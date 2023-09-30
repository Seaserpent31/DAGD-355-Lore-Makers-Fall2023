using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

// // ==========[ POWER UP ]==========
// Power-Up: Phasing.
    // Gives the player the ability to phase out and then back in after a certain amount of time.
    // To-Do:
        // Decide whether we want the Power-Up to be activated as soon as the player picks it up, or if it activates with a key.
        // Decide how we want the Power-Ups to spawn - randomly across the screen, or dropped by enemies.

public class PowerUp_Lauren : MonoBehaviour
{
    // ==========[ VARIABLES ]==========
    private GameManager gameManager;
    private GameObject player;

    private float detectionRadius = 0.5f; // So we can find the player.

    // public float alpha = 1f; // Instead of making the player completely invisible, I want them to be see-through.

    // private void OnTriggerEnter2D(Collider2D collision)
    // {
    //     Destroy(gameObject);
    //     Debug.Log("Collided with Power-Up.");
    //     powerUpEffects.Apply(collision.gameObject);
    // }

    // ==========[ START ]==========
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); // Finding the Player.
        gameManager = GameManager.FindAnyObjectByType<GameManager>();

    } // End of Start.

// ==========[ UPDATE ]==========
    private void Update()
    {
        // Still haven't figure out how to make it detectable with OnCollision/OnTriggerEnter2D, so using Raycasting again.
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, detectionRadius);

        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Player"))
            {
                Debug.Log("Phasing out.");
                gameManager.isPhasing = true;

                // Disable collision and player's render.
                player.GetComponent<Renderer>().enabled = false;
                player.GetComponent<Collider2D>().enabled = false;

                // Destroy the Power-Up.
                Destroy(gameObject);
            }
        }

    } // End of Update.

} // End of Power Up.
