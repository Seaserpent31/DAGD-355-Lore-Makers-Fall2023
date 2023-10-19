using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

// ==========[ GAME MANAGER ]==========
// To-Do:
    // Bullets:
        // Figure out how we want different weapon types to be unlocked and used.
            // Should they be unlocked as the player progresses (like the amount of waves they complete)?
            // Should weapon types be switchable by pressing a key or scrolling with the middle mouse button?
    // Power-Ups:
        // Visuals:
            // Add a timer that appears on the screen (thinking towards the bottom of the screen in the middle) that counts down.
            // Add animation to Lawrence's animator.
        // Figure out how we want the power-ups to spawn.
            // Show up randomly across the screen, or will they drop from enemies?
    // Enemies:
        // Actually spawn the enemies instead of throwing random ones in the scene.

public class GameManager : MonoBehaviour
{
// ==========[ VARIABLES ]==========
    // Other References.
    private GameObject player;

    // Phasing.
    public bool isPhasing = false; // Whether the player is currently phasing or not.
        // While phasing, the player should NOT be able to do the following:
            // Be detected by enemies (specifically the Bombers - they shouldn't continue to follow the player).
            // Pick up other Power-Ups (maybe?).
            // Shoot bullets (maybe?).
    public float phaseTime = 8f; // How long the player will be phasing for.

    // Shooting.
    public bool isShooting = true;
        // I don't think I need this, but I'm keeping it for now just in case.

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
            // Once the timer reaches zero, it should reset and the player should be visible and able to collide with things again.
            if (phaseTime <= 0f)
            {
                print("Phased back in.");

                isPhasing = false;
                phaseTime = 8f;

                player.GetComponent<Collider2D>().enabled = true;
            }

        }

    } // End of Update.

} // End of Game Manager.
