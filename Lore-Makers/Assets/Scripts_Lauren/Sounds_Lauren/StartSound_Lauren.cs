using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSound_Lauren : MonoBehaviour
{
    // Audio help from:
    // https://youtu.be/tEsuLTpz_DU?si=S7gOn5Bmo7GIWcg0

    [SerializeField] private AudioClip clip;

    private void Start()
    {
        AudioManager_Lauren.instance.Play(clip);
    }

}
