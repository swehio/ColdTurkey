using UnityEngine;
using UnityEngine.UI;

public class PotionDisplay : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Potion potionData;
    //public Text potionInfoText;
    private GameObject tooltip;
    public Font tooltipFont;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        CreateTooltip();
    }

    public void SetPotionData(Potion potion)
    {
        potionData = potion;

        if (spriteRenderer != null && potionData != null)
        {
            spriteRenderer.sprite = potionData.icon;
        }
        if (tooltip != null)
        {
            Text tooltipText = tooltip.GetComponentInChildren<Text>();
            if (tooltipText != null)
            {
                tooltipText.text = $"포션 정보\n" +
                                   $"Ingredients: {string.Join(", ", potionData.ingredientCounts)}\n" +
                                   $"Has Power: {potionData.hasPower}\n" +
                                   $"Has Poison: {potionData.hasPoison}";
            }

            tooltip.SetActive(false);
        }
        else
        {
            Debug.LogWarning(" PotionDisplay: tooltip이 생성되지 않았습니다!");
        }
    }

    private void CreateTooltip()
    {
        if (tooltip != null)
        {
            Destroy(tooltip);
        }

        tooltip = new GameObject("Tooltip");
        tooltip.transform.SetParent(GameObject.Find("Canvas").transform, false);

        Image bg = tooltip.AddComponent<Image>();
        bg.color = new Color(0, 0, 0, 0.7f);

        GameObject textObject = new GameObject("TooltipText");
        textObject.transform.SetParent(tooltip.transform, false);
        Text text = textObject.AddComponent<Text>();
        text.font = tooltipFont;
        text.color = Color.white;
        text.alignment = TextAnchor.MiddleCenter;

        RectTransform bgRect = tooltip.GetComponent<RectTransform>();
        bgRect.sizeDelta = new Vector2(200, 100); 

        RectTransform textRect = textObject.GetComponent<RectTransform>();
        textRect.sizeDelta = new Vector2(180, 80);

        tooltip.SetActive(false); 
    }

    private void OnMouseEnter()
    {
        if (tooltip != null)
        {
            tooltip.SetActive(true);
            tooltip.transform.position = Camera.main.WorldToScreenPoint(transform.position + Vector3.up * 1.5f);
        }
    }

    private void OnMouseExit()
    {
        if (tooltip != null)
        {
            tooltip.SetActive(false);
        }
    }

    private void OnMouseDown()
    {
        if (tooltip != null)
        {
            tooltip.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        if (tooltip != null)
        {
            Destroy(tooltip);
        }
    }
}