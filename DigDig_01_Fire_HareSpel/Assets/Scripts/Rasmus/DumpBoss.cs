using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumpBoss : MonoBehaviour
{
    bool transporting = true;
    bool startedPhase1 = false;
    bool startedPhase2 = false;
    bool startedPhase3 = false;
    bool increasedPhase = false;
    bool dead = false;
    float transportSpeed = 1f;
    float walkingSpeed = 2;
    int dumpPhase = 1;

    int birdCounter = 0;
    int airStrikeCounter = 0;

    public static bool wallUp = false;

    public int result;

    public GameObject shot;
    public GameObject shotgun_down;
    public GameObject shotgun_up;
    public GameObject spread_down;
    public GameObject spread_up;

    public GameObject bird;
    public GameObject laser;
    public GameObject wall;
    public GameObject airStrike;

    public GameObject[] hunters;
    public int hunterSelect;
    public static int huntersActive = 0;
    GameObject spawner;

    public RuntimeAnimatorController dumpWithBoss;
    public RuntimeAnimatorController dumpWall;
    public RuntimeAnimatorController dumpPhase3;
    public RuntimeAnimatorController dumpDead;

    Animator animator;

    Vector3 targetLocation;

    Vector3[] positions = new Vector3[6];
    Vector3 current_location;

    int hp = 20;

    // Start is called before the first frame update
    void Start()
    {
        positions[1] = new Vector3(6, -3, 0);
        positions[2] = new Vector3(6, 0, 0);
        positions[3] = new Vector3(6, 3, 0);
        positions[4] = new Vector3(5, 1.5f, 0);
        positions[5] = new Vector3(5, -1.5f, 0);
        spawner = GameObject.Find("Enemy Spawner");
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("birdcount is" + birdCounter);
        Debug.Log(hp);
        if (hp <= 0 && increasedPhase == false && startedPhase3 == false)
        {
            CancelInvoke();
            dumpPhase++;
            transporting = true;
            increasedPhase = true;
        }
        else if (hp <= 0 && startedPhase3 == true)
        {
            dead = true;
            animator.runtimeAnimatorController = dumpDead;
            animator.Play("Dump death");
            Invoke("DeathDelay", 1.4f);
        }

        if (transform.position.x >= 5 && dumpPhase == 1 && transporting == true)
        {
            transform.position = new Vector3(transform.position.x - transportSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        }
        else if (transform.position.x <= 5)
        {
            animator.SetBool("Dump pickup", true);
            Invoke("PickupDelay", 1);
        }

        if (transporting == false)
        {
            if (dumpPhase == 1)
            {
                if (startedPhase1 == false)
                {
                    InvokeRepeating("TrumpHunterShoot", 0, 1);
                    InvokeRepeating("Randomizer", 0, 5);
                    startedPhase1 = true;
                }
                Movement();
            }
        }
        if (dumpPhase == 2)
        {
            if (transform.position.x != 7 || transform.position.y != 0 && transporting == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(7, 0, 0), walkingSpeed * Time.deltaTime);
            }
            if (transform.position.x == 7 || transform.position.y == 0)
            {
                
                transporting = false;
            }
            if (startedPhase2 == false && transporting == false)
            {
                hp = 1;
                
                SpawnWall();
                InvokeRepeating("SpawnBird", 1, 1);
                InvokeRepeating("AirStrike", 10, 10);
                Invoke("WallDelay", 2);
                animator.runtimeAnimatorController = dumpWall;
                animator.Play("Dump Cast wall");
                increasedPhase = false;
                startedPhase2 = true;
            }
        }
        if (dumpPhase == 3 && dead == false)
        {
            if (transform.position.x != 6 || transform.position.y != 0 && transporting == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(6, 0, 0), walkingSpeed * Time.deltaTime);
            }
            if (transform.position.x == 6 || transform.position.y == 0)
            {
                transporting = false;
            }
            if (startedPhase3 == false && transporting == false)
            {
                hp = 100;
                InvokeRepeating("Randomizer", 0, 0.5f);
                InvokeRepeating("SpawnHunter", 0, 4);
                walkingSpeed = 5;
                startedPhase3 = true;
            }
            Movement();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet" && wallUp == false && transporting == false)
        {
            hp -= collision.gameObject.GetComponent<BulletDamage>().damage;
            Destroy(collision.gameObject);
        }
    }
    void Movement()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetLocation, walkingSpeed * Time.deltaTime);
    }
    private void Randomizer()
    {
        current_location = targetLocation;
        do
        {
            result = Random.Range(1, 6);
            if (result == 1)
            {
                targetLocation = positions[1];
            }
            else if (result == 2)
            {
                targetLocation = positions[2];
            }
            else if (result == 3)
            {
                targetLocation = positions[3];
            }
            else if (result == 4)
            {
                targetLocation = positions[4];
            }
            else if (result == 5)
            {
                targetLocation = positions[5];
            }
        } while (current_location == targetLocation);
    }
    void PickupDelay()
    {
        animator.runtimeAnimatorController = dumpWithBoss;
        transporting = false;
    }
    void WallDelay()
    {
        transporting = false;
    }
    void DeathDelay()
    {
        Destroy(gameObject);
    }
    void TrumpHunterShoot()
    {
        animator.Play("Dump Fire");
        Instantiate(shot, new Vector3(transform.position.x + -2.3f, transform.position.y, -0.1f), Quaternion.identity);
        Instantiate(shotgun_down, new Vector3(transform.position.x + -2.2f, transform.position.y, -0.1f), Quaternion.identity);
        Instantiate(shotgun_up, new Vector3(transform.position.x + -2.1f, transform.position.y, 0.1f), Quaternion.identity);
        Instantiate(spread_down, new Vector3(transform.position.x + -2.0f, transform.position.y, -0.1f), Quaternion.identity);
        Instantiate(spread_up, new Vector3(transform.position.x + -1.9f, transform.position.y, 0.1f), Quaternion.identity);
    }
    void SpawnWall()
    {
        Instantiate(wall, new Vector3(transform.position.x - 1.5f, transform.position.y, 0), Quaternion.identity);
        wallUp = true;
    }
    void SpawnBird()
    {
        birdCounter++;
        Instantiate(bird, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        animator.Play("Dump bird");
        if (birdCounter == 9)
        {
            CancelInvoke("SpawnBird");
            InvokeRepeating("SpawnBird", 2, 1);
            birdCounter = 0;
        }
    }
    void AirStrike()
    {
        airStrikeCounter++;
        GameObject airStrikeTemp = Instantiate(airStrike, new Vector3(10, 4.7f, 0), Quaternion.identity);
        if (airStrikeCounter == 2)
        {
            airStrikeTemp.gameObject.GetComponent<DumpAirstrike>().isDud = true;
            airStrikeCounter = 0;
        }
    }
    void SpawnHunter()
    {
        if (huntersActive <= 5)
        {
            int spawnPosition = Random.Range(-5, 5);
            hunterSelect = Random.Range(0, 3);
            Instantiate(hunters[hunterSelect], new Vector3(spawner.transform.position.x, spawner.transform.position.y + spawnPosition, 0), Quaternion.identity);
            huntersActive++;
        }
    }
}
