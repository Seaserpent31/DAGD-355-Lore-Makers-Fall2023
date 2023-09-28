using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner_Ryk : MonoBehaviour
{
    public bool spawnBomb;
    public int spawnRate;
    public int randomSpawnNumber;

    public GameObject bomb;

    // Start is called before the first frame update
    void Start()
    {
        spawnBomb = false;
        spawnRate = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if(randomSpawnNumber > spawnRate)
        {
            spawnBomb = true;
        }

        if (spawnBomb) 
        {
            Instantiate(bomb, transform.position, Quaternion.identity);
        }
    }
}
