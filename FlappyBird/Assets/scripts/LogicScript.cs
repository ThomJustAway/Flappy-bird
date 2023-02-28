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
    [ContextMenu("Increase Score")]

    private void Start()
    {
        int highScore = PlayerPrefs.GetInt(highScoreKey);
        HighScore.text = "High Score: "+ highScore;
    }


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
