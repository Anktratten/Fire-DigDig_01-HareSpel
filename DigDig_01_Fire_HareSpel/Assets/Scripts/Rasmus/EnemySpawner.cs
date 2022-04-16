using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner: MonoBehaviour
{
    public GameObject[] foxes;
    public GameObject[] hunters;
    public GameObject hunterBoss;

    public static int waveNumber = 1;

    public int spawnPosition;
    public int hunterSelect;
    public int huntersSpawned = 0;
    int hunterTargetAmount = 3;
    public float nextTimeToSpawn = 0;
    float spawnDelay = 3f;

    public static int huntersActive = 0;

    bool waveOver = false;


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
            if (huntersSpawned < hunterTargetAmount && nextTimeToSpawn < Time.time)
            {
                SpawnHunter();
                nextTimeToSpawn = Time.time + spawnDelay;
            }

            if (huntersActive == 0 && waveOver == false)
            {
                waveOver = true;
            }

        }
    }

    void SpawnHunter()
    {
        spawnPosition = Random.Range(-5, 5);
        hunterSelect = Random.Range(0, 0);
        Instantiate(hunters[hunterSelect], new Vector3(transform.position.x, transform.position.y + spawnPosition, 0), Quaternion.identity);
        huntersSpawned++;
        huntersActive++;
    }
    void NextWave()
    {
        waveNumber++;
        huntersSpawned = 0;

    }
}
