using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement_Lauren : MonoBehaviour
{
    // Enemy: Bomber.
    // This enemy follows player movements.
    // They do not shoot at the player, however they carry a bomb.
    // If they reach the player or are in range of the player when they're "killed," they deal damage to the player.

    public GameObject player;
    public float speed;

    private float dis;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dis = Vector2.Distance(transform.position, player.transform.position);
        Vector2 dir = player.transform.position - transform.forward;
        dir.Normalize();
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        // Movement and rotation.
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);
    }
}
