using EditorAttributes;
using TMPro;
using UnityEngine;

public class EndingCanvas : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] Dialogue dialogue;

    [Button]
    public void Init()
    {
        TryGetComponent(out Canvas component);
        component.enabled = true;
        dialogue.enabled = true;
        text.text = GameManager.Instance.GetEndingType().ToString();
    }
}
