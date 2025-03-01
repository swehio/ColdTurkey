using UnityEngine;

public class IngredientSpawner : MonoBehaviour
{
    public GameObject ingredientPrefab;
    public Transform spawnPoint;

    public void SetIngredientPrefab(GameObject newPrefab)
    {
        ingredientPrefab = newPrefab;
    }

    public void SpawnIngredient()
    {
        if (ingredientPrefab != null && spawnPoint != null)
        {
            GameObject newIngredient = Instantiate(ingredientPrefab, spawnPoint.position, Quaternion.identity);
        }
    }

}
