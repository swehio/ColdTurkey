using NUnit.Framework;
using System.Collections.Generic;
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
    [SerializeField] DialogueData repeatDialogue;

    List<int> finishedDialogueIndexs = new (4);

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
        dialogue.isInteractable = true;

        if (index == results.Length - 1)
        {
            dialogue.SetDialogue(results[index]);
            return;
        }

        if(finishedDialogueIndexs.Contains(index))
        {
            dialogue.SetDialogue(repeatDialogue);
            return;
        }
        dialogue.SetDialogue(results[index]);

        finishedDialogueIndexs.Add(index);
    }
}
