using UnityEngine;

public class GameControl : MonoBehaviour
{
    // [Header("Object to Spawn")]
    public GameObject objectToSpawn; // assign your prefab here in the Inspector

    [Header("Spawn Settings")]
    public float spawnInterval = 1.5f; // seconds between spawns
    public float spawnHeight = 6f;     // world Y position for top of screen
    public float xRange = 7f;          // horizontal range for random spawn position

    private void Start()
    {
        // start spawning repeatedly
        InvokeRepeating(nameof(SpawnObject), 1f, spawnInterval);
    }

    void SpawnObject()
    {
        if (objectToSpawn == null)
        {
            Debug.LogWarning("No object assigned to spawn!");
            return;
        }

        // choose a random X position
        float randomX = Random.Range(-xRange, xRange);

        // position to spawn at (top of screen)
        Vector3 spawnPosition = new Vector3(randomX, spawnHeight, 0f);

        // instantiate the object
        Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
    }
}