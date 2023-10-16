using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_ButtonNoise_Lawrence : MonoBehaviour
{
    public AudioClip buttonSound;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ButtonNoiseFunc()
    {
        audioSrc = GetComponent<AudioSource>();
        audioSrc.PlayOneShot(buttonSound);
    }
}
