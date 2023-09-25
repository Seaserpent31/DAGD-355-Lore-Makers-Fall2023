using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Script_Player_Lawrence : MonoBehaviour
{
    public float MaxSpeed;
    public float easeDist;
    public GameObject basicBullet;
    public GameObject ChargeShot;
    public float maxHealth;
    public bool isShooting;
    public bool isDead;
    public float maxChargeTime;
    public GameObject HealthHolder;
    public GameObject chargeHolder;

    public ProgressBar healthBar;
    public Slider chargeBar;

    private float curHealth;
    private Rigidbody2D rb;
    private Vector3 goalPos;
    private float chargeTime=0;
    private bool isCharging=false;

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
        healthBar = HealthHolder.GetComponent<ProgressBar>();
        chargeBar = chargeHolder.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {

        //
        if(!isDead )
        {
            //gets mouse input for shooting
            if(Input.GetMouseButtonDown(0))
            {
                isCharging = true;
            }
            if(Input.GetMouseButtonUp(0))
            {
                if (isCharging)
                {
                    AttemptChargeShot();
                }
            }


            //if is charging then display charge meter and stop shooting bullets
            if(isCharging)
            {
                isShooting = false;
                chargeTime += Time.deltaTime;
                if(chargeTime > maxChargeTime)
                {
                    AttemptChargeShot();
                }
            }

            // chargeBar.value = chargeTime;

            //update player health
            // healthBar.value = curHealth;


            //playerMovement
            //get mouse button
            goalPos = Input.mousePosition;
            goalPos.z = 0;
            goalPos = Camera.main.ScreenToWorldPoint(goalPos);
            //get distance and angle to goal
            angleToGoal = Mathf.Atan2(goalPos.y - transform.position.y, goalPos.x - transform.position.x);
            distToGoal = Vector2.Distance(transform.position, goalPos);

            if (distToGoal > easeDist)
            {
                //max moveSpeed
                rb.velocity = MaxSpeed * new Vector2(Mathf.Cos(angleToGoal),Mathf.Sin(angleToGoal));
            }
            else if(distToGoal < .5)
            {
                //no speed
                rb.velocity = new Vector2(0,0);
            }
            else
            {
                //easing speed
                easeStrength = distToGoal / easeDist;
                rb.velocity = MaxSpeed * new Vector2(Mathf.Cos(angleToGoal), Mathf.Sin(angleToGoal)) * easeStrength;
               
            }
            

        }
    }

    void AttemptChargeShot()
    {
        //shoot bullet if Charge is close to full
        if (chargeTime >= .7f * maxChargeTime && chargeTime <= .9f*maxChargeTime)
        {
            Instantiate(ChargeShot, transform.position, Quaternion.identity);
        }
        else if(chargeTime > .9f * maxChargeTime)// take damage if charge is overfull;
        {
            curHealth -= 10;
        }
        chargeTime = 0;
        isCharging = false;
        isShooting=true;
    }
}
