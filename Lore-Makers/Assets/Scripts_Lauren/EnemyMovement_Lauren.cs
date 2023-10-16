using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ==========[ ENEMY MOVEMENT ]==========
// Enemy: Bomber.
    // This enemy follows player movements.
    // They do not shoot at the player, however they carry a bomb.
    // If they reach the player or are in range of the player when they're "killed," they deal damage to the player.
// To-Do:
    // Fix enemy rotation - it doesn't "rotate fast enough" to face the player.
    // Make it to where the enemies roam randomly until the player phases back into existence.
    // Make sure enemies actually spawn instead of just placing prefabs.

public class EnemyMovement_Lauren : MonoBehaviour
{
    // ==========[ VARIABLES ]==========
    // Other References.
    private GameManager gameManager; // For phasing and future things.

    private GameObject player; // For finding the player's location.
    public GameObject bomb; // Bomb prefab for when the enemy dies.
    public GameObject explosion; // Explosion effect.

    public LayerMask enemyLayer;

    private Rigidbody2D rb;

    // Animation.
    public Animator animator;

    // Audio.
    public AudioManager_Lauren audioManager;
    [SerializeField] private AudioClip clip;

    // Movement and Health.
    public float speed;
    public float enemyHealth = 50; // Enemy health, probably not 50 (just a placeholder).
    private float dis; // Used for finding the player's location.

// ==========[ START ]==========
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        gameManager = GameManager.FindAnyObjectByType<GameManager>();
        audioManager = AudioManager_Lauren.FindAnyObjectByType<AudioManager_Lauren>();

        player = GameObject.FindGameObjectWithTag("Player");

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
                // Commenting out for testing purposes. Remember to get rid of the // later.

        }

        // Instead, the enemies should find "new paths" until the player phases back in.

    } // End of Update.

// ==========[ OTHER FUNCTIONS ]==========
    // TakeDamage() - Taking damage.
    public void TakeDamage(float damage)
    {
        enemyHealth -= damage;
        // If the enemy reaches 0 health, they should "die."
        if (enemyHealth <= 0f)
        {
            animator.SetTrigger("destroy");

        }

    }

    // Kill() - "Killing" the enemy.
    public void Kill()
    {       
        Destroy(gameObject);

        // Bomb and Explosion.
        Instantiate(explosion, transform.position, Quaternion.identity);
        Instantiate(bomb, transform.position, Quaternion.identity);

        audioManager.Play(clip);
        audioManager.audioSource.volume = 0.25f;

        // I don't really like how the explosion particles go off after the animation is completely done, might have to fix.

        Debug.Log("Bomb deployed.");

    } // End of Kill().

    // OnCollisionEnter2D() - Collision with the bullets.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        BulletDamage_Lauren bullet = GetComponent<BulletDamage_Lauren>();
        int currentType = BulletDamage_Lauren.currentType;

        if (collision.gameObject.tag == "Bullet")
        {
            // Bullet types.
            if (currentType == 0) // Bullet.
            {
                bullet.RegularEffect(Random.Range(10f, 12f));
            }
            else if (currentType == 1) // Electro Bullet.
            {
                bullet.ElectroEffect(Random.Range(7f, 10f));
            }
            else if (currentType == 2) // Poison Dart.
            {
                bullet.PoisonEffect(Random.Range(10f, 12f));
            }
            else if (currentType == 3) // Rocket.
            {
                bullet.RocketEffect(Random.Range(28f, 32f));
            }
            else if (currentType == 4) // Sniper Bullet.
            {
                bullet.SniperEffect(Random.Range(20f, 25f));
            }
            else if (currentType == 5) // Speedy Bullet.
            {
                bullet.SpeedyEffect(Random.Range(5f, 7f));
            }

        }

    }// End of OnCollisionEnter2D().

} // End of Enemy Movement.
