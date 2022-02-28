using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public int speed;
    public Transform bullet;
    public float coolDown = 0.2f;
    float nextTimeToFire = 0;
    string weaponSelect = "Pistol";

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (PauseController.isPaused == false)
        {
            if (Input.GetKey("right"))
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            if (Input.GetKey("left"))
            {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            if (Input.GetKey("up"))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);
            }
            if (Input.GetKey("down"))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, transform.position.z);
            }

            if (Input.GetKey("space") && nextTimeToFire < Time.time)
            {
                Instantiate(bullet, new Vector3(transform.position.x + 1, transform.position.y, 0), Quaternion.identity);
                nextTimeToFire = Time.time + coolDown;
            }
        }
    }
    void PistolSelect()
    {
        weaponSelect = "Pistol";
    }

    void ShotgunSelect()
    {
        weaponSelect = "Shotgun";
    }

    void AutomaticSelect()
    {
        weaponSelect = "Automatic";
    }
}
