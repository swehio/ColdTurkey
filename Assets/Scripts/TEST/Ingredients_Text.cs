using TMPro;
using UnityEngine;

public class Ingredients_Text : MonoBehaviour
{
    TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        string temp = "";

        foreach (var hint in GameManager.Instance.collectedHints.Keys)
        {
            temp += GameManager.Instance.collectedHints[hint] + "\n";
        }

        text.text = temp;
    }
}
