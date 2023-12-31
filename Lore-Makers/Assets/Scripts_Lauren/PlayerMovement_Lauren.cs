using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using static UnityEngine.UI.Image;

// ==========[ PLAYER MOVEMENT ]==========
// The Player is controlled with the mouse.
// To-Do:
    // Disable enemy collision when the player is phasing out (Power-Up).
    // Use the better movement code that Lawrence provided.

public class PlayerMovement_Lauren : MonoBehaviour
{
// ==========[ VARIABLES ]==========
    // Other References.
    public GameManager gameManager;  
    private GameObject enemy;
    
    // private Rigidbody2D rb;

    // Animation.
    public Animator animator;

    // Health.
    // public float playerHealth = 100f;

// ==========[ START ]==========
    void Start()
    {
        // rb = GetComponent<Rigidbody2D>();

        enemy = GameObject.FindGameObjectWithTag("Enemy"); // Finding the Enemy object.
        gameManager = GameManager.FindAnyObjectByType<GameManager>();

    } // End of Start.

// ==========[ UPDATE ]==========
    void Update()
    {
        // Mouse movement.
        /* Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(cursorPosition.x, cursorPosition.y);

        // Getting the mouse's X and Y.
        float vertical = Input.GetAxis("Mouse Y");
        float horizontal = Input.GetAxis("Mouse X"); */

        // Phasing.
        if (gameManager.isPhasing)
        {
            animator.SetBool("isPhasing", true);
        }
        else if(!gameManager.isPhasing)
        {
            animator.SetBool("isPhasing", false);
        }

    } // End of Update.

// ==========[ OTHER FUNCTIONS ]==========
    // OnCollisionEnter2D() - Collision with enemies.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
       {
            Debug.Log("Enemy Collision with Player.");
    
            Destroy(collision.gameObject);

            gameObject.GetComponent<Script_Player_Lawrence>().TakeDamage(10);
            // To-Do:
                // If enemies are in the process of dying, they should not be able to continue moving or taking damage.

        }
   
     } // End of OnCollisonEnter2D.

    // TakeDamage() - Taking damage.
    // public void TakeDamage(float damage)
    // {
    //     playerHealth -= damage;
    //     if (playerHealth <= 0f)
    //     {
    //         // Game is over.
    //         Debug.Log("Game Over.");

    //         animator.SetTrigger("destroy");

    //     }

   //  } // End of TakeDamage().

    // Kill() - "Killing" the player.
    // public void Kill()
    // {
     //    Destroy(gameObject);

    // } // End of Kill().

} // End of Player Movement.
