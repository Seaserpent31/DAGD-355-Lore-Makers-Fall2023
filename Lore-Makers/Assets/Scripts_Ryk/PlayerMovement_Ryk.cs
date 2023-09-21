using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_Ryk : MonoBehaviour
{
    public bool netActive = true;

    public GameObject net;

    // Start is called before the first frame update
    void Start()
    {
        net = GameObject.FindWithTag("Net");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && !netActive)
        {
            Instantiate(net, transform.position, Quaternion.identity);
            netActive = true;
            Debug.Log("Q is hit");
        }

        if (Input.GetKeyDown(KeyCode.Q) && netActive)
        {
            Destroy(net);
            netActive = false;
        }

    }
}
