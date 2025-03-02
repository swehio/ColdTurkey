using UnityEngine;
using UnityEngine.UI;

public class SubmitPotion : MonoBehaviour
{
    //  public GameManager gameManager;

    public Text noPotionText;
    private PotionDisplay currentPotion;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Draggable"))
        {
            if (other.TryGetComponent(out currentPotion))
            {
                Debug.Log($"포션 감지됨: {currentPotion.name}");
            }
            else
            {
                Debug.LogWarning("잘못된 아이템이 감지되었습니다!");
                if (noPotionText != null)
                {
                    noPotionText.text =  "약이 아닙니다!";
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == currentPotion.gameObject)
        {
            currentPotion = null;
        }
    }

    public void Submit()
    {
        if (currentPotion != null)
        {
            Potion PotionData = currentPotion.potionData;

            if (PotionData != null)
            {

                Debug.Log($"Potion 제출됨!");
                GameManager.Instance.SetPotion(PotionData);
                GameManager.Instance.MakeResult();
                 Destroy(currentPotion);
                 currentPotion = null;

                GetComponentInParent<Canvas>().gameObject.SetActive(false);
            }
        }
        else
        {
            if (noPotionText != null)
            {
                noPotionText.text = "제출할 약이 없습니다!";
            }
        }
    }

}