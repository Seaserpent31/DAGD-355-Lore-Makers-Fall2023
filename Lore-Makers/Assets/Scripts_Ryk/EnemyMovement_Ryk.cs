using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement_Ryk : MonoBehaviour
{
    private int enemyFirePattern;
 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        enemyFirePattern = Random.Range(0, 3);
        

        if (enemyFirePattern == 0 )
        {

        }
        else if (enemyFirePattern == 1 )
        {

        }
        else if(enemyFirePattern == 2 )
        {

        }
        //Debug.Log(spawnPosX + " " + spawnPosY);
    }
}
