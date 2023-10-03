using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

// ==========[ BULLET COLLISION ]==========
// Collision between bullets (particles) and enemies.

public class BulletCollision_Lauren : MonoBehaviour
{
// ==========[ VARIABLES ]==========
    private Rigidbody2D rb;

    private EnemyMovement_Lauren enemy;

    // ==========[ START ]==========
    void Start()
    {
        enemy = GetComponent<EnemyMovement_Lauren>();

        rb = GetComponent<Rigidbody2D>();

    } // End of Start.

// ==========[ UPDATE ]==========
    void Update()
    {


    } // End of Update.

    // OnParticleCollision() - For detecting collision between game objects with the tag "Enemy."
    private void OnParticleCollision(GameObject other)
    {
        // https://docs.unity3d.com/530/Documentation/ScriptReference/MonoBehaviour.OnParticleCollision.html
        // https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnParticleCollision.html
        // https://docs.unity3d.com/530/Documentation/ScriptReference/ParticlePhysicsExtensions.GetCollisionEvents.html

        other = GameObject.FindGameObjectWithTag("Enemy");

        if (other.tag == "Enemy")
        {
            // Deal damage.
            Debug.Log("Hit an enemy");
            Debug.Log(enemy.enemyHealth);
            enemy.TakeDamage(1);
        }
    }

} // End of Bullet Collision.
