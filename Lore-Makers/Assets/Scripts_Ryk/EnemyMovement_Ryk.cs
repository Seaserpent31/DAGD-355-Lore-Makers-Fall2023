using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement_Ryk : MonoBehaviour
{
    private int enemyFirePattern;

    private float enemyFireRate;

    public GameObject shot;

    // Start is called before the first frame update
    void Start()
    {

        enemyFirePattern = Random.Range(0, 3);

        //Debug.Log(spawnPosX + " " + spawnPosY);
        Debug.Log(enemyFirePattern);

    }

    // Update is called once per frame
    void Update()
    {

        if (enemyFirePattern == 0)
        {
            firePatternSingle();
        }
        else if (enemyFirePattern == 1)
        {
            firePatternSingle();
        }
        else if (enemyFirePattern == 2)
        {
            firePatternSingle();
        }
    }

    private void firePatternSingle()
    {
        enemyFireRate += Time.deltaTime;
        if (enemyFireRate >= 3 )
        {
            Instantiate(shot, GameObject.FindGameObjectWithTag("Enemy").transform.position, Quaternion.identity);
            enemyFireRate = 0;
        }
    }

    private void firePatternTriple()
    {

    }

    private void firePatternPierce() 
    {
        
    }
}
