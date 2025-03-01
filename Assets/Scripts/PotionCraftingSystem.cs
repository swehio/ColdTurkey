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
            selectedIngredients[ingredient.ingredientNum]--;
            if (selectedIngredients[ingredient.ingredientNum] > 0) 
            {
                
                Debug.Log($"{ingredient.ingredientNum} 개수 감소! 남은 개수: {selectedIngredients[ingredient.ingredientNum]}");
            }
            else
            {
                Debug.Log($"재료가 없습니다!");
            }
        }
    }

    public void CraftPotion()
    {
        Sprite randomSprite = GetRandomSprite(); 
        Potion craftedPotion = DeterminePotion(randomSprite);

        DisplayPotionObject(craftedPotion);
    }

    private Potion DeterminePotion(Sprite potionSprite)
    {
        return new Potion(potionSprite, selectedIngredients, hasPower, hasPoison);
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
        GameObject potionObject = Instantiate(potionPrefab, potionSpawnPoint.position, Quaternion.identity);
        SpriteRenderer sr = potionObject.GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            sr.sprite = potion.icon;
        }
    }

}