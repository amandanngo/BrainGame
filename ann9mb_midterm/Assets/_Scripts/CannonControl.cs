using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonControl : MonoBehaviour
{
    float angle = 0f;

    [Header("Projectile Settings")]
    public GameObject projectilePrefab1;
    public GameObject projectilePrefab2;
    public GameObject projectilePrefab3;

    public float projectileSpeed = 10f;   // Speed of the projectile
    public float cannonLength = 2f;       // Distance from pivot to cannon tip

    void Update()
    {
        // Get mouse position in world space
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        // Compute direction from cannon pivot to mouse
        Vector3 direction = mousePos3D - transform.position;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Rotate cannon toward mouse
        transform.rotation = Quaternion.Euler(0, 0, angle - 90);

        // Fire when pressing S
        if (Input.GetKeyDown(KeyCode.S))
        {
            Fire("Projectile1",projectilePrefab1);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Fire("Projectile2",projectilePrefab2);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            Fire("Projectile3",projectilePrefab3);
        }
    }

    void Fire(string projectileType, GameObject projectilePrefab)
    {
        // Check ammo via static LevelManager
        if (LevelManager.UseProjectile(projectileType))
        {
            // Shoot normally
            Vector3 shootDirection = transform.up;
            Vector3 spawnPos = transform.position + shootDirection * cannonLength;
            GameObject projGO = Instantiate(projectilePrefab, spawnPos, Quaternion.identity);
            Rigidbody rigidB = projGO.GetComponent<Rigidbody>();
            if (rigidB != null) rigidB.velocity = shootDirection * projectileSpeed;
        }
        else
        {
            Debug.Log("No ammo left for " + projectileType);
        }
    }

}
