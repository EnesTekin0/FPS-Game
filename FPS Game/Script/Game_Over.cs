using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Over : MonoBehaviour
{
    [SerializeField] TMP_Text scoreDisplayText;
    [SerializeField] TMP_Text highScoreDisplayText;
    private void Start()
    {
        //İmleç açık
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        ScoreDisplay();
        HighScoreDisplay();
    }

    private void ScoreDisplay ( )
    {
        if (Score_Manager.score < 0)
            Score_Manager.score = 0;
        scoreDisplayText.text = "Your Score : "+ Score_Manager.score;
    }

    private void HighScoreDisplay ( )
    {
        highScoreDisplayText.text = "High Score :" + PlayerPrefs.GetInt("highScore").ToString();
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(1);
    }
}