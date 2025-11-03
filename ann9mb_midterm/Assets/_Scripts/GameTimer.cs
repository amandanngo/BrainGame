using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    [Header("Timer Settings")]
    public float startTime = 60f;   // total countdown time in seconds
    private float currentTime;

    [Header("UI Reference")]
    public TextMeshProUGUI timerText;

    private bool isRunning = true;

    void Start()
    {
        currentTime = startTime;
    }

    void Update()
    {
        if (!isRunning) return;

        // Count down
        currentTime -= Time.deltaTime;

        // Clamp so it doesn’t go negative
        if (currentTime < 0)
        {
            currentTime = 0;
            isRunning = false;
            EndGame();
        }

        // Format and display time
        UpdateTimerDisplay();
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        timerText.text = $"Time: {minutes:00}:{seconds:00}";
    }

    void EndGame()
    {
        Debug.Log("⏰ Time's up!");
        // Example: Stop spawning crates or show end screen
        // You can add your own logic here
    }

    // Optional helper functions:
    public void ResetTimer()
    {
        currentTime = startTime;
        isRunning = true;
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    public void StartTimer()
    {
        isRunning = true;
    }
}
