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
    // Make sure power-ups actually spawn instead of just placing prefabs.
    // Switch collision to the regular kind, since I finally figured out what was wrong.
    // Make a timer appear on screen counting down the seconds.

public class PowerUp_Lauren : MonoBehaviour
{
// ==========[ VARIABLES ]==========
    // Other References.
    private GameManager gameManager;
    private GameObject player;

    // Audio.
    public AudioManager_Lauren audioManager;
    [SerializeField] private AudioClip phasing;

    // ==========[ START ]==========
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); // Finding the Player.
        gameManager = GameManager.FindAnyObjectByType<GameManager>();

        audioManager = AudioManager_Lauren.FindAnyObjectByType<AudioManager_Lauren>();

    } // End of Start.

// ==========[ UPDATE ]==========
    private void Update()
    {
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, Vector2.one * 0.5f, 0f, transform.right, 0f);

        if (hit.collider.CompareTag("Player"))
        {
            audioManager.Play(phasing);  

            Debug.Log("Phasing out.");
              gameManager.isPhasing = true;
        
              // Disable collision and player's render.
              player.GetComponent<Collider2D>().enabled = false;

              // Destroy the Power-Up.
              Destroy(gameObject);
        }

        // Completely forgot that I never fixed the collision for these.

    } // End of Update.

} // End of Power Up.
