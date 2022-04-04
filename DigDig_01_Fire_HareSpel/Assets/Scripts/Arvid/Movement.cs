using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public Sprite pistolBunny;
    public Sprite shotgunBunny;
    public Sprite assaultRifleBunny;

    public float borderX = 8.57f;
    public float borderY = 4.7f;

    public int speed;
    float nextTimeToFire = 0;
    string weaponSelect = "Pistol";

    float[] pistolCooldown = {0.75f, 0.5f, 0.25f};
    float[] shotgunCooldown = {2f, 1.5f, 1f};
    float[] assaultRifleCooldown = {0.25f, 0.20f, 0.15f};

    public GameObject pistolBullet;
    public GameObject shotgunBullet;
    public GameObject assaultRifleBullet;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(pistolCooldown[0]);
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseController.isPaused == false)
        {
            if (Input.GetKey("right") && transform.position.x <= +borderX)
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            if (Input.GetKey("left") && transform.position.x >= -borderX)
            {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            if (Input.GetKey("up") && transform.position.y <= +borderY)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);
            }
            if (Input.GetKey("down") && transform.position.y >= -borderY)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, transform.position.z);
            }

            //Pistol fire
            if (Input.GetKey("space") && nextTimeToFire < Time.time && weaponSelect == "Pistol")
            {
                if (UpgradeController.pistolLevel == 1)
                {
                    Instantiate(pistolBullet, new Vector3(transform.position.x + 0.21f, transform.position.y -0.11f), Quaternion.identity);
                    nextTimeToFire = Time.time + pistolCooldown[0];
                }
                else if (UpgradeController.pistolLevel == 2)
                {
                    Instantiate(pistolBullet, new Vector3(transform.position.x + 0.21f, transform.position.y - 0.11f), Quaternion.identity);
                    nextTimeToFire = Time.time + pistolCooldown[1];
                }
                else if (UpgradeController.pistolLevel == 3)
                {
                    Instantiate(pistolBullet, new Vector3(transform.position.x + 0.21f, transform.position.y - 0.11f), Quaternion.identity);
                    nextTimeToFire = Time.time + pistolCooldown [2];
                }
            }
            //Shotgun fire
            if (Input.GetKey("space") && nextTimeToFire < Time.time && weaponSelect == "Shotgun")
            {
                if (UpgradeController.shotgunLevel == 1)
                {
                    Instantiate(shotgunBullet, new Vector3(transform.position.x + 1, transform.position.y, + 1), Quaternion.identity);
                    Instantiate(shotgunBullet, new Vector3(transform.position.x + 1, transform.position.y, - 1), Quaternion.identity);
                    nextTimeToFire = Time.time + shotgunCooldown[0];
                }
                else if (UpgradeController.shotgunLevel == 2)
                {
                    Instantiate(shotgunBullet, new Vector3(transform.position.x + 1, transform.position.y, +1), Quaternion.identity);
                    Instantiate(shotgunBullet, new Vector3(transform.position.x + 1, transform.position.y, +0), Quaternion.identity);
                    Instantiate(shotgunBullet, new Vector3(transform.position.x + 1, transform.position.y, -1), Quaternion.identity);
                    nextTimeToFire = Time.time + shotgunCooldown[1];
                }
                else if (UpgradeController.shotgunLevel == 3)
                {
                    Instantiate(shotgunBullet, new Vector3(transform.position.x + 1, transform.position.y, +2), Quaternion.identity);
                    Instantiate(shotgunBullet, new Vector3(transform.position.x + 1, transform.position.y, +1), Quaternion.identity);
                    Instantiate(shotgunBullet, new Vector3(transform.position.x + 1, transform.position.y, +0), Quaternion.identity);
                    Instantiate(shotgunBullet, new Vector3(transform.position.x + 1, transform.position.y, -1), Quaternion.identity);
                    Instantiate(shotgunBullet, new Vector3(transform.position.x + 1, transform.position.y, -2), Quaternion.identity);
                    nextTimeToFire = Time.time + shotgunCooldown[2];
                }
            }
            //AssaultRifle fire
            if (Input.GetKey("space") && nextTimeToFire < Time.time && weaponSelect == "AssaultRifle")
            {
                if (UpgradeController.assaultRifleLevel == 1)
                {
                    Instantiate(assaultRifleBullet, new Vector3(transform.position.x + 1, transform.position.y, 0), Quaternion.identity);
                    nextTimeToFire = Time.time + assaultRifleCooldown[0];
                }
                if (UpgradeController.assaultRifleLevel == 2)
                {
                    Instantiate(assaultRifleBullet, new Vector3(transform.position.x + 1, transform.position.y, 0), Quaternion.identity);
                    nextTimeToFire = Time.time + assaultRifleCooldown[1];
                }
                if (UpgradeController.assaultRifleLevel == 3)
                {
                    Instantiate(assaultRifleBullet, new Vector3(transform.position.x + 1, transform.position.y, 0), Quaternion.identity);
                    nextTimeToFire = Time.time + assaultRifleCooldown[2];
                }
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                PistolSelect();
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                ShotgunSelect();
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                AssaultRifleSelect();
            }
        }
    }
    void PistolSelect()
    {
        weaponSelect = "Pistol";
        this.gameObject.GetComponent<SpriteRenderer>().sprite = pistolBunny;
    }
    void ShotgunSelect()
    {
        if (UpgradeController.shotgunLevel >= 1)
        {
            weaponSelect = "Shotgun";
            this.gameObject.GetComponent<SpriteRenderer>().sprite = shotgunBunny;
        }
    }
    void AssaultRifleSelect()
    {
        if (UpgradeController.assaultRifleLevel >= 1)
        {
            weaponSelect = "AssaultRifle";
            this.gameObject.GetComponent<SpriteRenderer>().sprite = assaultRifleBunny;
        }
    }
}