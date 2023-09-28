using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

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

    public Slider healthBar;
    public Slider chargeBar;

    private float curHealth;
    private Rigidbody2D rb;
    private Vector3 goalPos;
    private float chargeTime=0;
    private bool isCharging=false;

    private float angleToGoal;
    private float distToGoal;
    private float easeStrength;

    public float chargeFasterTimer;


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

            //cahrge faster power timer
            if (chargeFasterTimer >= 0)
            {
                chargeFasterTimer -= Time.deltaTime;
            }


            //if is charging then display charge meter and stop shooting bullets
            if(isCharging)
            {
                isShooting = false;
                chargeTime += Time.deltaTime;
                //if fast charging is true then charge twice as fast
                if (chargeFasterTimer > 0)
                {
                    chargeTime += Time.deltaTime;
                }


                if(chargeTime > maxChargeTime)
                {
                    AttemptChargeShot();
                }
            }

             chargeBar.value = chargeTime;
            if(chargeFasterTimer > 0)
            {
                chargeBar.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = new UnityEngine.Color(0f / 255f, 243f / 255f, 255f / 255f);
            }
            else
            {

                chargeBar.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = new UnityEngine.Color(255f / 255f, 243f / 255f, 0f / 255f);
            }
            
            //update player health
            healthBar.value = curHealth;


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
            else if(distToGoal < .1)
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
            if(chargeFasterTimer > 0)
            {
                Instantiate(ChargeShot, transform.position, Quaternion.identity);
            }
            else
            {
                curHealth -= 10;
            }
        }
        chargeTime = 0;
        isCharging = false;
        isShooting=true;
    }
}
