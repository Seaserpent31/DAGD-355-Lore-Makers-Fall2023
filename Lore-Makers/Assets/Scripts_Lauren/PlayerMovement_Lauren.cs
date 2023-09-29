using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

// ==========[ PLAYER MOVEMENT ]==========

public class PlayerMovement_Lauren : MonoBehaviour
{
    // ==========[ VARIABLES ]==========
    // private Rigidbody2D rb;
    private GameObject enemy;

    // public float detectionRadius = 0.5f;
    // public LayerMask enemyLayer; // Since I gave my enemy the "Enemy" layer.

    private float detectionRadius = 0.5f; // So we can find the "things" (enemies) we're trying to detect.

// ==========[ START ]==========
    void Start()
    {
        // rb = GetComponent<Rigidbody2D>();
        enemy = GameObject.FindGameObjectWithTag("Enemy"); // Finding the Enemy object.

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
        Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(cursorPosition.x, cursorPosition.y);


        // Raycasting
        // For some reason, NOTHING I did for 2D collision was working, but after trying this, it worked.
        // (temporary solution, unless it works best?).
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, detectionRadius);

        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                Debug.Log("Enemy has collided.");
                Destroy(hit.collider.gameObject);
            }
        }

    } // End of Update.

    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.gameObject.tag == "Enemy")
    //     {
    //         Debug.Log("Enemy Collision.");
    //         Destroy(collision.gameObject);
    //     }
    //
    // }

} // End of Player Movement.
