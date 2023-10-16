using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_GameOverMenu_Lawrence : MonoBehaviour
{
    GameObject manager;
    private int score;
    private int highScore=100;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("GameManager");
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        score = manager.GetComponent<GameManager_Lawrence>().score;
        if(score > highScore) {
         highScore = score;   
        }
        scoreText.text = "Score :" + score;
        highScoreText.text = "Highscore :" + highScore;
    }

    public void PlayAgainButton()
    {
        manager.GetComponent<GameManager_Lawrence>().StartGame();
        gameObject.SetActive(false);
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu_Lawrence");
    }

    public void quitButton()
    {
        Application.Quit();
    }
}
