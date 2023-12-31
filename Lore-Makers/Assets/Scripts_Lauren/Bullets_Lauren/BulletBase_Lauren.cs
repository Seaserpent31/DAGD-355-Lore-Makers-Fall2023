using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Help used from:
// https://youtu.be/Mq2zYk5tW_E?si=iDfJ1_zxp0sC6NAJ.

#region Base Info
// ==========[ BULLET BASE ]==========
// A base for the different bullet scripts.
// Each script inherits this script.

#endregion

public class BulletBase_Lauren : MonoBehaviour
{
// ==========[ VARIABLES ]==========
    public WeaponManager_Lauren weaponManager;
    public BulletDamage_Lauren bulletDamage;
    // private GameObject enemy;

    public LayerMask enemyLayer;

    private Vector2 direction;

    public float speed;
    public float rotation;

    private Rigidbody2D rb;

    // OnEnable() - Destroying the bullet after a certain amount of time (lifetime).
    private void OnEnable()
    {
        Invoke("Destroy", 5f);

    }

// ==========[ START ]==========
    void Start()
    {
        // enemy = GameObject.FindGameObjectWithTag("Enemy");

        rb = GetComponent<Rigidbody2D>();

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
