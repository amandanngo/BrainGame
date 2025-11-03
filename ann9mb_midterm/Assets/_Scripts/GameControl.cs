using UnityEngine;
using TMPro;

public class GameControl : MonoBehaviour
{
    // [Header("Object to Spawn")]
    public GameObject objectToSpawn; // assign your prefab here in the Inspector

    [Header("Spawn Settings")]
    public float spawnInterval = 1.5f; // seconds between spawns
    public float spawnHeight = 6f;     // world Y position for top of screen
    public float xRange = 7f;          // horizontal range for random spawn position

    public TextMeshProUGUI projectile1Text;
    public TextMeshProUGUI projectile2Text;
    public TextMeshProUGUI projectile3Text;
    public TextMeshProUGUI cratesText;

    

    private void Start()
    {
        // start spawning repeatedly
        InvokeRepeating(nameof(SpawnObject), 1f, spawnInterval);

        LevelManager.projectile1Text = this.projectile1Text;
        LevelManager.projectile2Text = this.projectile2Text;
        LevelManager.projectile3Text = this.projectile3Text;
        LevelManager.cratesText = this.cratesText;

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