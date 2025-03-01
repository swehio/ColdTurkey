using System.Collections.Generic;
using UnityEngine;

public class PotionCraftingSystem : MonoBehaviour
{
    public int[] selectedIngredients = new int[5]; // 재료 + 개수
    public bool hasPower = false;  // 주인공 능력 사용 여부
    public bool hasPoison = false; // 독약 사용 여부
    public GameObject potionPrefab; // 제조된 약 프리팹
    public Transform potionSpawnPoint; // 약 생성 위치
    public Sprite[] potionSprites;

    public void SetPower(bool value) => hasPower = value;
    public void SetPoison(bool value) => hasPoison = value;


    private void OnTriggerEnter2D(Collider2D other)
    {
        Ingredient ingredient = other.GetComponent<Ingredient>(); 

        if (ingredient != null) 
        {
            selectedIngredients[ingredient.ingredientNum]++; 
            Debug.Log($"{ingredient.ingredientNum}이(가) 추가됨! 총 개수: {selectedIngredients[ingredient.ingredientNum]}");
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
            }
        }
    }

    public void CraftPotion()
    {
        Sprite randomSprite = GetRandomSprite();

        Potion craftedPotion = new Potion(randomSprite, selectedIngredients, hasPower, hasPoison);

        DisplayPotionObject(craftedPotion);
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
            Debug.LogWarning("⚠ 랜덤 스프라이트 배열이 비어 있습니다!");
            return null;
        }
    }

    private void DisplayPotionObject(Potion potion)
    {
        if (potionPrefab == null || potionSpawnPoint == null)
        {
            Debug.LogError("⚠ Error: potionPrefab 또는 potionSpawnPoint가 설정되지 않았습니다!");
            return;
        }

        GameObject potionObject = Instantiate(potionPrefab, potionSpawnPoint.position, Quaternion.identity);

        PotionDisplay potionDisplay = potionObject.GetComponent<PotionDisplay>();
        if (potionDisplay != null)
        {
            potionDisplay.SetPotionData(potion); 
        }
        else
        {
            Debug.LogWarning("⚠ PotionPrefab에 PotionDisplay 스크립트가 없습니다!");
        }
    }

}