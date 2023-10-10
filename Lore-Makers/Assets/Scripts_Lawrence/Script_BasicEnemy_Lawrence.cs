using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_BasicEnemy_Lawrence : MonoBehaviour
{
    public float health;
    public float Maxhealth;
    public bool wasShielded;
    // Start is called before the first frame update
    void Start()
    {
        health = Maxhealth;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
            if (GetComponent<Script_ShieldEnemy_Lawrence>() != null)
            {
                GetComponent<Script_ShieldEnemy_Lawrence>().SpawnPowerUp();
            }
            if (GetComponent<EnemyMovement_Lauren>() != null)
            {
                GetComponent<EnemyMovement_Lauren>().kill();
            }
        }
    }

    public void takeDamage(float D)
    {
        health -= D;
    }
}
