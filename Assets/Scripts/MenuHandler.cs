using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuHandler : MonoBehaviour
{
    public static MenuHandler mainMenu;
    public static string directory = "/SaveData/";
    public static string fileName = "MyData.txt";
    public InputField usernameInput;
    public string playerName;
    public string highScorePlayerName;
    public Text displayHighscore;
    public int keepHighScore;
    // Start is called before the first frame update

    private void Awake()
    {
        if (mainMenu == null)
        {
            mainMenu = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }


    // Update is called once per frame
    void Update()
    {
        if (MainManager.Instance != null)
        {
            SetHighScore(MainManager.Instance.highScore);
        }
    }

    public void SetUsername()
    {
        playerName = usernameInput.text;

        SceneManager.LoadSceneAsync("main");
    }

    public void SetHighScore(int highscore)
    {
        if (highscore > keepHighScore)
        {
            keepHighScore = highscore;
            highScorePlayerName = playerName;
            PlayerPrefs.SetInt("HighScore", MenuHandler.mainMenu.keepHighScore);
            PlayerPrefs.SetString("Name", MenuHandler.mainMenu.highScorePlayerName);
            PlayerPrefs.GetInt("HighScore");
            PlayerPrefs.GetString("Name");
        }
    }

    public void UpdateHighScoreText()
    {
        MainManager.Instance.displayHighscore.text = $"HighScore: {PlayerPrefs.GetInt("HighScore", 0)} by: {PlayerPrefs.GetString("Name", default)}";
    }
}
