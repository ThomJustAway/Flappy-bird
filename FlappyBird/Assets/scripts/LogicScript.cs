using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LogicScript : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    private int score=0;
    [SerializeField] private GameObject gameOverScreen;

    
    [ContextMenu("Increase Score")]
    public void addScore()
    {
        score += 1;
        scoreText.text = score.ToString();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }
}
