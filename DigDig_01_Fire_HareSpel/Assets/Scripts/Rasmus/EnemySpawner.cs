using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject fox;
    public GameObject[] hunters;
    public GameObject[] dogs;
    public GameObject hunterBoss1;
    public GameObject hunterBoss2;
    public GameObject hunterBoss3;
    public GameObject dumpBoss;
    public GameObject hunterBossDummy;

    public int waveNumber = 1;

    public int hunterSelect;
    public int huntersSpawned = 0;
    int hunterTargetAmount = 3;
    public float nextTimeToSpawn = 0;
    float spawnDelay = 3f;

    int foxChance = 10;

    public static int huntersActive = 0;

    public int huntersUnlocked = 0;
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
        Debug.Log(huntersActive);
        if (PauseController.isPaused == false)
        {
            if (huntersSpawned < hunterTargetAmount && nextTimeToSpawn < Time.time && isBossWave == false)
            {
                SpawnHunter();
                nextTimeToSpawn = Time.time + spawnDelay;
            }

            if(huntersSpawned == hunterTargetAmount && huntersActive == 0 && waveOver == false)
            {
                waveOver = true;
                CancelInvoke("FoxSpawner");
                CancelInvoke("DogSpawner");
                Invoke("NextWave", 4);
            }
        }
    }

    void SpawnHunter()
    {
        int spawnPosition = Random.Range(-5, 5);
        hunterSelect = Random.Range(0, huntersUnlocked + 1);
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
        }
        else if (waveNumber != 20)
        {
            isBossWave = false;
        }
        else if (waveNumber == 20)
        {
            Instantiate(hunterBossDummy, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            Invoke("SpawnDump", 3);
            isBossWave = true;
        }

        if (isBossWave == false)
        {
            if (waveNumber < 5)
            {
                hunterTargetAmount += 1;
            }
            else if (waveNumber < 10)
            {
                hunterTargetAmount += 2;
                spawnDelay = 2f;
                huntersUnlocked = 1;
            }
            else if (waveNumber > 10)
            {
                hunterTargetAmount += 2;
                spawnDelay = 1f;
                huntersUnlocked = 2;
            }

            if (waveNumber > 5)
            {
                InvokeRepeating("FoxSpawner", 0, 1);
            }
            if (waveNumber > 10)
            {
                InvokeRepeating("DogSpawner", 0, 1);
            }
            if (waveNumber > 15)
            {
                dogsUnlocked = 1;
            }
        }


    }
    void SpawnHunterBoss()
    {
        hunterTargetAmount = 1;
        if(waveNumber == 5)
        {
            Instantiate(hunterBoss1, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            huntersActive++;
            huntersSpawned++;
        }
        else if (waveNumber == 10)
        {
            Instantiate(hunterBoss2, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            huntersActive++;
            huntersSpawned++;
        }
        else if (waveNumber == 15)
        {
            Instantiate(hunterBoss3, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            huntersActive++;
            huntersSpawned++;
        }
    }
    void SpawnDump()
    {
        hunterTargetAmount = 1;
        Instantiate(dumpBoss, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
    }
    void FoxSpawner()
    {
        int spawnRandomizer = Random.Range(1, 9);
        int spawnPosition = Random.Range(-5, 5);
        if (spawnRandomizer == 1)
        {
            Instantiate(fox, new Vector3(transform.position.x, transform.position.y + spawnPosition, 0), Quaternion.identity);
        }
    }
    void DogSpawner()
    {
        int spawnRandomizer = Random.Range(1, 9);
        if (spawnRandomizer == 1)
        {
            int spawnPosition = Random.Range(-5, 5);
            int typeRandomizer = Random.Range(0, dogsUnlocked + 1);
            Instantiate(dogs[typeRandomizer], new Vector3(transform.position.x, transform.position.y + spawnPosition, 0), Quaternion.identity);
        }

    }
}
