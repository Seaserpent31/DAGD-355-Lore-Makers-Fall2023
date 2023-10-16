using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_PauseMenu_Lawrence : MonoBehaviour
{
    public AudioClip buttonSound;
    static AudioSource audioSrc;

    public GameObject controlsScreen;

    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResumeButton()
    {
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }

    public void QuitButton()
    {
        SceneManager.LoadScene("MainMenu_Lawrence");
    }

    public void ButtonNoiseFunc()
    {
        audioSrc.PlayOneShot(buttonSound);
    }

    public void ControlsButton()
    {
        controlsScreen.SetActive(true);
    }
}
