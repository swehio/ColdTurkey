using UnityEngine;

public static class FinalResult
{
    public static int CollectHintCount;
    public static Result[] Results = new Result[2];

    public static void Reset()
    {
        CollectHintCount = 0;
        Results = new Result[2];
    }
}
