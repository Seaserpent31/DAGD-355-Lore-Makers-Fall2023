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
    private Rigidbody2D rb;

    private GameObject enemy;
    private GameManager gameManager;

    private EnemyMovement_Lauren enemyMovement;

    public Animator animator;

    public float playerHealth = 100f;

    // public LayerMask layerMask; // Since I gave my enemy the "Enemy" layer.

    // private float detectionRadius = 1f; // So we can find the "things" (enemies) we're trying to detect.

// ==========[ START ]==========
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        enemy = GameObject.FindGameObjectWithTag("Enemy"); // Finding the Enemy object.
        gameManager = GameManager.FindAnyObjectByType<GameManager>();

    } // End of Start.

    // private void FixedUpdate()
    // {
    //     Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius, enemyLayer);
    //
    //     foreach (Collider2D collider in colliders)
    //     {
    //        Debug.Log("Enemy Collision.");
    //        Destroy(collider.gameObject);
    //     }
    // }

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

        // RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, detectionRadius);
        // Debug.DrawRay(transform.position, transform.right * detectionRadius, Color.white);

        // if (hit.collider != null)
        // {
        //   if (hit.collider.CompareTag("Enemy"))
        //   {
        //       Debug.Log("Collided with Enemy.");
        //       Destroy(hit.collider.gameObject);
        //   }
        // }

        // Raycasting
        // For some reason, NOTHING I did for 2D collision was working, but after trying this, it worked.
        // RaycastHit2D hit = Physics2D.BoxCast(transform.position, Vector2.one * 0.5f, 0f, transform.right, 0f, layerMask);

        // if(!gameManager.isPhasing)
        // {
        //     if (hit.collider != null)
        //     {
        //         GameObject enemy = hit.collider.gameObject;
        //         Debug.Log("Player collided with enemy: " + enemy.name);

        //         enemy.GetComponent<EnemyMovement_Lauren>().TakeDamage(10);
        //     }
        // }

    } // End of Update.

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy Collision.");

            enemyMovement.animator.SetTrigger("destroy");

            // To-Do:
                // If enemies are in the process of dying, they should not be able to continue moving or taking damage.
        }
   
    }

    public void TakeDamage(float damage)
    {
        playerHealth -= damage;
        if (playerHealth <= 0f)
        {
            // Game is over.
            Debug.Log("Game Over.");

            animator.SetTrigger("destroy");
        }
    }

    public void kill()
    {
        Destroy(gameObject);
    }

} // End of Player Movement.
