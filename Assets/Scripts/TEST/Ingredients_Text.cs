using UnityEngine;
using EditorAttributes;
using TMPro;

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

        foreach (string keyword in GameManager.Instance.collectedKeywords.Keys)
        {
           if( GameManager.Instance.collectedKeywords[keyword])
            {
                temp += keyword + "\n";
            }
        }

        text.text = temp;
    }
}
