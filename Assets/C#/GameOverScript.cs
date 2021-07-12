using Assets.C_;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Text scoreText;
    List<PlayerHighScore> lstHighScore = new List<PlayerHighScore>();
    List<Text> lstTextPlayer = new List<Text>();
    List<Text> lstTextScore = new List<Text>();
    public Text player1;
    public Text player2;
    public Text player3;
    public Text player4;
    public Text player5;
    public Text score1;
    public Text score2;
    public Text score3;
    public Text score4;
    public Text score5;
    bool checkLose = false;
    public void Setup(int score, bool check)
    {
        gameObject.SetActive(true);
        if (check == false)
        {
            scoreText.text = "ĐIỂM CỦA BẠN: " + score.ToString();
            Debug.Log(score.ToString());
        }
        else
        {
            Debug.Log("aaaa");
            scoreText.text = "TUYỆT! BẠN THUỘC TOP 5. " +"\n ĐIỂM CỦA BẠN:" + score.ToString();
        }
    }
    private void Start()
    {
        if (PlayerPrefs.GetInt("checkLose") == 1)
        {
            checkLose = true;   
        }
        else
        {
            checkLose = false;
        }
        Setup(PlayerPrefs.GetInt("scoreLose"), checkLose);
        lstTextPlayer.Clear();
        lstTextScore.Clear();
        lstHighScore.Clear();
        lstTextPlayer.Add(player1);
        lstTextPlayer.Add(player2);
        lstTextPlayer.Add(player3);
        lstTextPlayer.Add(player4);
        lstTextPlayer.Add(player5);
        lstTextScore.Add(score1);
        lstTextScore.Add(score2);
        lstTextScore.Add(score3);
        lstTextScore.Add(score4);
        lstTextScore.Add(score5);
        //PlayerPrefs.DeleteAll();
        int countListHighScore = PlayerPrefs.GetInt("count");
        //Debug.Log("countPlayerPref:" + countListHighScore.ToString());
        for (int i = 0; i < countListHighScore; i++)
        {
            PlayerHighScore player = new PlayerHighScore();
            player.playerName = PlayerPrefs.GetString("name" + i);
            player.score = PlayerPrefs.GetInt("score" + i);
            lstHighScore.Add(player);
        }
        //Debug.Log("countList: " + lstHighScore.Count);
        lstHighScore = lstHighScore.OrderByDescending(x => x.score).ToList();
        for (int i = 0; i < lstHighScore.Count(); i++)
        {
            if (lstHighScore[i].playerName.Length > 7)
            {
                lstTextPlayer[i].text = lstHighScore[i].playerName.Substring(0, 4);
            }
            else
            {
                lstTextPlayer[i].text = lstHighScore[i].playerName;
            }
            lstTextScore[i].text = lstHighScore[i].score.ToString();

        }
    }
    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void loadMenu()
    {
        SceneManager.LoadScene("MenuGame");
    }
}
