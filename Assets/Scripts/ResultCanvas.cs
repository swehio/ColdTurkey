using EditorAttributes;
using TMPro;
using UnityEngine;

public class ResultCanvas : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] DialogueData[] dialogueDatas;
    [SerializeField] Dialogue dialogue;

    [Button]
    public void Init()
    {
        Result result = GameManager.Instance.GetResult();

        TryGetComponent(out Canvas component);
        component.enabled = true;

        dialogue.SetDialogue(dialogueDatas[(int)result]);
        dialogue.gameObject.SetActive(true);
        dialogue.enabled = true;

        // TEST
        text.text = GameManager.Instance.GetResult().ToString();
    }
}
