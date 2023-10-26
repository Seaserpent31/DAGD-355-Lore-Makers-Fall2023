using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetSpawn_Ryk : MonoBehaviour
{
    public GameObject net;
    public GameObject electricBurst;

    public GameObject player;

    public bool netActive = false;

    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.Find("Player_Ryk");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!netActive)
            {
                Instantiate(net, GameObject.FindGameObjectWithTag("Player").transform.position, Quaternion.identity);
                netActive = true;
            }
            else if (netActive)
            {
                Instantiate(electricBurst, GameObject.FindGameObjectWithTag("Player").transform.position, Quaternion.identity);
                netActive = false;
            }
        }
    }
}

