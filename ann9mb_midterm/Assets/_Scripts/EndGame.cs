using UnityEngine;
using TMPro;

public class EndScreen : MonoBehaviour
{
    public TextMeshProUGUI finalScoreText;

    void Start()
    {
        int finalScore = ScoreCounter.score;
        finalScoreText.text = "Final Score: " + finalScore;
    }
}
