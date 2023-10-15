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
    // Make sure enemies actually spawn instead of just placing prefabs.

public class EnemyMovement_Lauren : MonoBehaviour
{
    // ==========[ VARIABLES ]==========
    private GameManager gameManager;
    private GameObject player; // For finding the player's location.
    private GameObject bullet;

    private Rigidbody2D rb;

    public LayerMask enemyLayer;

    public Animator animator;

    public GameObject bomb;
    // private ExplosionBehavior_Lauren explosion;

    public float speed;

    public float enemyHealth = 10f;

    private float dis;

// ==========[ START ]==========
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        gameManager = GameManager.FindAnyObjectByType<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player");
        bullet = GameObject.FindGameObjectWithTag("Bullet");

        // bomb = GameObject.FindGameObjectWithTag("Test");
        // explosion = ExplosionBehavior_Lauren.FindAnyObjectByType<ExplosionBehavior_Lauren>();

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
            // transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            // transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }

        // Instead, the enemies should find "new paths" until the player phases back in.

    } // End of Update.

    public void TakeDamage(float damage)
    {
        enemyHealth -= damage;
        if (enemyHealth <= 0f)
        {
            animator.SetTrigger("destroy");
        }

    }

    private void OnDestroy()
    {
        // Instantiate the bomb.
        // Instantiate(bomb, transform.position, Quaternion.identity);
        Debug.Log("Bomb deployed.");

    }

    public void kill()
    {
        Destroy(gameObject);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        BulletDamage_Lauren bullet = GetComponent<BulletDamage_Lauren>();
        int currentType = BulletDamage_Lauren.currentType;

        if (collision.gameObject.tag == "Bullet")
        {
            if (currentType == 0) // Bullet
            {
                bullet.RegularEffect(Random.Range(10f, 12f));
            }
            else if (currentType == 1) // Electro Bullet
            {
                bullet.ElectroEffect(Random.Range(7f, 10f));
            }
            else if (currentType == 2) // Poison Dart
            {
                bullet.PoisonEffect(Random.Range(10f, 12f));
            }
            else if (currentType == 3) // Rocket
            {
                bullet.RocketEffect(Random.Range(28f, 32f));
            }
            else if (currentType == 4) // Sniper Bullet
            {
                bullet.SniperEffect(Random.Range(20f, 25f));
            }
            else if (currentType == 5) // Speedy Bullet
            {
                bullet.SpeedyEffect(Random.Range(5f, 7f));
            }

        }

    }

} // End of Enemy Movement.
