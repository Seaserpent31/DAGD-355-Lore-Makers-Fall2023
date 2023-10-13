using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

#region Sniper Info
// ==========[ SNIPER BULLET ]==========
// These bullets fire one at a time at a slower rate than regular bullets.
// To make up for the low firerate, these bullets deal a lot of damage compared to the regular ones.
// To-Do:
    // Make the bullets find the closest enemy and shoot towards them.
    // Look at the code from previous sniper bullet script (look on GitHub since I deleted the script).
#endregion

public class SniperBullet_Lauren : MonoBehaviour
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

} // End of Sniper Bullet.
