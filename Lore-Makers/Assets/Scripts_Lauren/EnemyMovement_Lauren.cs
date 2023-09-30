using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ==========[ ENEMY MOVEMENT ]==========
// Enemy: Bomber.
    // This enemy follows player movements.
    // They do not shoot at the player, however they carry a bomb.
    // If they reach the player or are in range of the player when they're "killed," they deal damage to the player.
// To-Do:
    // Add the "explosion" and make sure it deals damage to the player.
    // Make sure the collision with the bullets works before we do the first one.
    // Fix enemy rotation - it doesn't "rotate fast enough" to face the player.
    // When the player is phasing in and out, the enemies should NOT be able to detect the player.
        // Make it to where the enemies roam randomly until the player phases back into existence.

public class EnemyMovement_Lauren : MonoBehaviour
{
// ==========[ VARIABLES ]==========
    private GameObject player; // For finding the player's location.
    private GameManager gameManager;

    public float speed;

    [SerializeField] private int enemyHealth = 10;

    private float dis;

    private Rigidbody2D rb;

// ==========[ START ]==========
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Instead of plugging the "Player" in into Unity, this was added so I could make the Enemy prefab work.
        player = GameObject.FindGameObjectWithTag("Player");
        gameManager = GameManager.FindAnyObjectByType<GameManager>();

    } // End of Start.

// ==========[ UPDATE ]==========
    void Update()
    {
        // Finding the player's location.
        dis = Vector2.Distance(transform.position, player.transform.position);
        Vector2 dir = player.transform.position - transform.forward;
        dir.Normalize();
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        // If the player is phasing, the enemies should NOT continue following them.
        if(!gameManager.isPhasing)
        {
            // Moving and rotating so the enemy faces the player.
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }

        // Instead, the enemies should find "new paths" until the player phases back in.

    } // End of Update.

    public void TakeDamage(int damage)
    {
        enemyHealth -= damage;
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        Destroy(gameObject);
    //    }
    //
    // }

} // End of Enemy Movement.
