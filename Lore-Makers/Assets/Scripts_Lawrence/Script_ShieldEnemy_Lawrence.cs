using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_ShieldEnemy_Lawrence : MonoBehaviour
{

    public float speed;
    public float StopPoint;

    public GameObject TrueShieldMaker;
    public GameObject powerDrop;

    private Rigidbody2D rb;
    private float health=10;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = new Vector2(-speed, 0);
        health = GetComponent<Script_BasicEnemy_Lawrence>().health;
    }

    // Update is called once per frame
    void Update()
    {
        health = GetComponent<Script_BasicEnemy_Lawrence>().health;
        if (transform.position.x <= StopPoint)
        {
            rb.velocity.Set(0, 0);
            transform.position = new Vector2(StopPoint, transform.position.y);
        }

    }

    public void SpawnPowerUp()
    {
        float x = Random.Range(0, 10f);
        if (x > 7)
        {
            Instantiate(powerDrop, transform.position, Quaternion.identity);
        }
    }

}
