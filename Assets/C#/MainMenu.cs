using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void Start()
    {
        //PlayerPrefs.DeleteAll();
    }
    public void PlayGame()
    {
        PlayerPrefs.SetString("level", "Dễ");
        SceneManager.LoadScene("PlayerName");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
