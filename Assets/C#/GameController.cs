using Assets.C_;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using Newtonsoft.Json;
public class GameController : MonoBehaviour
{
    List<Button> ListBtn = new List<Button>();
    public Sprite background_image;
    public Transform Panel;
    [SerializeField]
    private GameObject Button;
    GameObject btn;
    [SerializeField]
    public Sprite[] sourceSprites;
    public GameOverScript GameOverScript;
    public WinGame winGameScripting;
    public Text playerName;
    List<GameObject> lstBtnCreate = new List<GameObject>();
    string getLevel;
    private bool firstButtonClick, secondButtonClick;
    string firstButtonName, secondButtonName;
    int firstIndex, secondIndex, numMatch, numWin;
    float time;
    public Text timeText;
    public GameObject mainGame;
    public Text score;
    public List<Sprite> sprites = new List<Sprite>();
    List<ManChoi> lstManChoi = new List<ManChoi>();
    List<ManChoi> lstManChoiDe = new List<ManChoi>();
    List<ManChoi> lstManChoiKho = new List<ManChoi>();
    List<PlayerHighScore> lstHighScore = new List<PlayerHighScore>();
    int ngang;
    int doc;
    int ManHienTai;
    float timeDown;
    int Diem;
    public GameObject changeLevelUI;
    public GameObject pauseGame;
    public AudioSource gameAudio;
    public AudioClip matchAudio, wrongAudio, congthoigianAudio;
    private void Awake()
    {
        #region thêm màn
        //Dễ
        lstManChoiDe.Add(new ManChoi() { MaMan = 1, TenMan = "3x2 dễ", Ngang = 3, Doc = 2, ThoiGian = 10, Diem = 1, TocDoAnHinh = 0.5f, MaCapDo = 1 });
        lstManChoiDe.Add(new ManChoi() { MaMan = 2, TenMan = "3x3 dễ", Ngang = 3, Doc = 3, ThoiGian = 15, Diem = 2, TocDoAnHinh = 0.5f, MaCapDo = 1 });
        lstManChoiDe.Add(new ManChoi() { MaMan = 3, TenMan = "3x4 dễ", Ngang = 3, Doc = 4, ThoiGian = 17, Diem = 3, TocDoAnHinh = 0.5f, MaCapDo = 1 });
        //lstManChoiDe.Add(new ManChoi() { MaMan = 4, TenMan = "3x5 dễ", Ngang = 3, Doc = 5, ThoiGian = 20, Diem = 4, TocDoAnHinh = 0.5f, MaCapDo = 1 });
        //lstManChoiDe.Add(new ManChoi() { MaMan = 5, TenMan = "4x2 dễ", Ngang = 4, Doc = 2, ThoiGian = 20, Diem = 5, TocDoAnHinh = 0.5f, MaCapDo = 1 });
        //lstManChoiDe.Add(new ManChoi() { MaMan = 6, TenMan = "4x3 dễ", Ngang = 4, Doc = 3, ThoiGian = 24, Diem = 6, TocDoAnHinh = 0.5f, MaCapDo = 1 });
        //lstManChoiDe.Add(new ManChoi() { MaMan = 7, TenMan = "4x4 dễ", Ngang = 4, Doc = 4, ThoiGian = 30, Diem = 7, TocDoAnHinh = 0.5f, MaCapDo = 1 });
        //lstManChoiDe.Add(new ManChoi() { MaMan = 8, TenMan = "4x5 dễ", Ngang = 4, Doc = 5, ThoiGian = 35, Diem = 7, TocDoAnHinh = 0.5f, MaCapDo = 1 });
        //lstManChoiDe.Add(new ManChoi() { MaMan = 9, TenMan = "5x3 dễ", Ngang = 5, Doc = 3, ThoiGian = 35, Diem = 8, TocDoAnHinh = 0.5f, MaCapDo = 1 });

        //Khó
        lstManChoiKho.Add(new ManChoi() { MaMan = 10, TenMan = "3x2 khó", Ngang = 3, Doc = 2, ThoiGian = 8, Diem = 4, TocDoAnHinh = 0.2f, MaCapDo = 2 });
        lstManChoiKho.Add(new ManChoi() { MaMan = 11, TenMan = "3x3 khó", Ngang = 3, Doc = 3, ThoiGian = 13, Diem = 5, TocDoAnHinh = 0.2f, MaCapDo = 2 });
        lstManChoiKho.Add(new ManChoi() { MaMan = 12, TenMan = "3x4 khó", Ngang = 3, Doc = 4, ThoiGian = 15, Diem = 6, TocDoAnHinh = 0.2f, MaCapDo = 2 });
        //lstManChoiKho.Add(new ManChoi() { MaMan = 13, TenMan = "3x5 khó", Ngang = 3, Doc = 5, ThoiGian = 18, Diem = 7, TocDoAnHinh = 0.2f, MaCapDo = 2 });
        //lstManChoiKho.Add(new ManChoi() { MaMan = 14, TenMan = "4x2 khó", Ngang = 4, Doc = 2, ThoiGian = 18, Diem = 8, TocDoAnHinh = 0.2f, MaCapDo = 2 });
        //lstManChoiKho.Add(new ManChoi() { MaMan = 15, TenMan = "4x3 khó", Ngang = 4, Doc = 3, ThoiGian = 20, Diem = 9, TocDoAnHinh = 0.2f, MaCapDo = 2 });
        //lstManChoiKho.Add(new ManChoi() { MaMan = 16, TenMan = "4x4 khó", Ngang = 4, Doc = 4, ThoiGian = 28, Diem = 10, TocDoAnHinh = 0.2f, MaCapDo = 2 });
        //lstManChoiDe.Add(new ManChoi()  { MaMan = 17, TenMan = "4x5 khó", Ngang = 4, Doc = 5, ThoiGian = 33, Diem = 11, TocDoAnHinh = 0.2f, MaCapDo = 1 });
        //lstManChoiKho.Add(new ManChoi() { MaMan = 18, TenMan = "5x3 khó", Ngang = 5, Doc = 3, ThoiGian = 33, Diem = 12, TocDoAnHinh = 0.2f, MaCapDo = 2 });



        #endregion
        // lấy danh sách hình từ resource
        sourceSprites = Resources.LoadAll<Sprite>("icon/Images");
        foreach (var item in sourceSprites)
        {
            Debug.Log(item);
        }
        lstHighScore.Clear();
        //PlayerPrefs.DeleteAll();
        int countListHighScore = PlayerPrefs.GetInt("count");
        Debug.Log("countPlayerPref:" + countListHighScore.ToString());
        for(int i=0; i < countListHighScore; i++)
        {
            PlayerHighScore player = new PlayerHighScore();
            player.playerName = PlayerPrefs.GetString("name" + i);
            player.score = PlayerPrefs.GetInt("score" + i);
            lstHighScore.Add(player);
        }
        Debug.Log("countList: "+lstHighScore.Count);
        foreach (var item in lstHighScore)
        {
            Debug.Log("Item in List: " + item.playerName);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        getLevel = PlayerPrefs.GetString("level");
        Debug.Log("get level" + getLevel);
        if (getLevel == null || getLevel.Equals("Dễ"))
        {
            lstManChoi = lstManChoiDe;
            ManHienTai = 0;
            Diem = 0;
        }
        else
        {
            lstManChoi = lstManChoiKho;
            ManHienTai = 0;
            Diem = 0;
            Debug.Log(getLevel);
        }
        this.ngang = lstManChoi[ManHienTai].Ngang;
        this.doc = lstManChoi[ManHienTai].Doc;
        StartLevel();
        playerName.text = PlayerPrefs.GetString("playerName");
        timeText.text = time.ToString();
        gameAudio.Play();
        gameAudio.volume = PlayerPrefs.GetFloat("volume");
    }
    void StartLevel()
    {
        timeDown = lstManChoi[ManHienTai].TocDoAnHinh;
        time = lstManChoi[ManHienTai].ThoiGian;
        CreateButton();
        GetButton();
        AddButtonListener();
        AddImageForButton();
    }
    void AddImageForButton()
    {
        sprites = new List<Sprite>();
        for (int i = 0; i < ListBtn.Count; i++)
        {
            Sprite sprite = null;
            sprites.Add(sprite);
        }
        numMatch = 0;
        numWin = ListBtn.Count / 2;
        if (ListBtn.Count % 2 == 0)
        {
            for (int i = 0; i < numWin; i++)
            {
                int randImage = Random.Range(0, sourceSprites.Length - 1);
                int dem = 0;
                while (dem < 2)
                {
                    int randButton = Random.Range(0, sprites.Count);
                    if (sprites[randButton] == null)
                    {
                        sprites[randButton] = (sourceSprites[randImage]);
                        dem++;
                    }
                }
            }
        }
        else
        {
            for (int i = 0; i < numWin; i++)
            {
                int randImage = Random.Range(0, sourceSprites.Length - 1);
                int dem = 0;
                while (dem < 2)
                {
                    int randButton = Random.Range(0, sprites.Count);
                    if (sprites[randButton] == null)
                    {
                        sprites[randButton] = (sourceSprites[randImage]);
                        dem++;
                    }
                }
            }
            numWin += 1;
        }
        foreach (var item in sprites)
        {
            Debug.Log(item);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            timeText.text = Mathf.Round(time).ToString();
            score.text = Mathf.Round(Diem).ToString();
        }
        else
        {
            PlayerHighScore highScore = new PlayerHighScore();
            PlayerHighScore minScoreInTop5 = new PlayerHighScore();
            highScore.playerName = playerName.text;
            highScore.score = Diem;
            if (lstHighScore.Count < 5)
            {
                lstHighScore.Add(highScore);
            }
            else
            {
                minScoreInTop5 = lstHighScore.OrderByDescending(x => x.score).LastOrDefault();
                if (highScore.score > minScoreInTop5.score)
                {
                    lstHighScore.Remove(minScoreInTop5);
                    lstHighScore.Add(highScore);
                }
            }
            for (int i = 0; i < lstHighScore.Count; i++)
            {
                PlayerPrefs.SetString("name" + i, lstHighScore[i].playerName);
                PlayerPrefs.SetInt("score" + i, lstHighScore[i].score);
            }
            PlayerPrefs.SetInt("count", lstHighScore.Count);
            PlayerPrefs.Save();
            enabled = false;
            SceneManager.LoadScene("LoseGame");
            if (Diem > lstHighScore.OrderByDescending(x => x.score).LastOrDefault().score)
            {
                PlayerPrefs.SetInt("scoreLose", Diem);
                PlayerPrefs.SetInt("checkLose", 1);
            }
            else
            {
                PlayerPrefs.SetInt("scoreLose", Diem);
                PlayerPrefs.SetInt("checkLose", 0);
            }              
            return;
        }
    }

    void StartNewLevel()
    {
        ManHienTai++;//tăng màn
        if (ManHienTai == lstManChoi.Count) //hết màn, quay lại từ đầu
        {
            PlayerHighScore highScore = new PlayerHighScore();
            PlayerHighScore minScoreInTop5 = new PlayerHighScore();
            highScore.playerName = playerName.text;
            highScore.score = Diem;
            if (lstHighScore.Count < 5)
            {
                lstHighScore.Add(highScore);
            }
            else
            {
                minScoreInTop5 = lstHighScore.OrderByDescending(x => x.score).LastOrDefault();
                if (highScore.score > minScoreInTop5.score)
                {
                    lstHighScore.Remove(minScoreInTop5);
                    lstHighScore.Add(highScore);
                }
            }
            for(int i=0; i<lstHighScore.Count;i++)
            {
                PlayerPrefs.SetString("name" + i, lstHighScore[i].playerName);
                PlayerPrefs.SetInt("score" + i, lstHighScore[i].score); 
            }
            PlayerPrefs.SetInt("count", lstHighScore.Count);
            PlayerPrefs.Save();
            PlayerPrefs.SetInt("scoreWin", Diem);
            SceneManager.LoadScene("WinGame");
            return;
        }
        //Xóa mấy cái nút màn trước
        foreach (var item in lstBtnCreate)
        {
            Destroy(item);
        }
        lstBtnCreate = new List<GameObject>();
        //Set lại mấy thuộc tính
        this.ngang = lstManChoi[ManHienTai].Ngang;
        this.doc = lstManChoi[ManHienTai].Doc;
        ListBtn = new List<Button>();
        firstButtonClick = false;
        secondButtonClick = false;
        numMatch = 0;
        numWin = 0;
        Panel.DetachChildren();
        ListBtn = new List<Button>();
        sprites = new List<Sprite>();
        Time.timeScale = 0f;
        mainGame.SetActive(false);
        changeLevelUI.SetActive(true);
        StartLevel();   
    }
    public void LoadPauseGame()
    {
        Time.timeScale = 0f;
        pauseGame.SetActive(true);
    }
    void CreateButton()
    {
        //Tạo tag mới
        string tag = "Button" + lstManChoi[ManHienTai].MaMan;
        //Tạo nút rồi gắn tag
        for (int i = 0; i < this.ngang * this.doc; i++)
        {
            btn = Instantiate(Button);
            //btn.tag = tag;
            btn.name = "" + i;
            btn.transform.SetParent(Panel, false);
            lstBtnCreate.Add(btn);
        }
    }

    void GetButton()
    {
        //Lấy những bút đã tạo, set backgrond "?"
        for (int i = 0; i < lstBtnCreate.Count; i++)
        {
            ListBtn.Add(lstBtnCreate[i].GetComponent<Button>());
            ListBtn[i].image.sprite = background_image;
            ListBtn[i].GetComponentInChildren<Text>().text = "";
        }
        // Set thuộc tính cho grid
        Panel.GetComponent<GridLayoutGroup>().constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        Panel.GetComponent<GridLayoutGroup>().constraintCount = lstManChoi[ManHienTai].Ngang;
        Panel.GetComponent<GridLayoutGroup>().cellSize = new Vector2(100, 100);
    }

    void AddButtonListener()
    {
        //Thêm sự kiện cho nút
        foreach (var btn in ListBtn)
        {
            btn.onClick.AddListener(() => PickButton());
        }
    }

    void PickButton()
    {
        if (!firstButtonClick)
        {
            firstButtonClick = true; //hình 1 được ấn chuyển thành true
            firstIndex = int.Parse(EventSystem.current.currentSelectedGameObject.name);
            if (sprites[firstIndex] == null) //Ô trống, xóa ô trống
            {
                gameAudio.PlayOneShot(congthoigianAudio);
                ListBtn[firstIndex].interactable = false;
                ListBtn[firstIndex].image.color = new Color(0, 0, 0, 0);
                firstButtonClick = false;
                time += 5;
                numMatch++;
                Diem += lstManChoi[ManHienTai].Diem;
                firstButtonName = "no";
                StartCoroutine(CheckMatch());
                return;
            }
            //Ô hình, mở hình
            firstButtonName = sprites[firstIndex].name;
            ListBtn[firstIndex].image.sprite = sprites[firstIndex];
            Debug.Log("list index: " + firstIndex + "1 name " + firstButtonName);
        }
        else
        {
            if (!secondButtonClick)//kiểm tra lần chọn thứ 2, không cho chọn nhiều ô liên tục
            {
                secondButtonClick = true;//Xác nhận hình thứ 2 đã được bấm
                secondIndex = int.Parse(EventSystem.current.currentSelectedGameObject.name);
                if (sprites[secondIndex] == null)//Ô trống, xóa ô trống
                {
                    gameAudio.PlayOneShot(congthoigianAudio);
                    ListBtn[secondIndex].interactable = false;
                    ListBtn[secondIndex].image.color = new Color(0, 0, 0, 0);
                    time += 5;
                    numMatch++; 
                    Diem += lstManChoi[ManHienTai].Diem;
                    secondButtonClick = false;
                    return;
                }
                if (secondIndex != firstIndex)//2 ô khác nhau
                {
                    secondButtonName = sprites[secondIndex].name;
                    ListBtn[secondIndex].image.sprite = sprites[secondIndex];
                    Debug.Log("list index: " + secondIndex + "2 name " + secondButtonName);
                    StartCoroutine(CheckMatch());
                }
                else //chọn ô giống ô lần 1
                {
                    secondButtonClick = false;
                }
            }
        }
    }

    IEnumerator CheckMatch()
    {
        if (firstButtonName == "no")
        {
            if (numMatch == numWin)
            {
                Debug.Log("Win");
                StartNewLevel();
            }
        }
        if (firstIndex != secondIndex && firstButtonName.Equals(secondButtonName))
        {
            yield return new WaitForSeconds(timeDown);
            ListBtn[firstIndex].interactable = false;
            ListBtn[secondIndex].interactable = false;
            ListBtn[firstIndex].image.color = new Color(0, 0, 0, 0);
            ListBtn[secondIndex].image.color = new Color(0, 0, 0, 0);
            firstButtonClick = false;
            secondButtonClick = false;
            numMatch++;
            Diem += lstManChoi[ManHienTai].Diem;
            gameAudio.PlayOneShot(matchAudio);
            Debug.Log("Điểm: " + Diem);
            if (numMatch == numWin)
            {
                Debug.Log("Win");
                StartNewLevel();
            }
        }
        else if (firstIndex != secondIndex)
        {
            gameAudio.PlayOneShot(wrongAudio);
            Invoke("DownButton", timeDown);
        }
        else
        {
        }
    }
    void DownButton()
    {
        //úp hình lại
        ListBtn[firstIndex].image.sprite = background_image;
        ListBtn[secondIndex].image.sprite = background_image;
        firstButtonClick = false;
        secondButtonClick = false;
    }


}
