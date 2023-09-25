using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Script_Shot_Lawrence : MonoBehaviour
{

    private float lifeTimer = 5;
    public float damage = 10;
    public float speed=15;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed,0);

    }

    // Update is called once per frame
    void Update()
    {
        lifeTimer -=Time.deltaTime;
        if(lifeTimer <= 0)
        {
            Destroy(gameObject);
        }

    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Script_BasicEnemy_Lawrence>().takeDamage(damage);
            Destroy(gameObject);
        }
    }

}
