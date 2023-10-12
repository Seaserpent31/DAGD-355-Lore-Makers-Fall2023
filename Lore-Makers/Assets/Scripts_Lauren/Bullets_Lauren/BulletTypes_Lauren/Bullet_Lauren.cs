using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

// Help used from:
// https://youtu.be/Mq2zYk5tW_E?si=iDfJ1_zxp0sC6NAJ.

#region Bullet Info
// ==========[ BULLET ]==========
// Basic bullet. Fires at a normal rate and deals a normal amount of damage to enemies hit.
// To-Do:
    // Mess around with numbers, add important things, etc. (same goes for every bullet script).
#endregion

public class Bullet_Lauren : BulletBase_Lauren
{
// ==========[ VARIABLES ]==========
    [SerializeField] private int amountBullets = 10;
    //[SerializeField] float startAngle = 270f, endAngle = 90f;
    [SerializeField] float startAngle = 90f, endAngle = 270f;
    // I want the bullets to shoot everywhere on screen.
    [SerializeField] private float firerate;

    private Vector2 bulletMoveDirection;

// ==========[ START ]==========
    private void Start()
    {
        InvokeRepeating("Fire", 0f, firerate);

    } // End of Start.

    // Fire() - Firing the bullet.
    private void Fire()
    {
        float angleStep = (endAngle - startAngle) / amountBullets;
        float angle = startAngle;

        for (int i = 0; i < amountBullets; i++)
        {
            float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);
            // Calculating end points.

            Vector3 bulMove = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMove - transform.position).normalized;

            GameObject bullet = BulletPool_Lauren.instance.GetBullet();
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            bullet.SetActive(true);
            bullet.GetComponent<BulletBase_Lauren>().SetDirection(bulDir);

            angle += angleStep;

        }

    } // End of Fire().

} // End of Bullet.
