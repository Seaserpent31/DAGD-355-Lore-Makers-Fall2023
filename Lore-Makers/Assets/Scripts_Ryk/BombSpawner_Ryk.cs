using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner_Ryk : MonoBehaviour
{
    public bool spawnBomb;
    public int spawnRate;
    public int randomSpawnNumber;

    public GameObject bomb;

    //Throwaway Variables
    public bool bombActive = false;

    // Start is called before the first frame update
    void Start()
    {
        spawnBomb = false;
        spawnRate = 5;

    }

    // Update is called once per frame
    void Update()
    {
        /*if(randomSpawnNumber > spawnRate)
        {
            spawnBomb = true;
        }

        if (spawnBomb) 
        {
            Instantiate(bomb, GameObject.FindGameObjectWithTag("Enemy").transform.position, Quaternion.identity);
        }*/

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!bombActive)
            {
                randomSpawnNumber = Random.Range(0, spawnRate);
                Debug.Log(randomSpawnNumber);
                if (randomSpawnNumber > 2)
                {
                    Instantiate(bomb, GameObject.FindGameObjectWithTag("Enemy").transform.position, Quaternion.identity);
                    bombActive = true;
                }
            }
            else if (bombActive)
            {
                bombActive = false;
            }
        }
    }
}
