using EditorAttributes;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum HintQuality
{
    None,
    Bad,
    Soso,
    Good,

    Add,
    DontAdd
}

public enum Result
{
    A,
    B,
    C,
    D
}

public enum EndingType
{
    TrueEnding,
    NormalGoodEnding,
    NormalBadEnding,
    BadEnding
}


public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [field: SerializeField] public int CurrentStage { get; private set; }

    [Header(" - Hint - ")]
    public Dictionary<int, HintQuality> collectedHints = new();
    int collectedHintCount;
    public void AddCollectecHintCount(int collectedHintCount) => this.collectedHintCount += collectedHintCount;
    [SerializeField] int goalKeywordCount = 2;

    [Button]
    void TestHints( HintQuality hintQuality)
    {
        for (int i = 0; i < 5; i++)
        {
            collectedHints[i] =hintQuality;
        }
    }

    [Header(" - Craft - ")]
    [SerializeField] GameObject craftBtn;

    [Header(" - Result - ")]
    [SerializeField] Potion potion;
    [SerializeField] ResultCanvas resultCanvas;
    public void SetPotion(Potion potion) => this.potion = potion;
    Result[] results = new Result[2];
    public Result GetResult() => results[CurrentStage];

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        Init();
    }

    private void Init()
    {
        for (int i = 0; i < 10; i++)
        {
            collectedHints.Add(i, HintQuality.None);
        }
    }

    public void CollectHint(int index, HintQuality quality)
    {
        if (collectedHints.ContainsKey(index))
        {
            if (quality == HintQuality.None)
                collectedHintCount++;
            else if (quality == HintQuality.Add)
            {
                collectedHints[index] = collectedHints[index] + 1;
                print(collectedHints[index]);
            }


            if (collectedHintCount >= goalKeywordCount)
            {
                craftBtn.SetActive(true);
            }
        }
    }

    public void MakeResult()
    {


        bool[] passFails = new bool[7];

        if (CurrentStage == 0)
        {
            passFails[0] = potion.ingredientCounts[0] >= 3 && potion.ingredientCounts[0] < 6;
            passFails[1] = true;
            passFails[2] = potion.ingredientCounts[2] >= 1 && potion.ingredientCounts[2] <= 3;
            passFails[3] = potion.ingredientCounts[3] == 0;
            passFails[4] = potion.ingredientCounts[4] == 0;
            passFails[5] = !potion.hasPoison;
            passFails[6] = potion.hasPower;

            if (!passFails[5])
            {
                results[0] = Result.D;
            }
            else if (!passFails[4] || !passFails[3] || !passFails[2] || !passFails[1] || !passFails[0])
            {
                results[0] = Result.C;
            }
            else if (!passFails[6])
            {
                results[0] = Result.B;
            }
            else
            {
                results[0] = Result.A;
            }
        }
        else
        {
            passFails[0] = potion.ingredientCounts[0] >= 3;
            passFails[1] = potion.ingredientCounts[1] == 0;
            passFails[2] = potion.ingredientCounts[2] >= 1;
            passFails[3] = potion.ingredientCounts[0] != 0 ? potion.ingredientCounts[3] < 3 : true;
            passFails[4] = potion.ingredientCounts[2] != 0 ? potion.ingredientCounts[4] < 3 : true;
            passFails[5] = !potion.hasPoison;
            passFails[6] = !potion.hasPower;

            if (!passFails[5])
            {
                results[1] = Result.D;
            }
            else if (!passFails[4] || !passFails[3] || !passFails[2] || !passFails[1] || !passFails[0])
            {
                results[1] = Result.C;
            }
            else if (!passFails[6])
            {
                results[1] = Result.B;
            }
            else
            {
                results[1] = Result.A;
            }
        }

        resultCanvas.Init();
    }

    public EndingType GetEndingType()
    {
        if (results.Contains(Result.D))
            return EndingType.BadEnding;
        else if (results.Contains(Result.C))
            return EndingType.NormalBadEnding;
        else if (results.Contains(Result.B))
            return EndingType.NormalGoodEnding;
        else
            return EndingType.TrueEnding;

    }

    [Button]
    void TEST_MakeResult()
    {
        MakeResult();
        print(results[0] + " / " + results[1]);
    }
}