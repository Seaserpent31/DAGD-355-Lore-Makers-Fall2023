using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner_Ryk : MonoBehaviour
{
    bool spawnBomb;
    public int spawnRate;
    int randomSpawnNumber;

    public GameObject bomb;

    //Throwaway Variables
    public bool bombActive = false;

    // Start is called before the first frame update
    void Start()
    {
        spawnBomb = false;

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

        
    }

    public void kill()
    {
        if (!bombActive)
        {
            randomSpawnNumber = Random.Range(0, 10);
            //Debug.Log(randomSpawnNumber);
            if (randomSpawnNumber < spawnRate)
            {
                Instantiate(bomb, gameObject.transform.position, Quaternion.identity);
                bombActive = true;
            }
        }
    }
}
