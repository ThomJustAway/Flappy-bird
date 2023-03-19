using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseListener : MonoBehaviour
{

    private bool stop = false;
    [SerializeField] private GameObject pauseGameMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //stop = !stop;
            //OnEscKeyPressed?.Invoke(this, stop);
            if (!stop)
            {
                Time.timeScale = 0f;
                AudioListener.pause = true;
                pauseGameMenu.SetActive(true);
            }
            else
            {
                Time.timeScale = 1f;
                pauseGameMenu.SetActive(false);
                AudioListener.pause = false;
            }
            stop = !stop;
        }
    }

    public void ExitGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
