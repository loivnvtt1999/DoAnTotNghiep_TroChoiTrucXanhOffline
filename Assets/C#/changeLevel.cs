using Assets.C_;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class changeLevel : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject changeLevelUI;
    public GameObject mainGame;
    List<PlayerHighScore> lstHighScore = new List<PlayerHighScore>();
    // Update is called once per frame
    void Start()
    {
        if (GameIsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }
    public void Resume()
    {
        changeLevelUI.SetActive(false);
        mainGame.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        changeLevelUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuGame");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
