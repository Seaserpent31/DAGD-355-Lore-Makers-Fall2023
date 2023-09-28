using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_Lawrence : MonoBehaviour
{
    public GameObject shieldEnemy;
    public float spawnIntervalShield;
    private float spawnTimerShield;
    private Vector3 spawnPos;
    // Start is called before the first frame update
    void Start()
    {
        spawnTimerShield = spawnIntervalShield;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimerShield -= Time.deltaTime;
        if(spawnTimerShield <= 0)
        {
            spawnTimerShield = spawnIntervalShield;
            spawnShieldEnemy();
        }
    }

    public void spawnShieldEnemy()
    {
        spawnPos = new Vector3(30, Random.Range(-6.3f, 9.25f), 0);
        Instantiate(shieldEnemy, spawnPos, Quaternion.identity);
    }
}
