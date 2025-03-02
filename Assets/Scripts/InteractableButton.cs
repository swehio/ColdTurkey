using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HoverScaleButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private RectTransform rectTransform;
    private Vector2 originalSize;
    public float scaleFactor = 1.1f;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        originalSize = rectTransform.sizeDelta; 
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        rectTransform.sizeDelta = originalSize*scaleFactor;  
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        rectTransform.sizeDelta = originalSize; // 원래 크기로 복구
    }
}