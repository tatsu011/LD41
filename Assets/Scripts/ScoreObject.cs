using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreObject : MonoBehaviour
{
    static int score = 0;

    public static void AddScore(int value)
    {
        score += value;
    }
    public static int GetScore()
    {
        return score;
    }


    void Update()
    {
        Text text = GetComponent<Text>();
        text.text = $"Score  {score}";
    }


}
