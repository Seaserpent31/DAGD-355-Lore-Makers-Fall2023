using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetSpawn_Ryk : MonoBehaviour
{
    public GameObject net;

    public bool netActive = false;

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
