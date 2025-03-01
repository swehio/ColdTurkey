using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Potion
{
    public string potionName; 
    public Sprite icon; 
    public Dictionary<string, int> ingredientCounts;
    public bool hasPower; 
    public bool hasPoison;

    public Potion(string name, Sprite potionIcon,  Dictionary<string, int> ingredients, bool power, bool poison)
    {
        potionName = name;
        icon = potionIcon;
        ingredientCounts = new Dictionary<string, int>(ingredients);
        hasPower = power;
        hasPoison = poison;
    }
}
