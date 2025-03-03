using EditorAttributes;
using TMPro;
using UnityEngine;

public class ResultCanvas : MonoBehaviour
{
    [SerializeField] DialogueData[] dialogueDatas;
    [SerializeField] Dialogue dialogue;

    [Button]
    public void Init()
    {
        Result result = GameManager.Instance.GetResult();

        print(result);

        TryGetComponent(out Canvas component);
        component.enabled = true;

        dialogue.SetDialogue(dialogueDatas[(int)result]);
        dialogue.gameObject.SetActive(true);
        dialogue.enabled = true;

    }
}
