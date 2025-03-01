using System.Collections.Generic;
using UnityEngine;

public enum HintQuality
{
    None,
    Bad,
    Soso,
    Good
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }


    public Dictionary<int, HintQuality> collectedHints = new();
    int collectedHintCount;
    [SerializeField] int goalKeywordCount = 2;

    [SerializeField] GameObject makeBtn;

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

        for (int i = 0; i < 10; i++)
        {
            collectedHints.Add(i, HintQuality.None);
        }
    }



    public void CollectHint(int index, HintQuality quality)
    {
        if (collectedHints.ContainsKey(index))
        {
            if (collectedHints[index] == HintQuality.None)
                collectedHintCount++;

            collectedHints[index] = quality;


            if (collectedHintCount >= goalKeywordCount)
            {
                makeBtn.SetActive(true);
            }
        }
    }
}