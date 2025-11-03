using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public static class LevelManager
{
    // Projectiles
    public static Dictionary<string, int> projectiles = new Dictionary<string, int>()
    {
        { "Projectile1", 50 },
        { "Projectile2", 50 },
        { "Projectile3", 50 }
    };

    // Remaining crates
    public static int cratesLeft = 5;

    // Score
    public static int score = 0;

    // UI references (assign these from scripts that create UI)
    public static TextMeshProUGUI projectile1Text;
    public static TextMeshProUGUI projectile2Text;
    public static TextMeshProUGUI projectile3Text;
    public static TextMeshProUGUI cratesText;

    // Call this when shooting a projectile
    public static bool UseProjectile(string type)
    {
        if (projectiles.ContainsKey(type) && projectiles[type] > 0)
        {
            projectiles[type]--;
            UpdateUI();
            return true;
        }
        return false; // no ammo
    }

    // Call when a crate is destroyed
    public static void CrateDestroyed()
    {
        if (cratesLeft > 0)
        {
            cratesLeft--;
            UpdateUI();
        }
        if (cratesLeft == 0)
        {
            SceneManager.LoadScene("EndScreen");
        }
    }

    public static void UpdateUI()
    {
        if (projectile1Text != null) projectile1Text.text = projectiles["Projectile1"].ToString();
        if (projectile2Text != null) projectile2Text.text = projectiles["Projectile2"].ToString();
        if (projectile3Text != null) projectile3Text.text = projectiles["Projectile3"].ToString();
        if (cratesText != null) cratesText.text = cratesLeft.ToString();
    }
}
