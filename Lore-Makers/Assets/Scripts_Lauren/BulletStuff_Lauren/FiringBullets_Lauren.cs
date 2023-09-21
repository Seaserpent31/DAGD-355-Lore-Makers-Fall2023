using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringBullets_Lauren : MonoBehaviour
{
    // Help used from:
        // https://youtu.be/Mq2zYk5tW_E?si=iDfJ1_zxp0sC6NAJ.

    [SerializeField] private int amountBullets = 10;
    //[SerializeField] float startAngle = 270f, endAngle = 90f;
    [SerializeField] float startAngle = 0f, endAngle = 360f;
        // I want the bullets to shoot everywhere on screen.

    private Vector2 bulletMoveDirection;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", 0f, 2f);
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

            GameObject bullet = BulletPool_Lauren.bulletPoolInstance.GetBullet();
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            bullet.SetActive(true);
            bullet.GetComponent<Bullets_Lauren>().SetMoveDirection(bulDir);

            angle += angleStep;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
