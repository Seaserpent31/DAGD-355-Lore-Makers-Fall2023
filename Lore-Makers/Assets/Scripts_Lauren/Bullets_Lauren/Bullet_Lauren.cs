using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;
using UnityEngine.UIElements;
//using static UnityEditor.ObjectChangeEventStream;


// Help used from:
// https://youtu.be/Mq2zYk5tW_E?si=iDfJ1_zxp0sC6NAJ.

#region Bullet Info
// ==========[ BULLET ]==========
// Basic bullet. Fires at a normal rate and deals a normal amount of damage to enemies hit.
// To-Do:
// Mess around with numbers, add important things, etc. (same goes for every bullet script).

#endregion

public class Bullet_Lauren : MonoBehaviour
{
// ==========[ VARIABLES ]==========
    public GameManager gameManager;   
    public AudioManager_Lauren audioManager;

    public WeaponManager_Lauren weaponManager;
    public BulletDamage_Lauren bulletDamage;
    // public EnemyMovement_Lauren enemyDamage;

    [SerializeField] private AudioClip clip;

    private Rigidbody2D rb;

    // [SerializeField]
    private int amountBullets;
    // [SerializeField]
    private float startAngle, endAngle;

    // [SerializeField]
    private float firerate;
    private float speed;
    private float angle;

    private Vector2 bulletMoveDirection;

    private float lastShot = 0f;

    public LayerMask enemyLayer;

    public int damageAmount;

    // private bool isShooting = true;

    private int pattern = 0;
    // 0 - Normal
    // 1 - Electro
    // 2 - Poison Dart
    // 3 - Rocket
    // 4 - Sniper
    // 5 - Speedy

    // ==========[ START ]==========
    private void Start()
    {
        gameManager = GameManager.FindAnyObjectByType<GameManager>();
        audioManager = AudioManager_Lauren.FindAnyObjectByType<AudioManager_Lauren>();
        // bulletBase = FindAnyObjectByType<BulletBase_Lauren>();

        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // Bullet
            pattern = 0;
            bulletDamage.ChangeType(0);
            // weaponManager.SwapWeapon(WeaponManager_Lauren.WeaponType.Bullet);

            audioManager.Play(clip);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            // Electro Bullet
            pattern = 1;
            bulletDamage.ChangeType(1);
            // weaponManager.SwapWeapon(WeaponManager_Lauren.WeaponType.Electro);

            audioManager.Play(clip);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            // Poison Dart
            pattern = 2;
            bulletDamage.ChangeType(2);
            // weaponManager.SwapWeapon(WeaponManager_Lauren.WeaponType.PoisonDart);
            // 
            audioManager.Play(clip);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            // Rocket
            pattern = 3;
            bulletDamage.ChangeType(3);
            // weaponManager.SwapWeapon(WeaponManager_Lauren.WeaponType.Rocket);

            audioManager.Play(clip);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            // Sniper
            pattern = 4;
            bulletDamage.ChangeType(4);
            // weaponManager.SwapWeapon(WeaponManager_Lauren.WeaponType.Sniper);

            audioManager.Play(clip);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            // Speedy Bullet
            pattern = 5;
            bulletDamage.ChangeType(5);
            // weaponManager.SwapWeapon(WeaponManager_Lauren.WeaponType.Speedy);

            audioManager.Play(clip);
        }

        switch (pattern)
        {
            case 0: // Bullet
                if(!gameManager.isPhasing)
                {
                    Bullet();
                }
                break;
            case 1: // Electro
                if (!gameManager.isPhasing)
                {
                    Electro();
                    // bulletDamage.ElectroEffect();
                }                
                break;
            case 2: // Poison Dart
                if (!gameManager.isPhasing)
                {
                    PoisonDart();
                    // bulletDamage.PoisonEffect();
                }               
                break;
            case 3: // Rocket
                if (!gameManager.isPhasing)
                {
                    Rocket();
                }
                break;
            case 4: // Sniper
                if (!gameManager.isPhasing)
                {
                    Sniper();
                }
                break;
            case 5: // Speedy Bullet
                if (!gameManager.isPhasing)
                {
                    Speedy();
                }
                break;
        }
    }

    // Bullet() - Shooting bullets.
    private void Bullet()
    {
        amountBullets = 8;
        firerate = 5f;

        // So hundreds of bullets don't shoot at a time.
        float shotTime = 1f / firerate;

        if (Time.time - lastShot >= shotTime)
        {
            lastShot = Time.time;

            for (int i = 0; i < amountBullets; i++)
            {
                float bulDirX = transform.position.x + Mathf.Sin((angle + i * (360 / amountBullets)) * Mathf.Deg2Rad);
                float bulDirY = transform.position.y + Mathf.Cos((angle + i * (360 / amountBullets)) * Mathf.Deg2Rad);

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

    } // End of Bullet().

    // Electro() - Firing electro bullets.
    private void Electro()
    {
        // Variables
        amountBullets = 10;
        startAngle = 0;
        endAngle = 360;
        firerate = 1f;

        // So hundreds of bullets don't shoot at a time.
        float shotTime = 1f / firerate;

        if (Time.time - lastShot >= shotTime)
        {
            lastShot = Time.time;

            // Angles
            float angleStep = (endAngle - startAngle) / amountBullets;
            float angle = startAngle;

            for (int i = 0; i < amountBullets; i++)
            {
                float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180);
                float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180);

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

    } // End of Electro().

    public void ElectroEffect()
    {

    }

    // PoisonDart() - Firing poison darts.
    private void PoisonDart()
    {
        amountBullets = 15;
        firerate = 1f;

        // So hundreds of bullets don't shoot at a time.
        float shotTime = 1f / firerate;

        if (Time.time - lastShot >= shotTime)
        {
            lastShot = Time.time;

            for (int i = 0; i < amountBullets; i++)
            {
                float bulDirX = transform.position.x + Mathf.Sin((angle + i * (360 / amountBullets)) * Mathf.Deg2Rad);
                float bulDirY = transform.position.y + Mathf.Cos((angle + i * (360 / amountBullets)) * Mathf.Deg2Rad);

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

    } // End of PoisonDart().

    // Rocket() - Firing rockets.
    void Rocket()
    {
        amountBullets = 1;
        firerate = 1f;
        speed = 3f;
        
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closestEnemy = null;

        float closestDis = Mathf.Infinity;

        float shotTime = 1f / firerate;

        // For each enemy, find the distance of each to figure out which one is closest to the player.
        foreach (GameObject enemy in enemies)
        {
            float disToEnemy = (enemy.transform.position - this.transform.position).sqrMagnitude;
            if (disToEnemy < closestDis)
            {
                closestDis = disToEnemy;
                closestEnemy = enemy;
            }
        }

        // If there are no more enemies on screen, stop looking for the closest distance.
        if (enemies.Length == 0)
        {
            return;
        }

        if (Time.time - lastShot >= shotTime)
        {
            lastShot = Time.time;

            // If there is an enemy on screen, shoot at the closeset one.
            if (closestEnemy != null)
            {
                // Find the direction of the enemy.
                Vector3 directionToEnemy = (closestEnemy.transform.position - transform.position).normalized * speed;
                // Vector2 bulDir = (directionToEnemy - transform.position).normalized;

                // Shoot bullets towards that enemy's direction.
                for (int i = 0; i < amountBullets; i++)
                {
                    GameObject bul = BulletPool_Lauren.instance.GetBullet();
                    bul.transform.position = transform.position;
                    bul.transform.rotation = transform.rotation;
                    bul.SetActive(true);
                    bul.GetComponent<BulletBase_Lauren>().SetDirection(directionToEnemy);
                }

            }
            // Draw a line so we can see which enemy is closest (and to see if it worked).
            Debug.DrawLine(transform.position, closestEnemy.transform.position);
        }

    } // End of Rocket().

    // Sniper() - Firing sniper bullets.
    private void Sniper()
    {
        amountBullets = 1;
        firerate = 2f;
        speed = 5f;

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closestEnemy = null;

        float closestDis = Mathf.Infinity;

        float shotTime = 1f / firerate;

        // For each enemy, find the distance of each to figure out which one is closest to the player.
        foreach (GameObject enemy in enemies)
        {
            float disToEnemy = (enemy.transform.position - this.transform.position).sqrMagnitude;
            if (disToEnemy < closestDis)
            {
                closestDis = disToEnemy;
                closestEnemy = enemy;
            }
        }

        // If there are no more enemies on screen, stop looking for the closest distance.
        if (enemies.Length == 0)
        {
            return;
        }

        if (Time.time - lastShot >= shotTime)
        {
            lastShot = Time.time;

            // If there is an enemy on screen, shoot at the closeset one.
            if (closestEnemy != null)
            {
                // Find the direction of the enemy.
                Vector3 directionToEnemy = (closestEnemy.transform.position - transform.position).normalized * speed;
                // Vector2 bulDir = (directionToEnemy - transform.position).normalized;

                // Shoot bullets towards that enemy's direction.
                for (int i = 0; i < amountBullets; i++)
                {
                    GameObject bul = BulletPool_Lauren.instance.GetBullet();
                    bul.transform.position = transform.position;
                    bul.transform.rotation = transform.rotation;
                    bul.SetActive(true);
                    bul.GetComponent<BulletBase_Lauren>().SetDirection(directionToEnemy);
                }

            }
            // Draw a line so we can see which enemy is closest (and to see if it worked).
            Debug.DrawLine(transform.position, closestEnemy.transform.position);
        }

    } // End of Sniper().

    // Speedy() - Firing speedy bullets.
    private void Speedy()
    {
        // Variables
        amountBullets = 15;
        startAngle = Random.Range(0f, 360f);
        endAngle = Random.Range(0f, 360f);
        firerate = 5f;
        speed = 2f;
        
        // So hundreds of bullets don't shoot at a time.
        float shotTime = 1f / firerate;

        if (Time.time - lastShot >= shotTime)
        {
            lastShot = Time.time;

            // Angles
            float angleStep = (endAngle - startAngle) / amountBullets;
            float angle = startAngle;

            for (int i = 0; i < amountBullets; i++)
            {
                float bulDirX = transform.position.x + Mathf.Sin((angle + i * (360 / amountBullets)));
                float bulDirY = transform.position.y + Mathf.Cos((angle - i * (360 / amountBullets)));

                Vector3 bulMove = new Vector3(bulDirX, bulDirY, 0f);
                Vector2 bulDir = (bulMove - transform.position).normalized * speed;

                GameObject bullet = BulletPool_Lauren.instance.GetBullet();
                bullet.transform.position = transform.position;
                bullet.transform.rotation = transform.rotation;
                bullet.SetActive(true);
                bullet.GetComponent<BulletBase_Lauren>().SetDirection(bulDir);

                angle += angleStep;
            }
        }

    } // End of Speedy().

} // End of Bullet.
