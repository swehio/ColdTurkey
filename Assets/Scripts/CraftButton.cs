using UnityEngine;
using UnityEngine.UI;

public class CraftButton : MonoBehaviour
{
    [SerializeField] Dialogue[] dialogues;

    Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        button.onClick.AddListener(OnClick);
    }
    private void OnDisable()
    {
        button.onClick.RemoveListener(OnClick);
    }

    void OnClick()
    {
        int hintCount = GameManager.Instance.GetCollectedHintCount();

        if (hintCount < 2)
        {
            dialogues[0].gameObject.SetActive(true);
        }
        else if (hintCount >= 2 && hintCount<5)
        {
            dialogues[1].gameObject.SetActive(true);
            FinalResult.CollectHintCount += hintCount;
        }
        else
        {
            dialogues[2].gameObject.SetActive(true);
            FinalResult.CollectHintCount += hintCount;
        }

    }
}
