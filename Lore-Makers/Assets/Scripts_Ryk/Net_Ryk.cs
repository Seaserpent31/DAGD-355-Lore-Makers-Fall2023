using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Net_Ryk : MonoBehaviour
{
    public float speed;
    public int damage;
    public int passiveDamage;

    public bool netActive = true;

    public float burstRadius;
    public bool burstNet;

    public Vector3 gravityRange;
    public float gravityStrength;
    public float pullForce;
    public bool isEnemyPulled;

    List<GameObject> trappedGuys;

    // Start is called before the first frame update
    void Start()
    {
        speed = 6f;
        damage = 50;
        passiveDamage = 5;
        burstRadius = 5f;
        burstNet = false;
        trappedGuys = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && netActive)
        {
            Debug.Log(trappedGuys.Count);
            Destroy(gameObject);
            foreach(GameObject go in trappedGuys)
            {
                if (go != null)
                {
                    //Debug.Log("netDamage");
                    go.GetComponent<Script_BasicEnemy_Lawrence>().takeDamage(damage);
                }
            }
            burstNet = true;
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
        if (collider.gameObject.tag == "Enemy")
        {
            collider.gameObject.GetComponent<Script_BasicEnemy_Lawrence>().takeDamage(passiveDamage);
            trappedGuys.Add(collider.gameObject);
        }
    }
}

