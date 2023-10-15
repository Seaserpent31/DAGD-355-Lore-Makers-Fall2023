using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

// Help used from:
// https://youtu.be/Mq2zYk5tW_E?si=iDfJ1_zxp0sC6NAJ.

#region Pool Info
// ==========[ BULLET POOL ]==========
// For pooling bullets.

#endregion

public class BulletPool_Lauren : MonoBehaviour
{
// ==========[ VARUABLES ]==========
    public static BulletPool_Lauren instance;

    [SerializeField] private GameObject pooledBullet;
    private bool notEnoughBullets = true;

    private List<GameObject> bullets;

 // ==========[ AWAKE ]==========
    private void Awake()
    {
        instance = this;

    } // End of Awake.

// ==========[ START ]==========
    private void Start()
    {
        bullets = new List<GameObject>();

    } // End of Start.

    // GetBullet() - "Getting" the bullet.
    public GameObject GetBullet()
    {
        if (bullets.Count > 0)
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                if (!bullets[i].activeInHierarchy)
                {
                    return bullets[i];
                }
            }
        }

        // If there aren't enough bullets, "make" more.
        if (notEnoughBullets)
        {
            GameObject bullet = Instantiate(pooledBullet);
            bullet.SetActive(false);
            bullets.Add(bullet);
            return bullet;
        }

        return null;

    } // End of GetBullet().

// ==========[ UPDATE ]==========
    private void Update()
    {
        

    } // End of Update.

} // End of Bullet Pool.