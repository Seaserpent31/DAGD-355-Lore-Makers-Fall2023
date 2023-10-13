using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

#region Dart Info
// ==========[ ELECTRO BULLET ]==========
// These darts fire at a normal rate.
// They deal a normal amount of damage, but deal damage in a chain (as long as there are nearby enemies).
// To-Do:
    // Make sure the bullets deal damage to multiple enemies at a time.
    // Visualize the damage being done to the enemies.
    // Look at the code from previous electro bullet script (look on GitHub since I deleted the script).
#endregion 

public class electroBullet_Lauren : MonoBehaviour
{
// ==========[ VARIABLES ]==========
   public WeaponManager_Lauren weaponManager;
    
    [SerializeField] private int amountBullets = 10;
    //[SerializeField] float startAngle = 270f, endAngle = 90f;
    // [SerializeField] float startAngle = 90f, endAngle = 270f;
    // I want the bullets to shoot everywhere on screen.

    [SerializeField] private float firerate;
    [SerializeField] private bool isShooting = false;

    private Vector2 bulletMoveDirection;

    private float angle = 0f;

    // ==========[ START ]==========
    private void Start()
    {
        if (weaponManager.curWeaponIndex == 1)
        {
            InvokeRepeating("Spiral", 0f, firerate);
        }
        else if (weaponManager.curWeaponIndex != 1)
        {
            CancelInvoke();
        }

    } // End of Start.


    // Spiral() - Shoots bullets in a spiral.
    private void Fire()
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

} // End of Electro Bullet.
