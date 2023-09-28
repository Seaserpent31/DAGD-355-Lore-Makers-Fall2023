using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Net_Ryk : MonoBehaviour
{
    public float speed;

    public bool netActive = true;

    public float burstRadius;

    // Start is called before the first frame update
    void Start()
    {
        speed = 6f;
        burstRadius = 5f;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && netActive)
        {
            Destroy(gameObject);
            Debug.Log("Destroyed");
        }

        transform.position += new Vector3(1f, 0f, 0f) * speed * Time.deltaTime;
    }
}
