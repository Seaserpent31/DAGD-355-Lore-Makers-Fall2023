using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerMovement_Lauren : MonoBehaviour
{
    // ========== VARIABLES ==========
    // private Rigidbody2D rb;
    private GameObject enemy;

    // public float detectionRadius = 0.5f;
    // public LayerMask enemyLayer;

    public float detectionDistance = 1.0f; // So we can find the "thing" we're trying to detect.

    void Start()
    {
        // rb = GetComponent<Rigidbody2D>();
        enemy = GameObject.FindGameObjectWithTag("Enemy"); // Finding the Enemy object.
    }

   // private void FixedUpdate()
   // {
   //     Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius, enemyLayer);
   //
   //     foreach (Collider2D collider in colliders)
   //     {
   //         // Handle the collision with the enemy here
   //        Debug.Log("Collision with enemy detected.");
   //         Destroy(collider.gameObject);
   //     }
   // }

    // Update is called once per frame
    void Update()
    {
        Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(cursorPosition.x, cursorPosition.y);


        // Raycasting
        // For some reason, NOTHING I did for 2D collision was working, but after trying this, it worked.
        // (temporary solution, unless it works best?).
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, detectionDistance);

        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                Debug.Log("Enemy has collided.");
                Destroy(hit.collider.gameObject);
            }
        }
    }

    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.gameObject.tag == "Enemy")
    //     {
    //         Debug.Log("Collision with Enemy detected.");
    //         Destroy(collision.gameObject);
    //     }
    // }

}
