using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

// Help used from:
// https://youtu.be/Mq2zYk5tW_E?si=iDfJ1_zxp0sC6NAJ.

#region Shoot Info
// ==========[ SHOOT BULLETS ]==========
// Do not need this anymore, but will still keep just in case something needs to be changed.
// Currently just holds the same thing Bullet_Lauren and ElectroBullet_Lauren has (as of right now).
#endregion

public class ShootBullets_Lauren : MonoBehaviour
{
    // ==========[ VARIABLES ]==========
    [SerializeField] private int amountBullets = 10;
    //[SerializeField] float startAngle = 270f, endAngle = 90f;
    [SerializeField] float startAngle = 90f, endAngle = 270f;
    // I want the bullets to shoot everywhere on screen.

    [SerializeField] private float firerate;

    private Vector2 bulletMoveDirection;

    private float angle = 0;

// ==========[ START ]==========
    private void Start()
    {

        InvokeRepeating("Fire", 0f, firerate);

    } // End of Start.

    // Fire() - Firing the bullets.
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

    // Spiral() - Same as Fire() but in a different pattern.
    private void Spiral()
    {
        for (int i = 0; i < 10; i++)
        {
            // Firing bullets at different angles.
            float bulDirX = transform.position.x + Mathf.Sin(((angle + 180f * i) * Mathf.PI) / 180f);
            float bulDirY = transform.position.y + Mathf.Cos(((angle + 180f * i) * Mathf.PI) / 180f);
            // Firing double spiral bullets from the top and bottom of the player.

            bulDirX = transform.position.x + Mathf.Sin(((angle + 90f * i) * Mathf.PI / 2) / 90f);
            bulDirY = transform.position.y + Mathf.Cos(((angle + 90f * i) * Mathf.PI / 2) / 90f);
            // Firing more bullets at the player's side.

            Vector3 bulMove = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMove - transform.position).normalized;

            GameObject bul = BulletPool_Lauren.instance.GetBullet();
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<BulletBase_Lauren>().SetDirection(bulDir);
        }

        angle += 10f;

        // If the angle reaches the "end," we have to reset it.
        if (angle >= 360f)
        {
            angle = 0f;

        }

    } // End of Spiral().

} // End of Shoot Bullets.
