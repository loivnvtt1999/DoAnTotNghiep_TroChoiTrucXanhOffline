using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerName : MonoBehaviour
{
    public Text validateText;
    public InputField playerName;
    private void Start()
    {
        PlayerPrefs.DeleteKey("playerName");
        validateText.enabled = false;
    }
    public void backMenu()
    {
        SceneManager.LoadScene("MenuGame");
    }
    public void getPlayerName()
    {
        string name = playerName.text;
        if (string.IsNullOrWhiteSpace(name))
        {
            validateText.enabled = true;
        }
        else
        {
            if (name.Length>7)
            {
                name = name.Substring(0, 4) + "...";
                PlayerPrefs.SetString("playerName", name);
                SceneManager.LoadScene("SampleScene");
            }
            else
            {
                PlayerPrefs.SetString("playerName", name);
                SceneManager.LoadScene("SampleScene");
            }       
        }
    }
}
