using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Net_Ryk : MonoBehaviour
{
    public float speed;

    public bool netActive = true;

    // Start is called before the first frame update
    void Start()
    {
        speed = 3;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q) && !netActive)
        {
            Instantiate(gameObject, transform.position, Quaternion.identity);
            netActive = true;
            Debug.Log("Q is hit");
        }

        if (Input.GetKeyDown(KeyCode.Q) && netActive)
        {
            Destroy(gameObject);
            netActive = false;
        }

        transform.position += new Vector3(0f, 1f, 0f) * speed * Time.deltaTime;
    }
}
