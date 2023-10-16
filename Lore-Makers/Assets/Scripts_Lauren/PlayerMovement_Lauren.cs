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
    private GameManager gameManager;  
    private GameObject enemy;
    
    private Rigidbody2D rb;

    // Animation.
    public Animator animator;

    // Health.
    public float playerHealth = 100f;

// ==========[ START ]==========
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        enemy = GameObject.FindGameObjectWithTag("Enemy"); // Finding the Enemy object.
        gameManager = GameManager.FindAnyObjectByType<GameManager>();

    } // End of Start.

// ==========[ UPDATE ]==========
    void Update()
    {
        // Mouse movement.
        Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(cursorPosition.x, cursorPosition.y);

        // Getting the mouse's X and Y.
        float vertical = Input.GetAxis("Mouse Y");
        float horizontal = Input.GetAxis("Mouse X");

        // If the 'vertical' is greater than 0, the ship is moving up.
        if (vertical > 0)
        {
            animator.SetBool("isUp", true);
        }
        // If the 'vertical' is less than 0, the ship is moving down.
        else if (vertical < 0)
        {
            animator.SetBool("isUp", false);
        }

        // To-Do:
        // Tilting the player as they move from side to side (same as above).

        if (horizontal > 0)
        {
            animator.SetBool("isRight", true);
            animator.SetBool("isLeft", false);
        }
        // If the 'vertical' is less than 0, the ship is moving down.
        else if (horizontal < 0)
        {
            animator.SetBool("isRight", false);
            animator.SetBool("isLeft", true);
        }
        else if (horizontal == 0)
        {
            animator.SetBool("isRight", false);
            animator.SetBool("isLeft", false);
        }

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
    
            Destroy(enemy);

            // To-Do:
                // If enemies are in the process of dying, they should not be able to continue moving or taking damage.

        }
   
    } // End of OnCollisonEnter2D.

    // TakeDamage() - Taking damage.
    public void TakeDamage(float damage)
    {
        playerHealth -= damage;
        if (playerHealth <= 0f)
        {
            // Game is over.
            Debug.Log("Game Over.");

            animator.SetTrigger("destroy");

        }

    } // End of TakeDamage().

    // Kill() - "Killing" the player.
    public void Kill()
    {
        Destroy(gameObject);

    } // End of Kill().

} // End of Player Movement.
