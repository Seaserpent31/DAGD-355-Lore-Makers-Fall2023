using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

// Help with creating "Splash Damage" from: https://youtu.be/6YvEDbBjgAY?si=91v3FH2A8INLt43j.

// ==========[ EXPLOSION BEHAVIOR ]==========
// When the Bomber enemy is "killed" or reaches the player, they explode, dealing damage.
// The bomb is not meant to move, when the Bomber is destroyed, the bomb goes off where the Bomber was.
// To-Do:
    // Change things with damage (works for now - up close, deals around 9 and deals less further away).
    // Add particles for when the bomb explodes.

public class ExplosionBehavior_Lauren : MonoBehaviour
{
// ==========[ VARIABLES ]==========
    private PlayerMovement_Lauren player;
    public ParticleSystem explosion;
    
    // public bool hasExploded = false; // Whether the bomb has exploded or not.

    public float damage = 1f;
    public float radius = 5f; // Range for splash damage.

// ==========[ START ]==========
    void Start()
    {
        // bomb = GameObject.FindGameObjectWithTag("Bomb");

        // Making the bomb explode immediately after it's instantiated.
        Invoke("Explode", 0f);

    } // End of Start.

// ==========[ UPDATE ]==========
    void Update()
    {
        

    } // End of Update.

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

        // Explosion effect.
        // Instantiate(explosion, transform.position, Quaternion.identity);

        // Destroy the bomb.
        Destroy(gameObject);
        Debug.Log("Bomb exploded");

    } // End of Explode().

} // End of Explosion Bheavior.
