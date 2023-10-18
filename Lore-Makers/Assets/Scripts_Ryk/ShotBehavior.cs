using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBehavior : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-1f, 0f, 0f) * speed * Time.deltaTime;

        if(transform.position.x < -20f)Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<Script_Player_Lawrence>() != null)
        {
            Debug.Log("Player Hit!");
            //Deal Damage
            collider.gameObject.GetComponent<Script_Player_Lawrence>().TakeDamage(5);
            Destroy(gameObject);
        }
    }
}
