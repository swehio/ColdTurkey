using UnityEngine;
using UnityEngine.EventSystems;

public class UIButtonHoverUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject uiObject; 

    void Start()
    {
        uiObject.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (uiObject != null)
        {
            uiObject.SetActive(true); 
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (uiObject != null)
        {
            uiObject.SetActive(false); 
        }
    }
}