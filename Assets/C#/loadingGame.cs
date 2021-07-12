using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class loadingGame : MonoBehaviour
{
    // Start is called before the first frame update
    public Text timeStart;
    float time=5;
    // Update is called once per frame
    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            timeStart.text = Mathf.Round(time).ToString();
        }
        else
        {
            SceneManager.LoadScene("MenuGame");
        }
    }
}
