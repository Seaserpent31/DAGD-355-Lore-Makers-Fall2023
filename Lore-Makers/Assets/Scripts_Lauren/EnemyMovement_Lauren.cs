using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// EnemyMovement.
// Enemy: Bomber.
    // This enemy follows player movements.
    // They do not shoot at the player, however they carry a bomb.
    // If they reach the player or are in range of the player when they're "killed," they deal damage to the player.
// To-Do:
    // Add the "explosion" and make sure it deals damage to the player.
    // Make sure the collision with the bullets works before we do the first one.

public class EnemyMovement_Lauren : MonoBehaviour
{
    // ========== VARIABLES ==========
    private GameObject player; // For finding the player's location.
    public float speed;

    private float dis;

    // private Rigidbody2D rb;

    void Start()
    {
        // rb = GetComponent<Rigidbody2D>();

        // Instead of plugging the "Player" in into Unity, this was added so I could make the Enemy prefab work.
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        // Finding the player's location.
        dis = Vector2.Distance(transform.position, player.transform.position);
        Vector2 dir = player.transform.position - transform.forward;
        dir.Normalize();
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        // Moving and rotating so the enemy faces the player.
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);
    }

    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        Destroy(gameObject);
    //    }
    // }
}
