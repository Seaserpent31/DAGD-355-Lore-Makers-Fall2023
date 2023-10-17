using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager_Lawrence : MonoBehaviour
{
    public GameObject shieldEnemy;
    public GameObject PlayerChar;
    public float spawnIntervalShield;
    private float spawnTimerShield;
    private Vector3 spawnPos;

    public GameObject bomberEnemy;
    public float spawnIntervalBomber;
    private float spawnTimerBomber;


    public GameObject BasicEnemy;
    public float spawnIntervalBasic;
    private float spawnTimerBasic;

    public int score;
    public TextMeshProUGUI scoreText;


    //sound stuff
    public AudioClip startsound;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        spawnTimerShield = spawnIntervalShield;
        audioSrc = GetComponent<AudioSource>();


        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimerShield -= Time.deltaTime;
        if(spawnTimerShield <= 0)
        {
            spawnTimerShield = spawnIntervalShield;
            spawnShieldEnemy();
        }
        spawnTimerBomber -= Time.deltaTime;
        if (spawnTimerBomber <= 0)
        {
            spawnTimerBomber = spawnIntervalBomber;
            spawnBomberEnemy();
        }

        spawnTimerBasic -= Time.deltaTime;
        if (spawnTimerBasic <= 0)
        {
            spawnTimerBasic = spawnIntervalBasic;
            spawnBasicEnemy();
        }
        scoreText.text = "Score :" + score;
    }

    public void spawnShieldEnemy()
    {
        spawnPos = new Vector3(30, Random.Range(-6.3f, 9.25f), 0);
        Instantiate(shieldEnemy, spawnPos, Quaternion.identity);
    }
    public void spawnBomberEnemy()
    {
        spawnPos = new Vector3(30, Random.Range(-6.3f, 9.25f), 0);
        Instantiate(bomberEnemy, spawnPos, Quaternion.identity);
    }
    public void spawnBasicEnemy()
    {
        spawnPos = new Vector3(30, Random.Range(-6.3f, 9.25f), 0);
        Instantiate(BasicEnemy, spawnPos, Quaternion.identity);
    }

    public void StartGame()
    {
        score = 0;
        Time.timeScale = 1f;
        PlayerChar.GetComponent<Script_Player_Lawrence>().ResetPlayer();
        audioSrc.PlayOneShot(startsound);
    }

    public void endGame()
    {
        GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        Debug.Log(allEnemies.Length);
        foreach(GameObject enemy in allEnemies)
        {
            Destroy(enemy);
        }
    }
}
