using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonControl : MonoBehaviour
{
    float angle = 0f;

    [Header("Projectile Settings")]
    public GameObject projectilePrefab;
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
            Fire();
        }
    }

    void Fire()
    {
        if (projectilePrefab == null)
        {
            Debug.LogWarning("Projectile Prefab not assigned!");
            return;
        }

        // Determine shooting direction (the cannon’s local up direction)
        Vector3 shootDirection = transform.up;

        // Calculate the spawn position (at the tip of the cannon)
        Vector3 spawnPos = transform.position + shootDirection * cannonLength;

        // Instantiate projectile and set position
        GameObject projGO = Instantiate(projectilePrefab, spawnPos, Quaternion.identity);

        // Apply velocity to projectile’s Rigidbody
        Rigidbody rigidB = projGO.GetComponent<Rigidbody>();
        if (rigidB != null)
        {
            rigidB.velocity = shootDirection * projectileSpeed;
        }
        else
        {
            Debug.LogWarning("Projectile prefab has no Rigidbody component!");
        }
    }
}
