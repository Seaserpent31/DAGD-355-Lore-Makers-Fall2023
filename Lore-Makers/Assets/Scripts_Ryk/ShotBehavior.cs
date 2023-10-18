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
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Player Hit!");
        //Deal Damage
        Destroy(gameObject);
    }
}
