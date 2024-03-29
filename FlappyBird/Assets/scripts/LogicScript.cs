using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    private int score=0;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject pressJumpToStartScreen;
    [SerializeField] private TextMeshProUGUI HighScore;
    [SerializeField] private AudioClip newHighScore;
    [SerializeField] private AudioSource auidoSource;
    private string highScoreKey = "highScore";
    private bool hasPlayedHighScoreAudio = false;

    private void Start()
    {
        int highScore = PlayerPrefs.GetInt(highScoreKey);
        HighScore.text = "High Score: "+ highScore;
    }

    [ContextMenu("Increase Score")]

    public void AddScore()
    {
        score += 1;
        scoreText.text = score.ToString();
        if (score > PlayerPrefs.GetInt(highScoreKey) && !hasPlayedHighScoreAudio) 
        {
            Debug.Log("highScore achieve");
            auidoSource.clip = newHighScore;
            auidoSource.Play();
            hasPlayedHighScoreAudio=true;
        }
    }

    [ContextMenu("Increase 20 Score")]

    public void Add20Score()
    {
        score += 20;
        scoreText.text = score.ToString();
    }

    [ContextMenu("Increase 30 score")]
    public void Add30Score()
    {
        score += 30;
        scoreText.text = score.ToString();
    }

    public int ViewCurrentScore()
    {
        return score;
    }

    public void StartGame()
    {
        pressJumpToStartScreen.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        int highScore = PlayerPrefs.GetInt(highScoreKey);
        if (score > highScore)
        {
            PlayerPrefs.SetInt(highScoreKey, score);

        }
        gameOverScreen.SetActive(true);
    }

    
}
