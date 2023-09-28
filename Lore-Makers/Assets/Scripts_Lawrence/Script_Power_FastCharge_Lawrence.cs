using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Power_FastCharge_Lawrence : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= -100)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Script_Player_Lawrence>().chargeFasterTimer = 10;
            Destroy(gameObject);
        }
    }

}
