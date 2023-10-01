using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

// ==========[ EXPLOSION BEHAVIOR ]==========
// When the Bomber enemy is "killed" or reaches the player, they explode, dealing damage.
// The bomb is not meant to move, when the Bomber is destroyed, the bomb goes off where the Bomber was.
// To-Do:
    // Everything.

public class ExplosionBehavior_Lauren : MonoBehaviour
{
    // ==========[ VARIABLES ]==========
    private PlayerMovement_Lauren player;
    // private GameObject bomb;
    
    // public bool hasExploded = false; // Whether the bomb has exploded or not.

    public float damage = 2f;
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
        // Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);
        var colliders = Physics2D.OverlapCircleAll(transform.position, radius);

        foreach (var collider in colliders)
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
                    int calculatedDamage = (int)(damagePercent * damage);

                    // Dea damage.
                    player.TakeDamage(calculatedDamage);
                    Debug.Log("Damage taken. Remaining health: " + player.playerHealth);
                }
            }
        }

        // Destroy the bomb.
        Destroy(gameObject);
        Debug.Log("Bomb exploded");
    }

} // End of Explosion Bheavior.
