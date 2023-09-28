using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_Ryk : MonoBehaviour
{
    public float goalPos;
    public float angleToGoal;
    public float distToGoal;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");


        /*goalPos = Input.mousePosition();
        goalPos.z = 0;
        goalPos = Camera.main.ScreenToWorldPoint(goalPos);

        angleToGoal = Mathf.Atan2(goalPos.y - transform.position.y, goalPos.x - transform.position.x);
        distToGoal = Vector2.Distance(transform.position, goalPos);*/
    }
}
