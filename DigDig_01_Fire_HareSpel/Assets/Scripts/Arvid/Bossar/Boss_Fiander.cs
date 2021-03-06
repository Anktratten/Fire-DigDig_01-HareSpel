using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Fiander : MonoBehaviour
{
    float nextTimeToFire = 0;

    public Transform Shot;
    public Transform shotgun_u;
    public Transform shotgun_n;

    public float Cooldown_burst;
    public float Cooldown_shotgun;
    public float Cooldown;

    public bool shotgun = false;
    public bool burst = false;

    float bulletCount = 0;

    public float delay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseController.isPaused == false)
        {
            if (Boss_Chungus.dead == true)
            {
                Destroy(gameObject);
            }
            if (shotgun == false && burst == false)
            {
                if (nextTimeToFire < Time.time)
                {
                    Instantiate(Shot, new Vector3(transform.position.x + 0.1f, transform.position.y, 0), Quaternion.identity);
                    nextTimeToFire = Time.time + Cooldown;
                }
            }
            else if (shotgun == true)
            {
                if (nextTimeToFire < Time.time)
                {
                    Instantiate(Shot, new Vector3(transform.position.x + 0.1f, transform.position.y, 0), Quaternion.identity);
                    Instantiate(shotgun_u, new Vector3(transform.position.x + 0.1f, transform.position.y, 0), Quaternion.identity);
                    Instantiate(shotgun_n, new Vector3(transform.position.x + 0.1f, transform.position.y, 0), Quaternion.identity);
                    nextTimeToFire = Time.time + Cooldown_shotgun;
                }
            }
            else
            {
                if (nextTimeToFire < Time.time)
                {
                    InvokeRepeating("BurstFire", 0, delay /*delay mellan skott*/);
                    nextTimeToFire = Time.time + Cooldown_burst;
                }
            }
        }
    }
    void BurstFire()
    {
        Instantiate(Shot, new Vector3(transform.position.x + 0.1f, transform.position.y, 0), Quaternion.identity);
        bulletCount++;

        if(bulletCount == 3)
        {
            CancelInvoke("BurstFire");
            bulletCount = 0;
        }
    }
}
