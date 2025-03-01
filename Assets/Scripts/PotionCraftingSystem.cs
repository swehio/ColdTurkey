using System.Collections.Generic;
using UnityEngine;

public class PotionCraftingSystem : MonoBehaviour
{
    public Dictionary<string, int> selectedIngredients = new Dictionary<string, int>(); // 재료 + 개수
    public bool hasPower = false;  // 주인공 능력 사용 여부
    public bool hasPoison = false; // 독약 사용 여부
    public GameObject potionPrefab; // 제조된 약 프리팹
    public Transform potionSpawnPoint; // 약 생성 위치
    public Sprite[] potionSprites;

    public void SetPower(bool value) => hasPower = value;
    public void SetPoison(bool value) => hasPoison = value;

    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.CompareTag("Draggable")) 
    //    {
    //        AddIngredient(other.gameObject.name); // 재료 이름 추가
    //        Destroy(other.gameObject); // 재료 오브젝트 삭제
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D other)
    {
        Ingredient ingredient = other.GetComponent<Ingredient>(); 

        if (ingredient != null) 
        {
            string ingredientName = ingredient.ingredientName; 

            if (selectedIngredients.ContainsKey(ingredientName))
            {
                selectedIngredients[ingredientName]++; 
            }
            else
            {
                selectedIngredients[ingredientName] = 1; 
            }

            Debug.Log($"{ingredientName}이(가) 추가됨! 총 개수: {selectedIngredients[ingredientName]}");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Ingredient ingredient = other.GetComponent<Ingredient>(); 

        if (ingredient != null) 
        {
            string ingredientName = ingredient.ingredientName; 

            if (selectedIngredients.ContainsKey(ingredientName))
            {
                selectedIngredients[ingredientName]--;

                if (selectedIngredients[ingredientName] <= 0) 
                {
                    selectedIngredients.Remove(ingredientName);
                    Debug.Log($"{ingredientName}이(가) 완전히 제거됨!");
                }
                else
                {
                    Debug.Log($"{ingredientName} 개수 감소! 남은 개수: {selectedIngredients[ingredientName]}");
                }
            }
        }
    }

    private void AddIngredient(string ingredientName)
    {
        if (selectedIngredients.ContainsKey(ingredientName))
            selectedIngredients[ingredientName]++;
        else
            selectedIngredients[ingredientName] = 1;

        Debug.Log($"재료 추가됨: {ingredientName}, 총 개수: {selectedIngredients[ingredientName]}");
    }

    public void CraftPotion()
    {
        Sprite randomSprite = GetRandomSprite(); 
        Potion craftedPotion = DeterminePotion(randomSprite);

        DisplayPotionObject(craftedPotion);

        Debug.Log($"포션 제작 완료: {craftedPotion.potionName}");
    }

    private Potion DeterminePotion(Sprite potionSprite)
    {
        string potionName = "일반 포션";

        bool correctPotion = (selectedIngredients.ContainsKey("재료1") && selectedIngredients["재료1"] >= 3 && selectedIngredients["재료1"] < 6) &&
                             (selectedIngredients.ContainsKey("재료3") && selectedIngredients["재료3"] >= 1 && selectedIngredients["재료3"] < 3) &&
                             hasPower;

        if (hasPoison)
        {
            potionName = "독 포션";
        }
        else if (correctPotion)
        {
            potionName = "완벽한 치유 포션";
        }
        else
        {
            potionName = "일반 치유 포션";
        }

        return new Potion(potionName, potionSprite, selectedIngredients, hasPower, hasPoison);
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