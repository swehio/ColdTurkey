using UnityEngine;

public class IngredientSpawner : MonoBehaviour
{
    [SerializeField] PotionCraftingSystem craftingSystem;

    public Ingredient ingredientPrefab;
    public Transform spawnPoint;
    public float spawnRadius = 10f;

    public void SetIngredientPrefab(Ingredient newPrefab)
    {
        ingredientPrefab = newPrefab;
    }

    public void SpawnIngredient()
    {
        if (ingredientPrefab != null && spawnPoint != null)
        {
            Vector2 spawnPosition = GetRandomSpawnPosition(spawnPoint.position, spawnRadius);

            var newIngredient = Instantiate(ingredientPrefab, spawnPosition, Quaternion.identity);

            craftingSystem.selectedIngredients[newIngredient.ingredientNum]++;
        }
    }

    private Vector2 FindSafeSpawnPosition()
    {
        Vector2 spawnPos = spawnPoint.position;

        int maxAttempts = 10;
        for (int i = 0; i < maxAttempts; i++)
        {
            Collider2D hitCollider = Physics2D.OverlapCircle(spawnPos, spawnRadius);
            if (hitCollider == null) 
            {
                return spawnPos;
            }
            else 
            {
                spawnPos = spawnPoint.position + (Vector3)(Random.insideUnitCircle * spawnRadius);
            }
        }

        return spawnPoint.position;
    }

    private Vector2 GetRandomSpawnPosition(Vector2 center, float spawnRadius)
    {
        Vector2 randomOffset = Random.insideUnitCircle * spawnRadius; 
        Vector2 newSpawnPosition = center + randomOffset; 

        return newSpawnPosition;
    }
}
