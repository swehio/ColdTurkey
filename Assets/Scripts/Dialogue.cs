using System.Collections;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Dialogue : MonoBehaviour, IPointerClickHandler
{
    public bool isInteractable = true;

    [SerializeField] DialogueData defaultData;
    [SerializeField] DialogueData endDialogueData;
    bool isFirstTime = true;
    DialogueData currentData;

    [SerializeField] ResponseOptions responseOptions;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] GameObject nextText;
    int index;

    WaitForSeconds interval;
    Coroutine coroutine;


    public bool IsReadToGoNext { get; private set; }
    void SetIsReadToGoNext(bool value)
    {
        IsReadToGoNext = value;
        nextText.SetActive(value);
    }

    [SerializeField] bool dontResetMouseinput;

    public UnityEvent onDialogueEnd;


    private void Awake()
    {
        if (!text) text = GetComponentInChildren<TextMeshProUGUI>();

    }

    private void OnEnable()
    {
        index = 0;

        currentData = isFirstTime ? defaultData : endDialogueData;

        isFirstTime = false;

        interval = new WaitForSeconds(.05f);
        StartLetterByLetterDialogue();

        MouseInputManager.UseMouseInput = false;
    }
    private void OnDisable()
    {
        onDialogueEnd.RemoveAllListeners();

        if (!dontResetMouseinput)
            MouseInputManager.UseMouseInput = true;
    }

    /*    private void Update()
        {
            timer += Time.deltaTime;

            if (timer <= 1f) return;

            timer = 0;

            var textInfo = text.textInfo;
            for (int i = 0; i < textInfo.characterCount; ++i)
            {
                var charInfo = textInfo.characterInfo[i];

                if (!charInfo.isVisible) continue;

                var verts = textInfo.meshInfo[charInfo.materialReferenceIndex].vertices;

                for (int j = 0; j < 4; ++j)
                {
                    var orig = verts[charInfo.vertexIndex + j];
                    verts[charInfo.vertexIndex + j] = orig + Vector3.up * Random.Range(-3f, 3f);
                }
            }

            for (int i = 0; i < textInfo.meshInfo.Length; ++i)
            {
                var meshInfo = textInfo.meshInfo[i];
                meshInfo.mesh.vertices = meshInfo.vertices;
                text.UpdateGeometry(meshInfo.mesh, i);
            }
        }*/

    public void SetDialogue(DialogueData data)
    {
        this.currentData = data;
        index = 0;
        StartLetterByLetterDialogue();
    }

    public void StartDialogue()
    {
        index = 0;
        SetText();
    }

    public void NextDialogue()
    {
        index++;
        SetText();
    }

    public void StartLetterByLetterDialogue()
    {
        if (coroutine != null) return;

        coroutine = StartCoroutine(nameof(CoLetterByLetterDialogue));
    }
    IEnumerator CoLetterByLetterDialogue()
    {
        text.text = "";

        SetIsReadToGoNext(false);

        StringBuilder currentText = new();
        string sentence = currentData.Strings[index];

        for (int charIndex = 0; charIndex < sentence.Length; charIndex++)
        {
            currentText.Append(sentence[charIndex]);
            text.text = currentText.ToString();

            if (char.IsSeparator(sentence[charIndex]))
                yield return null;
            else
                yield return interval;
        }

        SetIsReadToGoNext(true);

        index++;
        coroutine = null;
    }

    public void SkipCurrentDialogue()
    {
        StopCoroutine(coroutine);
        coroutine = null;

        SetText();
    }

    private void SetText()
    {
        text.text = currentData.Strings[index];
        SetIsReadToGoNext(true);
        index++;
    }

    public void Interact()
    {
        if (index >= currentData.Strings.Length)
        {
            if (currentData.Index >= 0)
                GameManager.Instance.CollectHint(currentData.Index, currentData.HintQuality);

            if (currentData.HintQuality != HintQuality.None)
            {
                responseOptions.gameObject.SetActive(true);

                isInteractable = false;

                index = 0;
            }
            else
            {
                onDialogueEnd?.Invoke();
                gameObject.SetActive(false);
            }

            return;
        }

        if (!IsReadToGoNext)
            SkipCurrentDialogue();
        else
            StartLetterByLetterDialogue();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isInteractable)
            Interact();
    }
}
