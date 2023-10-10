using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ==========[ GAME MANAGER ]==========
// To-Do:
    // Bullets:
        // Figure out how we want different weapon types to be unlocked and used.
            // Should they be unlocked as the player progresses (like the amount of waves they complete)?
            // Should weapon types be switchable by pressing a key or scrolling with the middle mouse button?
        // Make the bullets deal certain amounts of damage.
            // Each bullet type has a different amount of damage that can be done.
            // More information shown in each script.
    // Power-Ups:
        // Visuals:
            // Add a timer that appears on the screen (thinking towards the bottom of the screen in the middle) that counts down.
            // Make the player slightly visible (but still invincible and undetectable by enemies).
        // Figure out how we want the power-ups to spawn.
            // Show up randomly across the screen, or will they drop from enemies?
        // Figure out how the power-up will be used.
            // Will it be used upon pickup, or will the player have to press a key (space bar)?
    // Enemies:
        // Add an explosion when the enemies die to show that the bomb went off.
        // Actually spawn the enemies instead of throwing random ones in the scene.

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

                // player.GetComponent<Renderer>().enabled = true;
                player.GetComponent<Collider2D>().enabled = true;

                phaseTime = 7f;
            }
        }

    } // End of Update.

} // End of Game Manager.
