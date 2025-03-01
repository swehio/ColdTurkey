using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Potion
{
    public Sprite icon; 
    public int[] ingredientCounts;
    public bool hasPower; 
    public bool hasPoison;

    public Potion(Sprite potionIcon,  int[] ingredients, bool power, bool poison)
    {
        icon = potionIcon;
        ingredientCounts = ingredients;
        hasPower = power;
        hasPoison = poison;
    }
}
