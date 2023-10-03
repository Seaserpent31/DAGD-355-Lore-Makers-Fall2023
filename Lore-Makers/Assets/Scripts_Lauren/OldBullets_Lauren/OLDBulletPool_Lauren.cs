using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class OLDBulletPool_Lauren : MonoBehaviour
{
    // Help used from:
        // https://youtu.be/Mq2zYk5tW_E?si=iDfJ1_zxp0sC6NAJ.

    // *~~ VARIABLES ~~*
    public static OLDBulletPool_Lauren bulletPoolInstance;

    public GameObject pooledBullet;
    private bool notEnoughBullets = true;

    private List<GameObject> bullets;
    // private List<GameObject> speedyBullets;

    private void Awake()
    {
        bulletPoolInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        bullets = new List<GameObject>();
        // speedyBullets = new List<GameObject>();
    }

    public GameObject GetBullet()
    {
        if(bullets.Count > 0)
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                if (!bullets[i].activeInHierarchy)
                {
                    return bullets[i];
                }
            }
        }

        if (notEnoughBullets)
        {
            GameObject bullet = Instantiate(pooledBullet);
            bullet.SetActive(false);
            bullets.Add(bullet);
            return bullet;
        }

        return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
