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



// To fix my weapon sawpping, will probably have to have ALL bullet info on one script and swap between them.
    // For ex) having a "Fire" and "Spiral" invoke but "if index == 0, fire" and "if index == 1, spiral" kind of thing.
    // Kind of like swapping scenes/screens in DAGD 255.

    // replace a lot of the numbers and stuff with variables so i can edit them for each bullet type.
#endregion

public class Bullet_Lauren : MonoBehaviour
{
// ==========[ VARIABLES ]==========
    public WeaponManager_Lauren weaponManager;
    public GameManager gameManager;

    [SerializeField] private int amountBullets = 10;
    //[SerializeField] float startAngle = 270f, endAngle = 90f;
    [SerializeField] float startAngle = 90f, endAngle = 270f;
    // I want the bullets to shoot everywhere on screen.

    [SerializeField] private float firerate;

    private Vector2 bulletMoveDirection;

    // private bool isShooting = true;

    private float angle = 0f;

    private int pattern = 0;
        // 0 - Normal
        // 1 - Electro
        // 2 - Poison Dart
        // 3 - Rocket
        // 4 - Sniper
        // 5 - Speedy

    private float lastShot = 0f;

    // ==========[ START ]==========
    private void Start()
    {
        // StartShooting();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // Bullet
            pattern = 0;
            weaponManager.SwapWeapon(WeaponManager_Lauren.WeaponType.Bullet);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            // Electro Bullet
            pattern = 1;
            weaponManager.SwapWeapon(WeaponManager_Lauren.WeaponType.Electro);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            // Poison Dart
            pattern = 2;
            weaponManager.SwapWeapon(WeaponManager_Lauren.WeaponType.PoisonDart);         
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            // Rocket
            pattern = 3;
            weaponManager.SwapWeapon(WeaponManager_Lauren.WeaponType.Rocket);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            // Sniper
            pattern = 4;
            weaponManager.SwapWeapon(WeaponManager_Lauren.WeaponType.Sniper);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            // Speedy Bullet
            pattern = 5;
            weaponManager.SwapWeapon(WeaponManager_Lauren.WeaponType.Speedy);
        }

        switch (pattern)
        {
            case 0:
                Fire();
                break;
            case 1:
                Spiral();
                break;
            case 2:
                Fire();
                break;
            case 3:
                Fire();
                break;
            case 4:
                Fire();
                break;
            case 5:
                Fire();
                break;
        }
    }

    // Fire() - Firing the bullet.
    private void Fire()
    {
        // So hundreds of bullets don't shoot at a time.
        float shotTime = 1f / firerate;

        if (Time.time - lastShot >= shotTime)
        {
            lastShot = Time.time;

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
        }

    } // End of Fire().

    // Spiral() - Spiral bullets.
    private void Spiral()
    {
        // So hundreds of bullets don't shoot at a time.
        float shotTime = 1f / firerate;

        if (Time.time - lastShot >= shotTime)
        {
            lastShot = Time.time;

            for (int i = 0; i < 10; i++)
            {
                float bulDirX = transform.position.x + Mathf.Sin(((angle + 90f * i) * Mathf.PI / 4) / 90f);
                float bulDirY = transform.position.y + Mathf.Cos(((angle + 90f * i) * Mathf.PI / 4) / 90f);

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
        }

    } // End of Spiral().

} // End of Bullet.
