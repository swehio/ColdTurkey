using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class RecipeBook : MonoBehaviour
{
    public Text[] recipeTexts;
    public GameManager gameManager; 

    public Dictionary<int, Dictionary<int, Dictionary<HintQuality, string[]>>> stageHintTexts = new();

    public int testStage = 0;
    private Dictionary<int, HintQuality> testCollectedHints = new()
    {
        { 0, HintQuality.Bad },
        { 1, HintQuality.Bad },
        { 2, HintQuality.Soso },
        { 3, HintQuality.Bad },
        { 4, HintQuality.None }
    };

    private void Start()
    {
        InitializeHintTexts(); 
        UpdateRecipeUI();
    }

    private void InitializeHintTexts()
    {
        stageHintTexts[0] = new Dictionary<int, Dictionary<HintQuality, string[]>>()
        {
            { 0, new Dictionary<HintQuality, string[]> {
                { HintQuality.None, new string[] { "world_1_hint_1_a" } },
                { HintQuality.Bad, new string[] { "world_1_hint_1_a", "world_1_hint_1_b" } },
                { HintQuality.Soso, new string[] { "world_1_hint_1_a", "world_1_hint_1_c" } },
                { HintQuality.Good, new string[] { "world_1_hint_1_a", "world_1_hint_1_a", "world_1_hint_1_c" } }
            }},
            { 1, new Dictionary<HintQuality, string[]> {
                { HintQuality.None, new string[] { "world_1_hint_2_a" } },
                { HintQuality.Bad, new string[] { "world_1_hint_2_a", "world_1_hint_2_b" } },
                { HintQuality.Soso, new string[] { "world_1_hint_2_a", "world_1_hint_2_c" } },
                { HintQuality.Good, new string[] { "world_1_hint_2_a", "world_1_hint_2_a", "world_1_hint_2_c" } }
            }},
            { 2, new Dictionary<HintQuality, string[]> {
                { HintQuality.Bad, new string[] { "world_1_hint_3_a" } },
                { HintQuality.Good, new string[] { "world_1_hint_3_a", "world_1_hint_3_b" } }
            }},
            { 3, new Dictionary<HintQuality, string[]> {
                { HintQuality.Bad, new string[] { "world_1_hint_4_a" } },
                { HintQuality.Good, new string[] { "world_1_hint_4_a", "world_1_hint_4_b" } }
            }},
            { 4, new Dictionary<HintQuality, string[]> {
                { HintQuality.Bad, new string[] { "world_1_hint_5_a" } },
                { HintQuality.Good, new string[] { "world_1_hint_5_a", "world_1_hint_5_b" } }
            }}
        };

        stageHintTexts[1] = new Dictionary<int, Dictionary<HintQuality, string[]>>()
        {
            { 0, new Dictionary<HintQuality, string[]> {
                { HintQuality.None, new string[] { "world_2_hint_1_a" } },
                { HintQuality.Bad, new string[] { "world_2_hint_1_a", "world_2_hint_1_b" } },
                { HintQuality.Soso, new string[] { "world_2_hint_1_a", "world_2_hint_1_c" } },
                { HintQuality.Good, new string[] { "world_2_hint_1_a", "world_2_hint_1_a", "world_2_hint_1_c" } }
            }},
            { 1, new Dictionary<HintQuality, string[]> {
                { HintQuality.None, new string[] { "world_2_hint_2_a" } },
                { HintQuality.Bad, new string[] { "world_2_hint_2_a", "world_2_hint_2_b" } },
                { HintQuality.Soso, new string[] { "world_2_hint_2_a", "world_2_hint_2_c" } },
                { HintQuality.Good, new string[] { "world_2_hint_2_a", "world_2_hint_2_a", "world_2_hint_2_c" } }
            }},
            { 2, new Dictionary<HintQuality, string[]> {
                { HintQuality.Bad, new string[] { "world_2_hint_3_a" } },
                { HintQuality.Good, new string[] { "world_2_hint_3_a", "world_2_hint_3_b" } }
            }},
            { 3, new Dictionary<HintQuality, string[]> {
                { HintQuality.Bad, new string[] { "world_2_hint_4_a" } },
                { HintQuality.Good, new string[] { "world_2_hint_4_a", "world_2_hint_4_b" } }
            }},
            { 4, new Dictionary<HintQuality, string[]> {
                { HintQuality.Bad, new string[] { "world_2_hint_5_a" } },
                { HintQuality.Good, new string[] { "world_2_hint_5_a", "world_2_hint_5_b" } }
            }}
        };
    }

    public void UpdateRecipeUI()
    {
        //if (GameManager.Instance == null || GameManager.Instance.collectedHints == null)
        //{
        //    Debug.LogError("⚠ GameManager 또는 collectedHints가 설정되지 않았습니다!");
        //    return;
        //}
        //TEST
        int currentStage = testStage;
        //int currentStage = GameManager.Instance.CurrentStage;

        //if (!stageHintTexts.ContainsKey(currentStage))
        //{
        //    Debug.LogWarning($"⚠ 스테이지 {currentStage}에 대한 힌트 데이터가 없습니다.");
        //    return;
        //}

        Dictionary<int, Dictionary<HintQuality, string[]>> currentStageHints = stageHintTexts[currentStage];

        //TEST
        List<int> hintKeys = new List<int>(testCollectedHints.Keys);
        hintKeys.Sort();

        //List<int> hintKeys = new List<int>(GameManager.Instance.collectedHints.Keys);
        //hintKeys.Sort();

        for (int i = 0; i < recipeTexts.Length; i++)
        {
            if (i < hintKeys.Count)
            {
                int hintID = hintKeys[i];
                if (!currentStageHints.ContainsKey(hintID))
                {
                    continue;
                }
                //TEST
                HintQuality hintQuality = testCollectedHints[hintID];
                //HintQuality hintQuality = GameManager.Instance.collectedHints[hintID];
                if (!currentStageHints[hintID].ContainsKey(hintQuality))
                {
                    continue;
                }

                string[] hints = currentStageHints[hintID][hintQuality];
                recipeTexts[i].text = string.Join("\n", hints);
            }
            else
            {
            }
        }
    }
}