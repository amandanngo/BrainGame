using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public static class ScoreCounter
{
    public static int score = 0;

    public static void AddPoints(int amount)
    {
        score += amount;
    }

    public static void Reset()
    {
        score = 0;
    }
}
