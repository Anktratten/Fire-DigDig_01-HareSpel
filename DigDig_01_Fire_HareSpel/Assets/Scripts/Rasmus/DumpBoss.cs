using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumpBoss : MonoBehaviour
{
    bool transporting = true;
    bool startedPhase1 = false;
    bool startedPhase2 = false;
    bool transporting2 = false;
    bool increasedPhase = false;
    float transportSpeed = 3f;
    float walkingSpeed = 2;
    int dumpPhase = 1;

    public static bool wallUp = false;

    public GameObject shot;
    public GameObject shotgun_down;
    public GameObject shotgun_up;
    public GameObject spread_down;
    public GameObject spread_up;

    public GameObject bird;
    public GameObject laser;
    public GameObject wall;
    public GameObject bomb;

    Vector3 targetLocation;

    Vector3[] positions = new Vector3[6];
    float current_location;

    int hp = 20;

    // Start is called before the first frame update
    void Start()
    {
        positions[1] = new Vector3(6, -3, 0);
        positions[2] = new Vector3(6, 0, 0);
        positions[3] = new Vector3(6, 3, 0);
        positions[4] = new Vector3(6, 1.5f, 0);
        positions[5] = new Vector3(6, -1.5f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(hp);
        if (hp <= 0 && increasedPhase == false)
        {
            CancelInvoke();
            dumpPhase++;
            transporting = true;
            increasedPhase = true;
        }

        if (transform.position.x >= 5 && dumpPhase == 1 && transporting == true)
        {
            transform.position = new Vector3(transform.position.x - transportSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        }
        else if (transform.position.x <= 5)
        {
            transporting = false;
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
            if (transform.position.x <= 7 || transform.position.y != 0 && transporting == true)
            {
                Debug.Log("duckfuck");
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(7, 0, 0), walkingSpeed * Time.deltaTime);
            }
            if (transform.position.x >= 7 || transform.position.y == 0)
            {
                transporting = false;
            }
            if (startedPhase2 == false && transporting == false)
            {
                hp = 1;
                SpawnWall();
                InvokeRepeating("SpawnBird", 0, 2);
                InvokeRepeating("ThrowBomb", 0, 20);
                InvokeRepeating("ShootLaser", 0, 10);
                startedPhase2 = true;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet" && wallUp == false && transporting == false && transporting2 == false)
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
        current_location = targetLocation.y;
        do
        {
            int result = Random.Range(1, 6);
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
        } while (current_location == targetLocation.y);
    }

    void TrumpHunterShoot()
    {
        Instantiate(shot, new Vector3(transform.position.x + -1.0f, transform.position.y, -0.1f), Quaternion.identity);
        Instantiate(shotgun_down, new Vector3(transform.position.x + -0.9f, transform.position.y, -0.1f), Quaternion.identity);
        Instantiate(shotgun_up, new Vector3(transform.position.x + -0.9f, transform.position.y, 0.1f), Quaternion.identity);
        Instantiate(spread_down, new Vector3(transform.position.x + -0.8f, transform.position.y, -0.1f), Quaternion.identity);
        Instantiate(spread_up, new Vector3(transform.position.x + -0.8f, transform.position.y, 0.1f), Quaternion.identity);
    }
    void SpawnWall()
    {
        Instantiate(wall, new Vector3(transform.position.x - 1.5f, transform.position.y, 0), Quaternion.identity);
        wallUp = true;
    }
    void SpawnBird()
    {
        Instantiate(bird, transform);
    }
    void ThrowBomb()
    {

    }
    void ShootLaser()
    {

    }
}
