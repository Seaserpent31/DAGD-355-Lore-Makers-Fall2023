using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_Ryk : MonoBehaviour
{
    public GameObject enemy;

    public GameObject net;

    public bool netCollidedEnemy;
    public bool netBurstCollision;

    public bool enemyKilled;

    public float spawnPosX;
    public float spawnPosY;



    // Start is called before the first frame update
    void Start()
    {
        spawnPosX = Random.Range(0, 10);
        spawnPosY = Random.Range(0, 10);
        //Instantiate(enemy, Vector3(spawnPosX, spawnPosY, 0f), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (gameObjectWithTag("Bomber"))
            {
                Instantiate(bomb, GameObject.FindGameObjectWithTag("Enemy").transform.position, Quaternion.identity);
                bombActive = true;
            }

            else
            {
                randomSpawnNumber = Random.Range(0, 10);
                Debug.Log(randomSpawnNumber);
                if (randomSpawnNumber < spawnRate)
                {
                    Instantiate(bomb, GameObject.FindGameObjectWithTag("Enemy").transform.position, Quaternion.identity);
                    bombActive = true;
                }
            }
        }
    }
}
