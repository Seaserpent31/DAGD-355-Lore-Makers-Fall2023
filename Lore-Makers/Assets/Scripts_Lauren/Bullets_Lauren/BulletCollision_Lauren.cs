using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ==========[ BULLET COLLISION ]==========
// To-Do:
    // everything :')

public class BulletCollision_Lauren : MonoBehaviour
{
// ==========[ VARIABLES ]==========
    private GameObject enemy;
    private BulletsScript_Lauren bullets;
    public ParticleSystem particles;

    public LayerMask enemyLayer;

   // [SerializeField] private Vector2 raycastRadius = Vector2.one;
   // [SerializeField] private float raycastDistance = 1f;

// ==========[ START ]==========
    void Start()
    {
        //enemy = GameObject.FindGameObjectWithTag("Enemy");
        particles = GetComponent<ParticleSystem>();

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

    } // End of Update.

    private void OnParticleCollision(GameObject other)
    {
        // https://docs.unity3d.com/530/Documentation/ScriptReference/MonoBehaviour.OnParticleCollision.html
        // https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnParticleCollision.html

        //EnemyMovement_Lauren enemy = other.GetComponent<EnemyMovement_Lauren>();
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");

        // Rigidbody rb = other.GetComponent<Rigidbody>();

        if (enemy)
        {
            Debug.Log("Hit an enemy");
        }
    }

} // End of Bullet Collision.
