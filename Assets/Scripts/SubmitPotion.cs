using UnityEngine;
using UnityEngine.EventSystems;

public class PotionReceiver : MonoBehaviour
{
  //  public GameManager gameManager;

    public GameObject noPotionUI; 
    private GameObject currentPotion;

    private void Start()
    {
        if (noPotionUI != null)
            noPotionUI.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Potion")) 
        {
            currentPotion = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == currentPotion)
        {
            currentPotion = null;
        }
    }

    public void Submit()
    {
        if (currentPotion != null)
        {
            Potion PotionData = currentPotion.GetComponent<PotionDisplay>().potionData;

            if (PotionData != null)
            {
                Debug.Log($"Potion 제출됨!");
                GameManager.Instance.SetPotion(PotionData);
                Destroy(currentPotion); 
                currentPotion = null; 
            }
        }
        else
        {
            if (noPotionUI != null)
            {
                noPotionUI.SetActive(true); 
                Invoke("HideNoPotionUI", 2f); 
            }
        }
    }

    private void HideNoPotionUI()
    {
        if (noPotionUI != null)
            noPotionUI.SetActive(false);
    }
}