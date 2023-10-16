using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound_Lauren
{
    // Audio help from:
    // https://youtu.be/6OT43pvUyfY?si=csZj34r6NSuSwfEu

    public string name;

    public AudioClip clip;

    [HideInInspector]
    public AudioSource source;

    [Range(0f, 1f)]
    public float volume;

    [Range(0.1f, 0.3f)]
    public float pitch;

}
