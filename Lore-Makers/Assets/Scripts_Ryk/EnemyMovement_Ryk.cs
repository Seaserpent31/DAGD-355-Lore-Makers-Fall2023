using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class EnemyMovement_Ryk : MonoBehaviour
{
    private float speed;

    private int enemyFirePattern;

    private float enemyFireRate;

    private bool enemyFire;

    public GameObject shot;

    // Start is called before the first frame update
    void Start()
    {
        speed = 5.0f;

        enemyFirePattern = Random.Range(0, 3);

        //Debug.Log(spawnPosX + " " + spawnPosY);
        Debug.Log(enemyFirePattern);

        enemyFire = false;
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
        if (enemyFireRate >= 3)
        {
            Instantiate(shot, GameObject.FindGameObjectWithTag("Enemy").transform.position, Quaternion.identity);
            enemyFireRate = 0;
            enemyFire = true;
        }

        if (enemyFire)
        {
            GameObject.FindGameObjectWithTag("Shot").transform.position -= new Vector3(1f, 0f, 0f) * speed * Time.deltaTime;
        }
    }

    private void firePatternTriple()
    {

    }

    private void firePatternPierce()
    {

    }
}
