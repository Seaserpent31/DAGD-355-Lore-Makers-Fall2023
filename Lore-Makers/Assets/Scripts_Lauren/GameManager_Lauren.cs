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

        }

    } // End of Update.

} // End of Game Manager.
