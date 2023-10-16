using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_TrueShieldMaker_Lawrence : MonoBehaviour
{
    public GameObject shield;
    //sound stuff
    public AudioClip Sheildsound;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            bool s = collision.gameObject.GetComponent<Script_BasicEnemy_Lawrence>().wasShielded;
            if (!s)
            {
                audioSrc.PlayOneShot(Sheildsound);
                collision.gameObject.GetComponent<Script_BasicEnemy_Lawrence>().wasShielded = true;
                GameObject obj = Instantiate(shield, collision.gameObject.transform);
                if (collision.gameObject.GetComponent<EnemyMovement_Lauren>() != null)
                {
                    obj.transform.localScale = new Vector3(0.5f, 0.5f, 0.3f);
                }
                
            }
        }
    }

}
