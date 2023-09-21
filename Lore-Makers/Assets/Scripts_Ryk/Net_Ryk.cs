using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Net_Ryk : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 3;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0f, 1f, 0f) * speed * Time.deltaTime;
    }
}
