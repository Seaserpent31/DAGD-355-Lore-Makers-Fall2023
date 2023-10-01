using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

// ==========[ BULLET COLLISION ]==========
// To-Do:
    // everything :')

public class BulletCollision_Lauren : MonoBehaviour
{
// ==========[ VARIABLES ]==========
    // private GameObject enemy;
    // private BulletsScript_Lauren bullets;

    // public ParticleSystem particles;
    // List<ParticleCollisionEvent> collisionEvents;

    // public LayerMask enemyLayer;

    // [SerializeField] private Vector2 raycastRadius = Vector2.one;
    // [SerializeField] private float raycastDistance = 1f;

    // public new ParticleSystem particleSystem;
    // public ParticleCollisionEvent[] collisionEvents;

    // ==========[ START ]==========
    void Start()
    {
        // enemy = GameObject.FindGameObjectWithTag("Enemy");

        // particles = GetComponent<ParticleSystem>();
        // collisionEvents = new List<ParticleCollisionEvent>();

        // particleSystem = GetComponent<ParticleSystem>();
        // collisionEvents = new ParticleCollisionEvent[10000];

    } // End of Start.

// ==========[ UPDATE ]==========
    void Update()
    {
      /*  Vector2 raycastStartPoint = transform.position;
        RaycastHit2D[] hits = Physics2D.RaycastAll(raycastStartPoint, raycastRadius, raycastDistance);

        Debug.DrawRay(raycastStartPoint, raycastRadius * raycastDistance, Color.white);

        // Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        // Making sure the raycast can hit multiple targets.
        foreach (RaycastHit2D hit in hits)
        {
            GameObject hitObject = hit.collider.gameObject;

            // If the object hit has the "Enemy" tag, it should be destroyed.
            if (hitObject.CompareTag("Enemy"))
            {
                Debug.Log("Hit an enemy" + hitObject.name);

                hitObject.GetComponent<EnemyMovement_Lauren>().TakeDamage(10);
            } */
        //}

        // List<ParticleCollisionEvent> collisionEvents = new List<ParticleCollisionEvent>();

        // int numCollisions = ParticlePhysicsExtensions.GetCollisionEvents(particleSystem, gameObject, collisionEvents);

        // for (int i = 0; i < numCollisions; i++)
        // {
            // Access collision information for each event.
        //     ParticleCollisionEvent collision = collisionEvents[i];
        //     Vector3 collisionPoint = collision.intersection;
        //     Vector3 collisionNormal = collision.normal;

            // Handle the collision (e.g., spawn effects, apply forces, etc.).
            // You can add your custom logic here.
            // Debug.Log("Hit an enemy");
        // }

    } // End of Update.

    private void OnParticleCollision(GameObject other)
    {
        // https://docs.unity3d.com/530/Documentation/ScriptReference/MonoBehaviour.OnParticleCollision.html
        // https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnParticleCollision.html
        // https://docs.unity3d.com/530/Documentation/ScriptReference/ParticlePhysicsExtensions.GetCollisionEvents.html

        // Debug.Log("Hit an enemy");

        // int numCollisionEvents = particles.GetCollisionEvents(other, collisionEvents);

        // other = GameObject.FindGameObjectWithTag("Test");
        // Rigidbody rb = other.GetComponent<Rigidbody>();
        // int i = 0;

        // while (i < numCollisionEvents)
        // {
        //     if (other)
        //     {
        //         Debug.Log("Hit an enemy");
        //     }
        //     i++;
        // }

        // Rigidbody body = other.GetComponent<Rigidbody>();
        // if (other.CompareTag("Test"))
        // {
        // Debug.Log("Hit an enemy");
        // }

        // int safeLength = particleSystem.GetSafeCollisionEventSize();
        // if (collisionEvents.Length < safeLength)
        //     collisionEvents = new ParticleCollisionEvent[safeLength];

        // int numCollisionEvents = particleSystem.GetCollisionEvents(other, collisionEvents);
        // Rigidbody rb = other.GetComponent<Rigidbody>();
        // int i = 0;
        // while (i < numCollisionEvents)
        // {
        //     if (other)
        //     {
        //         Debug.Log("Hit an enemy");
        //     }
        //     i++;
        // }

    }

} // End of Bullet Collision.
