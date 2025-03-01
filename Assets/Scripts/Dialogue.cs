using System.Collections;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Dialogue : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] DialogueData data;
    [SerializeField] ResponseOptions[] responseOptions;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] GameObject nextText;
    int index;
    int responseIndex;

    WaitForSeconds interval;
    Coroutine coroutine;

    public bool IsReadToGoNext { get; private set; }
    void SetIsReadToGoNext(bool value)
    {
        IsReadToGoNext = value;
        nextText.SetActive(value);
    }


    public UnityEvent onDialogueEnd;


    private void Awake()
    {
        if (!text) text = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        index = 0;

        interval = new WaitForSeconds(.1f);
        StartLetterByLetterDialogue();

        MouseInputManager.UseMouseInput = false;
    }
    private void OnDisable()
    {
        onDialogueEnd.RemoveAllListeners();

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
        this.data = data;
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
        string sentence = data.Strings[index];

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
        text.text = data.Strings[index];
        SetIsReadToGoNext(true);
        index++;
    }

    public void Interact()
    {
        if (index >= data.Strings.Length)
        {
            onDialogueEnd?.Invoke();

            if (data.HintQuality != HintQuality.None && data.HintQuality != HintQuality.Good)
            {
                GameManager.Instance.CollectHint(data.Index, data.HintQuality);

                responseOptions[responseIndex].gameObject.SetActive(true);

                responseIndex++;
            }
            else
                gameObject.SetActive(false);

            return;
        }

        if (!IsReadToGoNext)
            SkipCurrentDialogue();
        else
            StartLetterByLetterDialogue();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Interact();
    }
}
