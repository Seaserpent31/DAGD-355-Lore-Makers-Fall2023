using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;

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

    public GameObject PhaseUp;
    public float spawnIntervalPhase;
    private float spawnTimerPhase;


    public int score;
    public TextMeshProUGUI scoreText;


    //sound stuff
    public AudioClip startsound;
    static AudioSource audioSrc;

    // Background Audio (Lauren)
    public AudioManager_Lauren audioManager;
    [SerializeField] private AudioClip backgroundMusic;

    // Start is called before the first frame update
    void Start()
    {
        spawnTimerShield = spawnIntervalShield;
        audioSrc = GetComponent<AudioSource>();

        audioManager = AudioManager_Lauren.FindAnyObjectByType<AudioManager_Lauren>();

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

        spawnTimerPhase -= Time.deltaTime;
        if (spawnTimerPhase <= 0)
        {
            spawnTimerPhase = spawnIntervalPhase;
            spawnPhase();
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
        spawnPos = new Vector3(15, Random.Range(-6.3f, 9.25f), 0);
        Instantiate(BasicEnemy, spawnPos, Quaternion.Euler(0,0,-90));
    }
    public void spawnPhase()
    {
        spawnPos = new Vector3(Random.Range(-17f, 17f), Random.Range(-6.3f, 9.25f), 0);
        Instantiate(PhaseUp, spawnPos, Quaternion.identity);
    }
    public void StartGame()
    {
        score = 0;
        Time.timeScale = 1f;
        PlayerChar.GetComponent<Script_Player_Lawrence>().ResetPlayer();
        audioSrc.PlayOneShot(startsound);

        audioManager.Play(backgroundMusic);
    }

    public void endGame()
    {
        audioManager.Stop(backgroundMusic);
        
        GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
       // Debug.Log(allEnemies.Length);
        foreach(GameObject enemy in allEnemies)
        {
            Destroy(enemy);
        }
        GameObject[] allShots = GameObject.FindGameObjectsWithTag("Shot");
        //Debug.Log(allShots.Length);
        foreach (GameObject shot in allShots)
        {
            Destroy(shot);
        }
        GameObject[] allUps = GameObject.FindGameObjectsWithTag("PowerUp");
        //Debug.Log(allUps.Length);
        foreach (GameObject shot in allUps)
        {
            Destroy(shot);
        }

        GameObject[] allBullets = GameObject.FindGameObjectsWithTag("Bullet");
        foreach (GameObject bullet in allBullets)
        {
            bullet.SetActive(false);
        }
    }
}
