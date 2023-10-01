using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Net_Ryk : MonoBehaviour
{
    public float speed;
    public int damage;

    public bool netActive = true;

    public float burstRadius;
    public bool burstNet;

    public float gravityRange;
    public float gravityStrength;

    // Start is called before the first frame update
    void Start()
    {
        speed = 6f;
        damage = 25;
        burstRadius = 5f;
        burstNet = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && netActive)
        {
            Destroy(gameObject);
            Debug.Log("Destroyed");
            burstNet = true;
        }

        if (burstNet)
        {
            Debug.Log(damage + " damage dealt");
        }

        transform.position += new Vector3(1f, 0f, 0f) * speed * Time.deltaTime;
    }
}