using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_MainGameUI_Lawrence : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject pauseButton;

    public AudioClip buttonSound;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(pauseMenu != null)
        {
            if (pauseButton.activeInHierarchy == false && pauseMenu.activeInHierarchy == false)
            {
                pauseButton.SetActive(true);
            }
        }
    }

    public void PauseButton()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        pauseButton.SetActive(false);
    }

    public void ButtonNoiseFunc()
    {
        audioSrc.PlayOneShot(buttonSound);
    }
}
