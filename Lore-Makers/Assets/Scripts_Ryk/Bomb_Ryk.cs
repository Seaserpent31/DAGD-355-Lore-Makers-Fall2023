using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb_Ryk : MonoBehaviour
{
    public float speed;
    public bool bombActive = true;

    // Start is called before the first frame update
    void Start()
    {
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
    }
}
