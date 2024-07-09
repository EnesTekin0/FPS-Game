using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score_Manager : MonoBehaviour
{
    public static int score;
    TextMeshProUGUI scoreText;
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        score = 0;
    }

    
    void Update()
    {
        if (score < 0)
            score = 0;
        scoreText.text = "Score:" + score;    
        if(score > PlayerPrefs. GetInt("highScore"))
        PlayerPrefs.SetInt("highScore", score);
    }
    public static void AddPoints(int addPoint)
    {
        score += addPoint;
    }
    public static void Reset()
    {
        score = 0;
    }
}
