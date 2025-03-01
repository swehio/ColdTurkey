using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }


    [SerializeField] string[] keywords;
    public Dictionary<string, bool> collectedKeywords = new() { };
    int collectedKeywordCount;
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

        Init();
    }

    private void Init()
    {
        foreach (var keyword in keywords)
        {
            collectedKeywords.Add(keyword, false);
        }
    }

    public void CollectKeyword(string keyword)
    {
        if (collectedKeywords.ContainsKey(keyword))
        {
            collectedKeywords[keyword] = true;

            collectedKeywordCount++;

            if (collectedKeywordCount >= goalKeywordCount)
            {
                makeBtn.SetActive(true);
            }
        }
    }
}