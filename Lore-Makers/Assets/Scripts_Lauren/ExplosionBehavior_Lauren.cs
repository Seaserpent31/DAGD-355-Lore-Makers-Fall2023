using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

// Help with creating "Splash Damage" from: https://youtu.be/6YvEDbBjgAY?si=91v3FH2A8INLt43j.

// ==========[ EXPLOSION BEHAVIOR ]==========
// When the Bomber enemy is "killed" or reaches the player, they explode, dealing damage.
// The bomb is not meant to move, when the Bomber is destroyed, the bomb goes off where the Bomber was.

public class ExplosionBehavior_Lauren : MonoBehaviour
{
// ==========[ VARIABLES ]==========
    // Other References.
    private PlayerMovement_Lauren player;

    // Damage.
    public float damage = 1f;
    public float radius = 3f; // Range for splash damage.

// ==========[ START ]==========
    void Start()
    {
        // We want the bomb to immediately explode after it is instantiated.
        Invoke("Explode", 0f);

    } // End of Start.

// ==========[ UPDATE ]==========
    void Update()
    {
        

    } // End of Update.

// ==========[ OTHER FUNCTIONS ]==========
    // Explode() - For the bomb's explosion.
    void Explode()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);
        // var colliders = Physics2D.OverlapCircleAll(transform.position, radius);

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                PlayerMovement_Lauren player = collider.GetComponent<PlayerMovement_Lauren>();
                if (player != null)
                {
                    // The closest the player is to the bomb, the more damage should be dealt.
                    var closestPoint = collider.ClosestPoint(transform.position);
                    var distance = Vector3.Distance(closestPoint, transform.position);

                    // Deal damage depending on how close the player is.
                    var damagePercent = Mathf.InverseLerp(radius, 0, distance);
                    int calculatedDamage = (int)(damagePercent * 10 * damage);

                    // Dea damage.
                    player.TakeDamage(calculatedDamage);
                    Debug.Log(calculatedDamage);
                    Debug.Log("Damage taken. Remaining health: " + player.playerHealth);
                }

            }

        }

        // Destroy the bomb.
        Destroy(gameObject);
        Debug.Log("Bomb exploded");

    } // End of Explode().

} // End of Explosion Bheavior.
