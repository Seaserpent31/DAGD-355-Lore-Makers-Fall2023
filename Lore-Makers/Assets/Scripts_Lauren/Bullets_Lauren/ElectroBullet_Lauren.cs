using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Help with creating a "chain" from: https://youtu.be/TtfXvaRxsAM?si=fVf1p2MGeEgICpnG

// ==========[ ELECTRO BULLET ]==========
// Electro Bullets:
    // Shoots at a normal speed in a pattern.
    // Deals normal amount of damage, but at multiple targets that were near each other.
    // IDEA - Make the bullets stun enemies?
    // To-Do:
        // (if yes for the idea) Make the enemies get stunned for a few seconds.
        // Visualize the bullet shooting every enemy (make lifetimeloss 0 and do everything necessary).

    // Damage (in a hypothetical case):
        // Enemy has 50 health.
        // Bullet does around 10-12 damage per enemy.

public class ElectroBullet_Lauren : MonoBehaviour
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

    public LayerMask layerMask;

    public ParticleSystem system;
    // private ParticleSystemRenderer render;

    private GameManager gameManager;

    private void Awake()
    {
        Summon();
    }

    private void FixedUpdate()
    {
        // Spinning the particles/bullets.
        time += Time.fixedDeltaTime;

        transform.rotation = Quaternion.Euler(0, 0, time * spin);

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
        InvokeRepeating("DoEmit", 0f, firerate);

    } // End of Summon.

    // DoEmit() - Emit the particles (bullets).
    void DoEmit()
    {
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
                system.Emit(emitParams, 10);

                // Detect all enemies in a certain radius.
                Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 3f, layerMask);

                // For each enemy detected, deal damage.
                foreach (Collider2D collider in colliders)
                {
                    // Check if the detected object has an enemy script/component.
                    EnemyMovement_Lauren enemy = collider.GetComponent<EnemyMovement_Lauren>();

                    if (enemy != null)
                    {
                        enemy.TakeDamage(1);
                        Debug.Log("Electro.");
                    }
                }
            }
        }
    }

} // End of Electro Bullet.
