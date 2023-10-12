using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

#region Speedy Info
// ==========[ SPEEDY BULLET ]==========
// These bullets fire at a faster rate than regular bullets.
// Because they shoot out so fast, they shoot out at random places.
// They also deal less damage than regular bullets.
// To-Do:
    // Randomize everything.
    // Make sure the bullets fire fast and deal a low amount of damage.
    // Look at the code from previous speedy bullet script (look on GitHub since I deleted the script).
#endregion

public class SpeedyBullet_Lauren : BulletBase_Lauren
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

} // End of Speedy Bullet.
