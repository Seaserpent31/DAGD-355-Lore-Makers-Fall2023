using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager_Lauren : MonoBehaviour
{
    // Audio help from:
    // https://youtu.be/6OT43pvUyfY?si=csZj34r6NSuSwfEu
    // https://youtu.be/tEsuLTpz_DU?si=S7gOn5Bmo7GIWcg0

    // public Sound_Lauren[] sounds;

    public AudioSource audioSource;

    public static AudioManager_Lauren instance;

    private void Awake()
    {        
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        
        /* foreach (Sound_Lauren sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;

            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
        } */
    }

    public void Play (AudioClip clip) // 'string name' for first method
    {
        // Sound_Lauren s = Array.Find(sounds, sound => sound.name == name);
        // s.source.Play();

        audioSource.PlayOneShot(clip);
    }

    public void Stop (AudioClip clip)
    {
        // Sound_Lauren s = Array.Find(sounds, sound => sound.name == name);
        // s.source.Stop();

        audioSource.Stop();
    }

}
