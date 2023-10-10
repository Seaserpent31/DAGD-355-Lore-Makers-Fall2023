using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_Ryk : MonoBehaviour
{
    public float MaxSpeed;
    public float easeDist;
    public float maxHealth;
    public bool isShooting;
    public bool isDead;

    private float curHealth;
    private Rigidbody2D rb;
    private Vector3 goalPos;

    private float angleToGoal;
    private float distToGoal;
    private float easeStrength;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        curHealth = maxHealth;
        //healthBar.value = curHealth;
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");


        goalPos = Input.mousePosition;
        goalPos.z = 0;
        goalPos = Camera.main.ScreenToWorldPoint(goalPos);
        //get distance and angle to goal
        angleToGoal = Mathf.Atan2(goalPos.y - transform.position.y, goalPos.x - transform.position.x);
        distToGoal = Vector2.Distance(transform.position, goalPos);

        if (distToGoal > easeDist)
        {
            //max moveSpeed
            rb.velocity = MaxSpeed * new Vector2(Mathf.Cos(angleToGoal), Mathf.Sin(angleToGoal));
        }
        else if (distToGoal < .1)
        {
            //no speed
            rb.velocity = new Vector2(0, 0);
        }
        else
        {
            //easing speed
            easeStrength = distToGoal / easeDist;
            rb.velocity = MaxSpeed * new Vector2(Mathf.Cos(angleToGoal), Mathf.Sin(angleToGoal)) * easeStrength;

        }

    }
}
