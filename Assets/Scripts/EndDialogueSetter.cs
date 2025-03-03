using EditorAttributes;
using UnityEngine;

public class EndDialogueSetter : MonoBehaviour
{
    [SerializeField] int collectedHintCount;
    [SerializeField] Result[] results = new Result[2];

    [SerializeField] DialogueData[] dialogueDatas;
    Dialogue dialogue;

    int index = 0;

    private void Awake()
    {
        collectedHintCount = FinalResult.CollectHintCount;
        results = FinalResult.Results;

        dialogue = GetComponent<Dialogue>();
    }

    private void Start()
    {
        SetDialogue();
        
        SoundManager.instance.ChangeBGM(index);
    }

    void SetDialogue()
    {
        if (results[0] == Result.D && results[1] == Result.D)
        {
            if (collectedHintCount == 10)
                dialogue.SetDialogue(dialogueDatas[2]);
            else
                dialogue.SetDialogue(dialogueDatas[3]);

            index = 2;
        }
        else if (results[0] == Result.D)
        {
            dialogue.SetDialogue(dialogueDatas[0]);

            index = 2;
        }
        else if (results[1] == Result.D)
        {
            dialogue.SetDialogue(dialogueDatas[1]);

            index = 2;
        }
        else if (results[0] == Result.C && results[1] == Result.C)
        {
            if (collectedHintCount == 10)
                dialogue.SetDialogue(dialogueDatas[6]);
            else
                dialogue.SetDialogue(dialogueDatas[7]);

            index = 1;
        }
        else if (results[0] == Result.C)
        {
            dialogue.SetDialogue(dialogueDatas[4]);
            index = 1;
        }
        else if (results[1] == Result.C)
        {
            dialogue.SetDialogue(dialogueDatas[5]);
            index = 1;
        }
        else if (results[0] == Result.B || results[1] == Result.B)
        {
            if (collectedHintCount == 10)
                dialogue.SetDialogue(dialogueDatas[8]);
            else
                dialogue.SetDialogue(dialogueDatas[9]);
        }
        else
        {
            dialogue.SetDialogue(dialogueDatas[10]);
        }
        dialogue.enabled = true;
    }

    [Button]
    void TEST()
    {
        DialogueData data;

        if (results[0] == Result.D && results[1] == Result.D)
        {
            if (collectedHintCount == 10)
                data=(dialogueDatas[2]);
            else
                data= (dialogueDatas[3]);
        }
        else if (results[0] == Result.D)
        {
            data = (dialogueDatas[0]);
        }
        else if (results[1] == Result.D)
        {
            data = (dialogueDatas[1]);
        }
        else if (results[0] == Result.C && results[1] == Result.C)
        {
            if (collectedHintCount == 10)
                data = (dialogueDatas[6]);
            else
                data = (dialogueDatas[7]);
        }
        else if (results[0] == Result.C)
        {
            data = (dialogueDatas[4]);
        }
        else if (results[1] == Result.C)
        {
            data = (dialogueDatas[5]);
        }
        else if (results[0] == Result.B || results[1] == Result.B)
        {
            if (collectedHintCount == 10)
                data = (dialogueDatas[8]);
            else
                data = (dialogueDatas[9]);
        }
        else
        {
            data = (dialogueDatas[10]);
        }

        print(data.name);
    }
}
