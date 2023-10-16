using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_MainMenuUI_Lawrence : MonoBehaviour
{

    public GameObject controlsScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("Scene_Lawrence");
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void HowToPlayButton()
    {

        controlsScreen.SetActive(true);
    }
}
