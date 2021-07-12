using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class settingVolume : MonoBehaviour
{
    public Slider volumeSlider;
    private float volume = 50f;
    public void confirmVolume()
    {
        volume = volumeSlider.value;
        PlayerPrefs.SetFloat("volume", volume);
        SceneManager.LoadScene("MenuGame");
    }
}
