using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    private float _myTime;
    private float _bestTime;
    private GUIStyle _guiStyle;
    
    public BallMovement ballMovement;
    public GameObject winPanel;
    public GameObject losePanel;
    public TMP_Text myTimeResult;

    void Start()
    {
        _guiStyle = new GUIStyle();
        _guiStyle.fontSize = 48;
        _bestTime = PlayerPrefs.GetFloat("BestTime");

        losePanel.SetActive(false);
        winPanel.SetActive(false);
    }

  
    void Update()
    {
        if (ballMovement.isGame)
        {
            _myTime += Time.deltaTime;
        }
    }


    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
   

    private void OnGUI()
    {
        GUI.Label(new Rect(30,30,100,100),"Время игры: " + _myTime.ToString("0.00"), _guiStyle);
    }


    public void LoadWinPanel()
    {
        ballMovement.isGame = false;
        winPanel.SetActive(true);
        myTimeResult.text = _myTime.ToString("0.00");
        SaveMyTime();
    }


    public void LoadLosePanel()
    {
        ballMovement.isGame = false;
        losePanel.SetActive(true);
    }


    private void SaveMyTime()
    {
        if (_bestTime > _myTime || _bestTime == 0)
        {
          PlayerPrefs.SetFloat("BestTime", _myTime);
        }
    }
}
