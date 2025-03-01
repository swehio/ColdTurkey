using EditorAttributes;
using System;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [Serializable]
    public struct Achievement
    {
        public Image image;
        public bool achieved;
    }

    [SerializeField] Achievement[] achievements;

    [SerializeField, Range(0, 2)] int currentLevel = 0;
    [SerializeField] Image[] levelImages;

    [SerializeField, Range(0, 3)] int cigaretteCount = 0;
    [SerializeField] Image[] cigarettes;

    [Button]
    void UpdateUI()
    {
        for (int i = 0; i < levelImages.Length; i++)
        {
            levelImages[i].color = i == currentLevel ? Color.yellow : Color.white;
        }

        for (int i = 0; i < achievements.Length; i++)
        {
            Color temp = achievements[i].image.color;

            temp.a = achievements[i].achieved ? .5f : .2f;

            achievements[i].image.color = temp;
        }

        for (int i = 0; i < cigarettes.Length; i++)
        {
            cigarettes[i].gameObject.SetActive(i < cigaretteCount);
        }
    }
}
