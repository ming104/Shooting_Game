using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int currentScore;
    private int HighScore;

    public Text currentScoreUI;
    public Text HighScoreUI;

    public void SetScore()
    {
        
        currentScore++;
        currentScoreUI.text = "Score : " + currentScore;

        if(currentScore > PlayerPrefs.GetInt("HighScore"))
        {
            HighScore = currentScore;
            HighScoreUI.text = "HighScore : " + HighScore; 
            PlayerPrefs.SetInt("HighScore", HighScore);
        }
    }

    public int GetScore()
    {
        return currentScore;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0;
        if(!PlayerPrefs.HasKey("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", 0);
        }
        else
        {
            HighScoreUI.text = "HighScore : " + PlayerPrefs.GetInt("HighScore");
        }
      
    }

    // Update is called once per frame
    void Update()
    {
        //scoreText.text = "Score : " + score.ToString();
        //if(score >= PlayerPrefs.GetInt("HighScore"))
        //{
        //    PlayerPrefs.SetInt("HighScore", score);
        //}
        //HighScoreText.text = "HighScore : " + PlayerPrefs.GetInt("HighScore").ToString();
    }
}
