using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb_Ryk : MonoBehaviour
{
    public float speed;
    public bool bombActive = true;
    //private float damage = 20;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 6f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && bombActive)
        {
            Destroy(gameObject);
            Debug.Log("Destroyed");
        }

        transform.position -= new Vector3(1f, 0f, 0f) * speed * Time.deltaTime;
        //transform.rotation += Quaternion(0f, 0f, 0f, 0f) * speed * Time.deltaTime;
    }

    //if

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //collision.gameObject.GetComponent<Script_BasicEnemy_Lawrence>().takeDamage(damage);
            Destroy(gameObject);
            Debug.Log("Bomb Damage");
        }
    }
}
