using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public int speed;
    public Transform pistolBullet;
    public float coolDown; //Satt i editorn
    float nextTimeToFire = 0;
    string weaponSelect = "Pistol";

    public static float pistolCooldown = 0.5f;
    public static float shotgunCooldown = 1f;
    public static float assaultRifleCooldown = 0.1f;
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

            //Pistol fire
            if (Input.GetKey("space") && nextTimeToFire < Time.time && weaponSelect == "Pistol")
            {
                if (UpgradeController.pistolLevel == 1)
                {
                    Instantiate(pistolBullet, new Vector3(transform.position.x + 1, transform.position.y, 0), Quaternion.identity);
                }
                else if (UpgradeController.pistolLevel == 2)
                {
                    //Pistol fire level 2
                }
                else if (UpgradeController.pistolLevel == 3)
                {
                    //Pistol fire level 3
                }
                nextTimeToFire = Time.time + pistolCooldown;
            }
            //Shotgun fire
            if (Input.GetKey("space") && nextTimeToFire < Time.time && weaponSelect == "Shotgun")
            {
                if (UpgradeController.shotgunLevel == 1)
                {
                    //Shotgun fire level 1
                }
                else if (UpgradeController.shotgunLevel == 2)
                {
                    //Shotgun fire level 2
                }
                else if (UpgradeController.shotgunLevel == 3)
                {
                    //Shotgun fire level 3
                }
                nextTimeToFire = Time.time + shotgunCooldown;
            }
            //AssaultRifle fire
            if (Input.GetKey("space") && nextTimeToFire < Time.time && weaponSelect == "AssaultRifle")
            {
                //Fire assault rifle
                nextTimeToFire = Time.time + assaultRifleCooldown;
            }
        }
    }
    void PistolSelect()
    {
        weaponSelect = "Pistol";
    }
    void ShotgunSelect()
    {
        if (UpgradeController.shotgunLevel >= 1)
        {
            weaponSelect = "Shotgun";
        }
    }
    void AssaultRifleSelect()
    {
        if (UpgradeController.assaultRifleLevel >= 1)
        {
            weaponSelect = "AssaultRifle";
        }
    }
}
