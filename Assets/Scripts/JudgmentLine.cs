using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgmentLine : MonoBehaviour
{
    public float time = 0f;
    public GameObject gameOverPanel;

    private void OnTriggerEnter2D(Collider2D other) {
        time = 0f;
        Debug.Log("Collision");
    }

    private void OnTriggerStay2D(Collider2D other) {
        time += Time.deltaTime;
        if(time >= 1.0f)
        {
            gameOverPanel.SetActive(true);
            GameManager.Instance.GameOver();
            Time.timeScale = 0;
        }
    }
}
