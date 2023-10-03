using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OLDFiringBullets_Lauren : MonoBehaviour
{
    // Help used from:
        // https://youtu.be/Mq2zYk5tW_E?si=iDfJ1_zxp0sC6NAJ.

    [SerializeField] private int amountBullets = 10;
    //[SerializeField] float startAngle = 270f, endAngle = 90f;
    [SerializeField] float startAngle = 0f, endAngle = 360f;
        // I want the bullets to shoot everywhere on screen.

    private Vector2 bulletMoveDirection;

    private float angle = 0;

    // BulletPool_Lauren bulletPool;
    OLDWeaponsManager_Lauren weaponType;

    private void Awake()
    {
        weaponType = GetComponent<OLDWeaponsManager_Lauren>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (weaponType.currentWeaponIndex == 0)
        {
            InvokeRepeating("Fire", 0f, 1f);
        }
        else if (weaponType.currentWeaponIndex == 1)
        {
            InvokeRepeating("Spiral", 0f, 0.25f);
        }
    }

    private void Fire()
    {
        float angleStep = (endAngle - startAngle) / amountBullets;
        float angle = startAngle;

        for (int i = 0; i < amountBullets; i++)
        {
            float bulDirX = transform.position.x + Mathf.Sin(angle * Mathf.PI / 180f);
            float bulDirY = transform.position.y + Mathf.Cos(angle * Mathf.PI / 180f);
                // Calculating end points.

            Vector3 bulMove = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMove - transform.position).normalized;

            GameObject bullet = OLDBulletPool_Lauren.bulletPoolInstance.GetBullet();
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            bullet.SetActive(true);
            bullet.GetComponent<OLDBullets_Lauren>().SetMoveDirection(bulDir);

           angle += angleStep;
        }
    }

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

            GameObject bul = OLDBulletPool_Lauren.bulletPoolInstance.GetBullet();
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<OLDBullets_Lauren>().SetMoveDirection(bulDir);
        }

        angle += 10f;

        // If the angle reaches the "end," we have to reset it.
        if (angle >= 360f)
        {
            angle = 0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
