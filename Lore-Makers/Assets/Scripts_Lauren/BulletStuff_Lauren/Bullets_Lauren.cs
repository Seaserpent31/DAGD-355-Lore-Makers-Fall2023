using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Bullets_Lauren : MonoBehaviour
{
    // Help used from:
        // https://youtu.be/Mq2zYk5tW_E?si=iDfJ1_zxp0sC6NAJ.

    // Things to ask/consider:
        // Bullets will ALWAYS be firing, unless the player is using a certain pwoer-up.
        // Find a way to switch weapons - mouse scroll? Numbers on keyboard?
        // Should the player have access to all of the weapons from the start, or will they unlock them while playing?
            // Possible ideas:
                // Player can unlock new weapons if they kill a certain amount of enemies, play for a certain amount of time, etc.
        // Bullet life?
            // If the game has a "border," kill the bullets when they touch the border.
            // If there is no "border," give the bullets a lifetime.

    // Types of Weapons:
        // 1 - 
            // Fire rate greatly increases, but damage and accuracy decreases, causing each bullet to fire in random directions.

        // 2 - Poison Dart
            // Bullets deal damage over time (like a poison).
            // And/Or, the bullets stun or slow down enemies if hit.

        // 3 - Zapper
            // Bullets deal damage in a chain (if some enemies are close enough, they will be hit too).
            // Kind of like they're being electrocuted.

        // 4 - Rocket Launcher
            // Weapon shoots rockets that deal damage to multiple enemies at once.
            // Direct hits deal more damage, surrounding enemies less damaged.
            // Rockets that possibly follow the enemy?

        // 5 - Sniper
            // One shot weapon that eliminates any enemy, unless they have a shield; the shield will be instantly destroyed if shot.
            // High damage but low fire rare.

    // *~~ VARIABLES ~~*
    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] private Vector2 bulletDirection;
    [SerializeField] private int bulletDamage;

    public int bulletType;
        // Type 0: Bullet
        // Type 1: Electro Bullet
        // Type 2: Posion Dart
        // Type 3: Rocket
        // Type 4: Sniper Bullet
        // Type 5: Speedy Bullet

    private Rigidbody2D rb;

    private void OnEnable()
    {
        Invoke("Destroy", 3f);
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, bulletSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(bulletDirection * bulletSpeed * Time.deltaTime);
    }

    public void SetMoveDirection(Vector2 dir)
    {
        bulletDirection = dir;
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}
