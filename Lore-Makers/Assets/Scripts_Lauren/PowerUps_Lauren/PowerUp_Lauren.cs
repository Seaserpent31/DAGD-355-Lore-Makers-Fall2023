using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

// // ==========[ POWER UP ]==========

public class PowerUp_Lauren : MonoBehaviour
{
    // ==========[ VARIABLES ]==========
    public PowerUpEffects_Lauren powerUpEffects;
    private GameObject player;

    private float detectionRadius = 0.5f; // So we can find the player.

    public float phaseTime = 2f; // How long the player will be phasing for.
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
                Debug.Log("Collided with Power-Up.");

                // Counting down the phase time.
                phaseTime -= Time.deltaTime;

                if (phaseTime <= 0f)
                {
                    // Once the timer reaches zero, it should reset and the player should be visible and able to collide with things again.
                    Debug.Log("Phasing back in.");

                    player.GetComponent<Renderer>().enabled = true;
                    player.GetComponent<Collider2D>().enabled = true;

                    phaseTime = 2f;
                }

                player.GetComponent<Renderer>().enabled = false;
                player.GetComponent<Collider2D>().enabled = false;

                Destroy(gameObject);
            }
        }

    } // End of Update.

} // End of Power Up.
