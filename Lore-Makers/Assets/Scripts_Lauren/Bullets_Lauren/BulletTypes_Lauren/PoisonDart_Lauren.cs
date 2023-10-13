using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

#region Dart Info
// ==========[ SPEEDY BULLET ]==========
// These darts fire at a normal rate.
// They deal a little less damage than normal bullets, but if an enemy is hit, they deal more damage over time.
// To-Do:
    // Make sure the bullets deal base damage and continue to deal a little bit of damage over time.
    // Add effects to show enemies being posioned (look at other games for inspiration).
#endregion 

public class PoisonDart_Lauren : MonoBehaviour
{
// ==========[ VARIABLES ]==========
    [SerializeField] private int amountBullets = 10;
    //[SerializeField] float startAngle = 270f, endAngle = 90f;
    [SerializeField] float startAngle = 90f, endAngle = 270f;
    // I want the bullets to shoot everywhere on screen.

    [SerializeField] private float firerate;
    [SerializeField] private bool isShooting = false;

    private Vector2 bulletMoveDirection;

// ==========[ START ]==========
    private void Start()
    {
        if (isShooting)
        {
            InvokeRepeating("Fire", 0f, firerate);
        }

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

} // End of Poison Dart.
