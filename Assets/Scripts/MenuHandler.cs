using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour
{
    public static MenuHandler mainMenu;
    public InputField usernameInput;
    public string playerName;
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
        keepHighScore = highscore;
    }
}
