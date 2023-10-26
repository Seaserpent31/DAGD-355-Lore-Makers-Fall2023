using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_BackgroundImage_Lawrence : MonoBehaviour
{
    float scrollSpeed = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x-scrollSpeed*Time.deltaTime, transform.position.y, transform.position.z);
        if (transform.position.x <= -38.4f) transform.position = new Vector3(transform.position.x + 76.8f, transform.position.y, transform.position.z); ; 
    }
}
