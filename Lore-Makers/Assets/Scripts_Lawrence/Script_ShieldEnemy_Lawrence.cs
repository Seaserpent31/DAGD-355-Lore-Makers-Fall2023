using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_ShieldEnemy_Lawrence : MonoBehaviour
{

    public float speed;
    public float StopPoint;

    public GameObject TrueShieldMaker;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = new Vector2(-speed, 0);
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x <= StopPoint)
        {
            rb.velocity.Set(0, 0);
            transform.position = new Vector2(StopPoint, transform.position.y);
        }

    }

}
