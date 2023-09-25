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
    void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void takeDamage(float D)
    {
        health -= D;
    }
}
