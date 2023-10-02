using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

// Help with particle systems from: https://www.youtube.com/watch?v=46TqkhJu7uA&t=510s.
// Help with finding the closest enemy from: https://youtu.be/YLE3v8bBnck?si=Rq3ejV5F-IyWFLhv

// ==========[ SNIPER BULLET ]==========
// Sniper Bullet:
    // Shoots one bullet at a time that go to the closest enemy.
    // Deals a lot of damage to enemies.
    // To-Do:
        // Change how much damage gets dealt.
        // If the player moves fast, bullets may miss.
            // (can't really control, but should probably compensate by adding a faster firerate?).

    // Damage (in a hypothetical case):
        // Enemy has 50 health.
        // Bullet does around 20-25 damage.

public class SniperBullet_Lauren : MonoBehaviour
{
// ==========[ VARIABLES ]==========
    public int numColumns; // How many bullets I want fired out at a time.
    public float speed; // How fast I want the bullets to travel.
    public Sprite texture; // The particle's texture/sprite.
    public Color color; // Color of the bullets.
    public float lifetime; // How long the bullets stay "alive" for.
    public float firerate; // How fast bullets get fired.
    public float size; // The size of the bullets.
    private float angle; // Angle at which the bullets travel, depending on the columns.
    public Material material; // Particle's material.
    public float spin; // Rotating the bullets into a pattern.
    public float time;
    public float damage;

    public LayerMask layerMask;

    public ParticleSystem system;
    // private ParticleSystemRenderer render;

    private GameManager gameManager;
    private GameObject closestEnemy;

    private void Awake()
    {
        Summon();
    }

    private void FixedUpdate()
    {
        // Spinning the particles/bullets.
        time += Time.fixedDeltaTime;

        transform.rotation = Quaternion.Euler(0, 0, time * spin);

        damage = Random.Range(20f, 25f);

    }

// ==========[ SUMMON (START) ]==========
    void Summon()
    {
        gameManager = GameManager.FindAnyObjectByType<GameManager>();

        angle = 360f / numColumns;

        for (int i = 0; i < numColumns; i++)
        {
            // Simple particle material.
            Material particleMaterial = material;

            // Simple particle system (not where we are emitting particles).
            var go = new GameObject("Particle System");
            go.transform.Rotate(angle * i, 90, 0);
            go.transform.parent = this.transform;
            go.transform.position = this.transform.position;
            system = go.AddComponent<ParticleSystem>();
            go.GetComponent<ParticleSystemRenderer>().material = particleMaterial;

            var mainModule = system.main;
            mainModule.startColor = Color.green;
            mainModule.startSize = 0.5f;
            mainModule.startSpeed = speed;
            mainModule.maxParticles = 10000;
            // mainModule.duration = 0f;
            mainModule.simulationSpace = ParticleSystemSimulationSpace.World;

            // var renderModule = render;
            // render.renderMode = ParticleSystemRenderMode.Stretch;
            // render.lengthScale = 1f;

            // Turning the particle system's emissons off.
            var emission = system.emission;
            emission.enabled = false;

            // Changing the "shape" to a Sprite.
            var shape = system.shape;
            shape.enabled = true;
            shape.shapeType = ParticleSystemShapeType.Sprite;
            shape.sprite = null;
            // shape.alignToDirection = false;

            // Adding the "texture."
            var text = system.textureSheetAnimation;
            text.mode = ParticleSystemAnimationMode.Sprites;
            text.AddSprite(texture);
            text.enabled = true;

            // Collision.
            var collision = system.collision;
            collision.type = ParticleSystemCollisionType.World;
            collision.mode = ParticleSystemCollisionMode.Collision2D;
            collision.lifetimeLoss = 1;
            collision.collidesWith = layerMask;
            collision.sendCollisionMessages = true;
            collision.enabled = true;
        }

        // Firing the bullets. Keep OUTSIDE of the loop.
        InvokeRepeating("FindShootEnemy", 0f, firerate);

    } // End of Summon.

    // FindShootEnemy() - Finds the closest enemy and starts shooting at them.
    void FindShootEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closestEnemy = null;

        float closestDis = Mathf.Infinity;

        // For each enemy, find the distance of each to figure out which one is closest to the player.
        foreach (GameObject enemy in enemies)
        {
            float disToEnemy = (enemy.transform.position - this.transform.position).sqrMagnitude;
            if (disToEnemy < closestDis)
            {
                closestDis = disToEnemy;
                closestEnemy = enemy;
            }
        }

        // If there are no more enemies on screen, stop looking for the closest distance.
        if (enemies.Length == 0)
        {
            return;
        }

        // If there is an enemy on screen, shoot at the closeset one.
        if (closestEnemy != null)
        {
            // Find the direction of the enemy.
            Vector3 directionToEnemy = (closestEnemy.transform.position - transform.position).normalized;

            // Emit particles towards that enemy's direction.
            foreach (Transform child in transform)
            {
                system = child.GetComponent<ParticleSystem>();

                // emitParams will override the current system's when called.
                // We can change this in Unity.
                var emitParams = new ParticleSystem.EmitParams();
                emitParams.startColor = color;
                emitParams.startSize = size;
                emitParams.startLifetime = lifetime;

                // When phasing, we don't want the player to fire bullets.
                if (!gameManager.isPhasing)
                {
                    // Emit particles towards the enemy.
                    emitParams.velocity = directionToEnemy * speed;
                    system.Emit(emitParams, 1);
                }
            }

            // Draw a line so we can see which enemy is closest (and to see if it worked).
            Debug.DrawLine(transform.position, closestEnemy.transform.position);
        }
    } // End of FindShootEnemy().

} // End of Bullet Script.