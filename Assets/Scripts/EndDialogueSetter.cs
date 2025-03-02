using UnityEngine;

public class EndDialogueSetter : MonoBehaviour
{
    int collectedHintCount;
    Result[] results = new Result[2];

    private void Awake()
    {
        collectedHintCount = FinalResult.CollectHintCount;
        results = FinalResult.Results;
    }
}
