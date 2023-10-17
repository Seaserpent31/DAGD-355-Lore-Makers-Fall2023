using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_BasicEnemy_Lawrence : MonoBehaviour
{
    public float health;
    public float Maxhealth;
    public bool wasShielded;
    public GameObject manager;
    // Start is called before the first frame update
    void Start()
    {
        health = Maxhealth;
        manager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(health <= 0)
        {
            
            if (GetComponent<Script_ShieldEnemy_Lawrence>() != null)
            {
                manager.GetComponent<GameManager_Lawrence>().score += 20;
                GetComponent<Script_ShieldEnemy_Lawrence>().SpawnPowerUp();
            }
            if (GetComponent<EnemyMovement_Lauren>() != null)
            {
                manager.GetComponent<GameManager_Lawrence>().score += 10;
                GetComponent<EnemyMovement_Lauren>().Kill();
            }

            Destroy(gameObject);
        }
    }

    public void takeDamage(float D)
    {
        health -= D;
    }
}
