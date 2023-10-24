using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Net_Ryk : MonoBehaviour
{
    public float speed;
    public int damage;

    public bool netActive = true;

    public float burstRadius;
    public bool burstNet;

    public Vector3 gravityRange;
    public float gravityStrength;
    public float pullForce;
    public bool isEnemyPulled;

    // Start is called before the first frame update
    void Start()
    {
        speed = 6f;
        damage = 25;
        burstRadius = 5f;
        burstNet = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && netActive)
        {
<<<<<<< Updated upstream
            Destroy(gameObject);
            Debug.Log("Destroyed");
=======
            Debug.Log(trappedGuys.Count);

            foreach(GameObject go in trappedGuys)
            {
                if (go != null)
                {
                    //Debug.Log("netDamage");
                    go.GetComponent<Script_BasicEnemy_Lawrence>().takeDamage(damage);
                }
            }

            //spawn explosion prefab which pull enemies closer to the vortex and applies massive damage and destroys self

            //Instatiate

>>>>>>> Stashed changes
            burstNet = true;
            Destroy(gameObject);
        }

        if (burstNet)
        {
            Debug.Log(damage + " damage dealt");
        }

        transform.position += new Vector3(1f, 0f, 0f) * speed * Time.deltaTime;
    }

    /*private void gravityPull()
    {
        if (GameObject.FindGameObjectWithTag("Enemy").transform.position < gameObject.transform.position + gravityRange)
        {
            
        }
        pullForce = (gameObject.transform.position - GameObject.FindGameObjectWithTag("Enemy").transform.position).normalized / distance to Enemy * gravityStrength;
    }*/

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Triggered!");
    }
}

