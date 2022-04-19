using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject fox;
    public GameObject[] hunters;
    public GameObject[] dogs;
    public GameObject hunterBoss;
    public GameObject dumpBoss;

    public int waveNumber = 1;

    public int hunterSelect;
    public int huntersSpawned = 0;
    int hunterTargetAmount = 3;
    public float nextTimeToSpawn = 0;
    float spawnDelay = 3f;

    int foxChance = 10;

    public static int huntersActive = 0;

    int huntersUnlocked = 0;
    int dogsUnlocked = 0;

    bool waveOver = false;
    bool isBossWave = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (PauseController.isPaused == false)
        {
            if (huntersSpawned < hunterTargetAmount && nextTimeToSpawn < Time.time && isBossWave == false)
            {
                SpawnHunter();
                nextTimeToSpawn = Time.time + spawnDelay;
            }

            else if (huntersSpawned == hunterTargetAmount && huntersActive == 0 && waveOver == false)
            {
                waveOver = true;
                Invoke("NextWave", 4);
            }
        }
    }

    void SpawnHunter()
    {
        int spawnPosition = Random.Range(-5, 5);
        hunterSelect = Random.Range(0, huntersUnlocked);
        Instantiate(hunters[hunterSelect], new Vector3(transform.position.x, transform.position.y + spawnPosition, 0), Quaternion.identity);
        huntersSpawned++;
        huntersActive++;
    }
    void NextWave()
    {
        waveOver = false;
        waveNumber++;
        huntersSpawned = 0;

        if (waveNumber % 5 == 0 && waveNumber != 20)
        {
            SpawnHunterBoss();
            isBossWave = true;
            Debug.Log("this works");
        }
        else if (waveNumber != 20)
        {
            isBossWave = false;
        }
        else if (waveNumber == 20)
        {

        }

        if (waveNumber < 5)
        {
            hunterTargetAmount += 1;
        }
        else if (waveNumber < 10 && waveNumber > 6)
        {
            hunterTargetAmount += 2;
            spawnDelay = 2f;
            huntersUnlocked = 1;
        }
        else
        {
            hunterTargetAmount += 1;
            spawnDelay = 1f;
            huntersUnlocked = 2;
        }
        Debug.Log(waveNumber);

        if (waveNumber > 4)
        {
            InvokeRepeating("FoxSpawner", 0, 1);
        }
        if (waveNumber > 9)
        {
            InvokeRepeating("DogSpawner", 0, 1);
        }
        if (waveNumber > 15)
        {
            dogsUnlocked = 1;
        }

    }
    void SpawnHunterBoss()
    {
        Instantiate(hunterBoss, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        huntersActive++;
    }
    void FoxSpawner()
    {
        int spawnRandomizer = Random.Range(1, foxChance);
        int spawnPosition = Random.Range(-5, 5);
        if (spawnRandomizer == 1)
        {
            Instantiate(fox, new Vector3(transform.position.x, transform.position.y + spawnPosition, 0), Quaternion.identity);
        }
    }
    void DogSpawner()
    {
        int spawnRandomizer = Random.Range(1, foxChance);
        int spawnPosition = Random.Range(-5, 5);
        int typeRandomizer = Random.Range(0, dogsUnlocked);
        Instantiate(dogs[typeRandomizer], new Vector3(transform.position.x, transform.position.y + spawnPosition, 0), Quaternion.identity);
    }
}
