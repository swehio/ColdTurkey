using UnityEngine;
using UnityEngine.UI;

public class PotionDisplay : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Potion potionData;
    public Text potionInfoText;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetPotionData(Potion potion)
    {
        potionData = potion;

        if (spriteRenderer != null && potionData != null)
        {
            spriteRenderer.sprite = potionData.icon;
        }

        if (potionInfoText != null)
        {
            potionInfoText.text = $"🧪 포션 정보\n" +
                                  $"Sprite: {potionData.icon.name}\n" +
                                  $"Ingredients: {string.Join(", ", potionData.ingredientCounts)}\n" +
                                  $"Has Power: {potionData.hasPower}\n" +
                                  $"Has Poison: {potionData.hasPoison}";
        }
        else
        {
            Debug.LogWarning("⚠ PotionDisplay: potionInfoText가 설정되지 않았습니다!");
        }
    }
}