using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResponseOptions : MonoBehaviour
{
    TextMeshProUGUI[] responseTexts;
    Button[] responseButtons;
    Dialogue dialogue;

    [SerializeField] Responses responses;
    [SerializeField] DialogueData[] results;

    private void Awake()
    {
        responseTexts = GetComponentsInChildren<TextMeshProUGUI>();
        responseButtons = GetComponentsInChildren<Button>();
        dialogue = GetComponentInParent<Dialogue>();
    }

    private void OnEnable()
    {
        for (int i = 0; i < responseTexts.Length; i++)
        {
            responseTexts[i].text = responses.Strings[i];
        }

        for (int i = 0; i < responseButtons.Length; i++)
        {
            int ii =i;
            responseButtons[i].onClick.AddListener(() => SetDialogue(ii));
            responseButtons[i].onClick.AddListener(() => gameObject.SetActive(false));
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < responseButtons.Length; i++)
        {
            responseButtons[i].onClick.RemoveAllListeners();
        }
    }

    public void SetDialogue(int index)
    {
        dialogue.SetDialogue(results[index]);
    }
}
