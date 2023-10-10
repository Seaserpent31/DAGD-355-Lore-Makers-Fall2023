using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement_Ryk : MonoBehaviour
{
    public float spawnPosX;
    public float spawnPosY;

    // Start is called before the first frame update
    void Start()
    {
        spawnPosX = Random.Range(0, 10);
        spawnPosY = Random.Range(0, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
