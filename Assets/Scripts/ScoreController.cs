using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    private static ScoreController instance;
    private int score = 0;
    public Text scoreText;
    
    private void Awake() {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        scoreText.text = "分数: " + score;
    }

    public static ScoreController Instance
    {
        get { return instance; }
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "分数: " + score;
    }
}
