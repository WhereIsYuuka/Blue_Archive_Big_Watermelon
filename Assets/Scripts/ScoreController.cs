using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    private static ScoreController instance;
    public int score = 0;
    public Text scoreText;
    public Text highScoreText, currentScoreText;
    
    private void Awake() {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        scoreText.text = "" + score;
    }

    public static ScoreController Instance
    {
        get { return instance; }
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "" + score;
    }

    public void ChangeScore()
    {
        //获取最高分
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        //如果分数大于最高分，则更新最高分
        if(score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
        //显示当前分数和最高分
        highScoreText.text = highScore + "";
        currentScoreText.text = score + "";

    }
}
