using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Help used from:
// https://youtu.be/Mq2zYk5tW_E?si=iDfJ1_zxp0sC6NAJ.

#region Base Info
// ==========[ BULLET BASE ]==========
// A base for the different bullet scripts.
// Each script inherits this script.
// To-Do:
    // Add the important variables I need and go from there.
    // Speed
    // Rotation
    // Firerate
    // Damage
    // Direction
    // Lifetime
    // isRandom(?)
    // isPosion(?)
    // isElectric(?)
#endregion

public class BulletBase_Lauren : MonoBehaviour
{
// ==========[ VARIABLES ]==========
    private Vector2 direction;

    public float speed;
    public float rotation;

    // private Rigidbody2D rb;

    // OnEnable() - Destroying the bullet after a certain amount of time (lifetime).
    private void OnEnable()
    {
        Invoke("Destroy", 3f);

    }

// ==========[ START ]==========
    void Start()
    {
        // rb = GetComponent<Rigidbody2D>();
        // rb.velocity = new Vector2(0, speed);

        transform.rotation = Quaternion.Euler(0f, 0f, rotation);

    } // End of Start.

// ==========[ UPDATE ]==========
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

    } // End of Update.

    // SetDirection() - Setting the direction.
    public void SetDirection(Vector2 dir)
    {
        direction = dir;

    }

    // Destroy() - "destroying" the bullet (setting it to inactive).
    private void Destroy()
    {
        gameObject.SetActive(false);

    }

    // OnDisable() - For stopping the bullets from firing.
    private void OnDisable()
    {
        CancelInvoke();

    }

} // End of Bullet Base.
