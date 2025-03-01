using UnityEngine;

public class IngredientSpawner : MonoBehaviour
{
    public GameObject ingredientPrefab;
    public Transform spawnPoint;
    public float spawnRadius = 1f;

    public void SetIngredientPrefab(GameObject newPrefab)
    {
        ingredientPrefab = newPrefab;
    }

    public void SpawnIngredient()
    {
        if (ingredientPrefab != null && spawnPoint != null)
        {
            Vector2 safeSpawnPosition = FindSafeSpawnPosition();
            GameObject newIngredient = Instantiate(ingredientPrefab, spawnPoint.position, Quaternion.identity);
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

}
