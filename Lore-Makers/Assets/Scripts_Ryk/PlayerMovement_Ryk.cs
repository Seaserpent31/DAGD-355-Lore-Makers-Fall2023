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

    }
}
