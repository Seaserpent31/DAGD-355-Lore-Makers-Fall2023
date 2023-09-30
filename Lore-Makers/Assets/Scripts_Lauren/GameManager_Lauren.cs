using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ==========[ GAME MANAGER ]==========

public class GameManager : MonoBehaviour
{
// ==========[ VARIABLES ]==========
    private PowerUp_Lauren phasing;
    private GameObject player;

    public bool isPhasing = false; // Whether the player is currently phasing or not.
        // While phasing, the player should NOT be able to do the following:
            // Be detected by enemies (specifically the Bombers - they shouldn't continue to follow the player).
            // Pick up other Power-Ups (maybe?).
            // Shoot bullets (maybe?).
    public float phaseTime = 7f; // How long the player will be phasing for.

// ==========[ START ]==========
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    } // End of Start.

// ==========[ UPDATE ]==========
    void Update()
    {
        if(isPhasing)
        {
            // Counting down the phase time.
            phaseTime -= Time.deltaTime;

            if (phaseTime <= 0f)
            {
                // Once the timer reaches zero, it should reset and the player should be visible and able to collide with things again.
                Debug.Log("Phased back in.");

                isPhasing = false;

                player.GetComponent<Renderer>().enabled = true;
                player.GetComponent<Collider2D>().enabled = true;

                phaseTime = 7f;
            }
        }

    } // End of Update.

} // End of Game Manager.
