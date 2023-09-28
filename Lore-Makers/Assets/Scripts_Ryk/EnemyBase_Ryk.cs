using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase_Ryk : MonoBehaviour
{
    public int health;
    public int damage;
    public float speed;

    public int maxHealth;

    //public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        health = 50;
    }

    // Update is called once per frame
    void Update()
    {
        if (health < 0) 
        {
            Destroy(gameObject);
        }
    }
}
