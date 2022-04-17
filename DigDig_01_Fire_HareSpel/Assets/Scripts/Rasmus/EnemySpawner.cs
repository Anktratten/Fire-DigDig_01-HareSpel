using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner: MonoBehaviour
{
    public GameObject[] foxes;
    public GameObject[] hunters;
    public GameObject hunterBoss;

    public static int waveNumber = 1;

    public int hunterSpawnPosition;
    public int hunterSelect;
    public int huntersSpawned = 0;
    int hunterTargetAmount = 3;
    public float nextTimeToSpawn = 0;
    float spawnDelay = 3f;

    float foxChance = 0;

    public static int huntersActive = 0;

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
        hunterSpawnPosition = Random.Range(-5, 5);
        hunterSelect = Random.Range(0, 0);
        Instantiate(hunters[hunterSelect], new Vector3(transform.position.x, transform.position.y + hunterSpawnPosition, 0), Quaternion.identity);
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
            UpgradeHunters();
            isBossWave = true;
        }
        else
        {
            isBossWave = false;
        }

        if (waveNumber < 5)
        {
            hunterTargetAmount += 1;
        }
        else if (waveNumber < 10 && waveNumber > 6)
        {
            hunterTargetAmount += 2;
            spawnDelay = 2f;
        }
        else
        {
            hunterTargetAmount += 1;
            spawnDelay = 1f;
        }
        Debug.Log(waveNumber);

    }
    void SpawnHunterBoss()
    {
        Instantiate(hunterBoss, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        huntersActive++;
    }
    void FoxSpawner()
    {

    }
    void UpgradeHunters()
    {

    }
}
