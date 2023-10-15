using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage_Lauren : MonoBehaviour
{
    public GameObject enemy;
    // public EnemyMovement_Lauren enemyDamage;

    public LayerMask enemyLayer;

    // Bullet Type
    public static int currentType = 0;
    public int bulletType;
    // 0 - Bullet
    // 1 - Electro
    // 2 - Poison Dart
    // 3 - Rocket
    // 4 - Sniper
    // 5 - Speedy

    public float damage;
    // Bullet: 10 - 12 damage
    // Electro: 10 - 12 damage
    // Poison Dart: 7 - 10 damage
    // Rocket: 28 - 32 damage
    // Sniper: 20 - 25 damage
    // Speedy: 5 - 7 damage

    // Poison Dart
    private float poisonTimer; // Timer for dealing damage.
    private float poisonDamage;

    // Rocket
    public float radius = 3f;

    void Start()
    {
        // bullet = GameObject.FindGameObjectWithTag("Bullet");

    }

    void Update()
    {
       
        
    }

    // ChangeType() - Changing the bullet type.
    public void ChangeType(int newType)
    {
        currentType = newType;
    }
    
    // RegularEffect() - Regular bullets. Doesn't do anything special, deals a normal amount of damage.
    public void RegularEffect(float damage)
    {
        EnemyMovement_Lauren enemy = GetComponent<EnemyMovement_Lauren>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Debug.Log("Bullet. Damage dealt: " + damage);

        }

    } // End of RegularEffect().

    // ElectroEffect() - Like regular bullets, but deal damage to multiple enemies in range.
    public void ElectroEffect(float damage)
    {
        // damage = Random.Range(10f, 12f);
        
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 3f, enemyLayer);

        // For each enemy detected, deal damage.
        foreach (Collider2D collider in colliders)
        {
            // Check if the detected object has an enemy script/component.
            EnemyMovement_Lauren enemy = collider.GetComponent<EnemyMovement_Lauren>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                Debug.Log("Electro bullet. Damage dealt: " + damage);

            }

        }

        // To-Do: Possibly add a visual effect to show the enemies affected by bullets.

    } // End of ElectroEffect().

    // PoisonEffect() - Deals a little less damage than regular bullets, but deals extra damage over time.
    public void PoisonEffect(float damage)
    {
        EnemyMovement_Lauren enemy = GetComponent<EnemyMovement_Lauren>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Debug.Log("Poison bullet. Damage dealt: " + damage);

        }

        // damage = Random.Range(7f, 10f);
        poisonDamage = Random.Range(1f, 3f);
        poisonTimer = 5f;

        poisonTimer -= Time.deltaTime;
        if (poisonTimer >= 0)
        {
            damage += poisonDamage * Time.deltaTime;
            Debug.Log("Additional damage: " + poisonDamage);
        }
        else
        {
            poisonTimer = 5f;
        }

        // Damage over time doesn't currently work, need to fix.

    } // End of PoisonEffect().

    // RocketEffect() - Deals a lot of damage to enemies. Similar to the bomb that Bombers drop upon death.
    public void RocketEffect(float damage)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                EnemyMovement_Lauren enemy = collider.GetComponent<EnemyMovement_Lauren>();

                if (enemy != null)
                {
                    // The closest the enemy is to the explosion, the more damage should be dealt.
                    var closestPoint = collider.ClosestPoint(transform.position);
                    var distance = Vector3.Distance(closestPoint, transform.position);

                    // Deal damage depending on how close the enemy is.
                    var damagePercent = Mathf.InverseLerp(radius, 0, distance);
                    int calculatedDamage = (int)(damagePercent * damage);

                    enemy.TakeDamage(calculatedDamage);
                    Debug.Log("Rocket. Damage Dealt: " + calculatedDamage);
                }

                // To-Do: Make the enemies explode after they DIE, not after they get shot.
            }
        }

    } // End of RocketEffect().

    // SniperEffect() - Does nothing special, just deals a lot of damage.
    public void SniperEffect(float damage)
    {
        EnemyMovement_Lauren enemy = GetComponent<EnemyMovement_Lauren>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Debug.Log("Sniper Bullet. Damage dealt: " + damage);

        }

    } // End of SniperEffect().

    // SpeedyEffect() - Deals the least amount of damage, but makes up for it with amount of bullets fired at a time.
    public void SpeedyEffect(float damage)
    {
        EnemyMovement_Lauren enemy = GetComponent<EnemyMovement_Lauren>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Debug.Log("Speedy Bullet. Damage dealt: " + damage);

        }

    } // End of SpeedyEffect().

}
