using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionCraftingSystem : MonoBehaviour
{
    public int[] selectedIngredients = new int[5]; // 재료 + 개수
    public bool hasPower = false;  // 주인공 능력 사용 여부
    public bool hasPoison = false; // 독약 사용 여부
    public PotionDisplay potionPrefab; // 제조된 약 프리팹
    public Transform potionSpawnPoint; // 약 생성 위치
    public Sprite[] potionSprites;
    public Text[] ingredientsInfo;
    public Text CreatingWarning;
    public Image[] spriteImages;

    public Color activeColor = Color.white;
    public Color inactiveColor = Color.gray;

    public void SetPower()
    {
        hasPower = !hasPower;
        UpdateIngredientsInfo();
    }
    public void SetPoison()
    {
        hasPoison = !hasPoison;
        UpdateIngredientsInfo();
    }

    private List<GameObject> spawnedIngredients = new List<GameObject>();

    private void Start()
    {
        UpdateIngredientsInfo();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Ingredient ingredient = other.GetComponent<Ingredient>(); 

        if (ingredient != null) 
        {
/*            selectedIngredients[ingredient.ingredientNum]++; 
            Debug.Log($"{ingredient.ingredientNum}이(가) 추가됨! 총 개수: {selectedIngredients[ingredient.ingredientNum]}");*/

            spawnedIngredients.Add(other.gameObject);
            UpdateIngredientsInfo();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Ingredient ingredient = other.GetComponent<Ingredient>(); 

        if (ingredient != null) 
        {
            if (selectedIngredients[ingredient.ingredientNum] > 0) 
            {
                selectedIngredients[ingredient.ingredientNum]--;
                Debug.Log($"{ingredient.ingredientNum} 개수 감소! 남은 개수: {selectedIngredients[ingredient.ingredientNum]}");

                UpdateIngredientsInfo();
            }
        }
    }

    public void UpdateIngredientsInfo()
    {
        for(int i = 0; i< ingredientsInfo.Length; i++)
        {
            if (ingredientsInfo[i] == null) 
            {
                continue;
            }

            Text infoText = ingredientsInfo[i].GetComponentInChildren<Text>();

            if (infoText != null)
            {
                infoText.text = selectedIngredients[i].ToString();
            }
        }

        if (spriteImages.Length < 2)
        {
            Debug.LogError("⚠ Sprite 배열 크기가 2보다 작습니다!");
            return;
        }

        spriteImages[0].color = hasPower ? activeColor : inactiveColor;  
        spriteImages[1].color = hasPoison ? activeColor : inactiveColor; 

    }

    public void CraftPotion()
    {
        bool allZero = true;
        foreach (int count in selectedIngredients)
        {
            if (count > 0)
            {
                allZero = false;
                break;
            }
        }

        if (!allZero)
        {
            Sprite StageSprite;
            if (GameManager.Instance.CurrentStage == 0)
            {
                StageSprite = potionSprites[0];
            }
            else
            {
                StageSprite = potionSprites[1];
            }

            int[] temp = new int[5];
            selectedIngredients.CopyTo(temp, 0);
            Potion craftedPotion = new Potion(StageSprite, temp, hasPower, hasPoison);

            DisplayPotionObject(craftedPotion);

            ClearIngredients();

            CreatingWarning.text = "약 완성!";
        }
        else
        {
            CreatingWarning.text = "재료를 넣어주세요!"; 
        }

    }

    public void ClearIngredients()
    {

        while (spawnedIngredients.Count > 0)
        {
            GameObject ingredient = spawnedIngredients[0]; 
            if (ingredient != null)
            {
                Destroy(ingredient);
            }
            spawnedIngredients.RemoveAt(0); 
        }

        hasPower = false; 
        hasPoison = false;

        UpdateIngredientsInfo();

    Debug.Log("모든 재료가 제거되었습니다!");
    }

    private Sprite GetRandomSprite()
    {
        if (potionSprites.Length > 0)
        {
            int randomIndex = Random.Range(0, potionSprites.Length);
            return potionSprites[randomIndex];
        }
        else
        {
            Debug.LogWarning("랜덤 스프라이트 배열이 비어 있습니다!");
            return null;
        }
    }

    private void DisplayPotionObject(Potion potion)
    {
        if (potionPrefab == null || potionSpawnPoint == null)
        {
            Debug.LogError("Error: potionPrefab 또는 potionSpawnPoint가 설정되지 않았습니다!");
            return;
        }

        PotionDisplay potionDisplay = Instantiate(potionPrefab, potionSpawnPoint.position, Quaternion.identity);

        if (potionDisplay != null)
        {
            potionDisplay.SetPotionData(potion); 
        }
    }
}