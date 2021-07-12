using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSettingScript : MonoBehaviour
{
    List<string> level = new List<string>();
    public Dropdown dropdown;
    string levelName;
    // Start is called before the first frame update
    private void Awake()
    {
        dropdown.options.Clear();
        dropdown.ClearOptions();
        level.Add("Dễ");
        level.Add("Khó");
        foreach (var item in level)
        {
            dropdown.options.Add(new Dropdown.OptionData() { text = item });
        }
    }
    void Start()
    {
        dropdown.value = 0;
        dropdown.Select();
        DropDownItemSelected(dropdown);
        dropdown.onValueChanged.AddListener(delegate
        {
            DropDownItemSelected(dropdown);
        });

    }
    void DropDownItemSelected(Dropdown dropdown)
    {
        int index = dropdown.value;
        levelName = dropdown.options[index].text.ToString();
    }
    public void backMenu()
    {
        SceneManager.LoadScene("MenuGame");
    }
    public void PlayWithLevel()
    {
        Debug.Log(levelName);
        PlayerPrefs.SetString("level", levelName);
        SceneManager.LoadScene("PlayerName");       
    }
}
