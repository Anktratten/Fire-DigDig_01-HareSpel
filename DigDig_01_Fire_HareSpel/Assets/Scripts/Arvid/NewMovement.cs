using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMovement : MonoBehaviour
{
    public Sprite pistolBunny;
    public Sprite shotgunBunny;
    public Sprite assaultRifleBunny;

    public float borderX = 8.57f;
    public float borderY = 4.7f;

    public int speed;
    public Transform pistolBullet;
    public float coolDown; //Satt i editorn
    float nextTimeToFire = 0;
    string weaponSelect = "Pistol";

    public static float pistolCooldown = 0.5f;
    public static float shotgunCooldown = 1f;
    public static float assaultRifleCooldown = 0.1f;

    public Animator animator;
    bool dead;
    public int liv = 5;
    public float delay = 1f;

    // Start is called before the first frame update
    void Start()
    {
        PistolSelect();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (PauseController.isPaused == false)
        {
            animator.SetFloat("fastnes", Mathf.Abs(0));

            if (dead == false)
            {
                if (Input.GetKey("right") && transform.position.x <= +borderX)
                {
                    transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
                    animator.SetFloat("fastnes", Mathf.Abs(1));
                }


                if (Input.GetKey("left") && transform.position.x >= -borderX)
                {
                    transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
                    animator.SetFloat("fastnes", Mathf.Abs(1));
                }


                if (Input.GetKey("up") && transform.position.y <= +borderY)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);
                    animator.SetFloat("fastnes", Mathf.Abs(1));
                }


                if (Input.GetKey("down") && transform.position.y >= -borderY)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, transform.position.z);
                    animator.SetFloat("fastnes", Mathf.Abs(1));
                }




                //Pistol fire
                if (Input.GetKey("space") && nextTimeToFire < Time.time && weaponSelect == "Pistol")
                {
                    if (UpgradeController.pistolLevel == 1)
                    {
                        Instantiate(pistolBullet, new Vector3(transform.position.x + 0.33f, transform.position.y - 0.1f, 0), Quaternion.identity);
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
                        Instantiate(pistolBullet, new Vector3(transform.position.x + 1, transform.position.y, 0), Quaternion.identity);
                        Instantiate(pistolBullet, new Vector3(transform.position.x + 1, transform.position.y, +1), Quaternion.identity);
                        Instantiate(pistolBullet, new Vector3(transform.position.x + 1, transform.position.y, -1), Quaternion.identity);
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
                    if (UpgradeController.assaultRifleLevel == 1)
                    {
                        Instantiate(pistolBullet, new Vector3(transform.position.x + 0.35f, transform.position.y - 0.127f, 0), Quaternion.identity);
                    }
                    if (UpgradeController.assaultRifleLevel == 2)
                    {
                        //Fire assault rifle level 2
                    }
                    if (UpgradeController.assaultRifleLevel == 3)
                    {
                        //Fire assault rifle level 3
                    }
                    nextTimeToFire = Time.time + assaultRifleCooldown;
                }

                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    PistolSelect();
                 

                }
                if (Input.GetKeyDown(KeyCode.Alpha2) && UpgradeController.shotgunLevel > 0)
                {
                    ShotgunSelect();

                }
                if (Input.GetKeyDown(KeyCode.Alpha3) && UpgradeController.assaultRifleLevel > 0)
                {
                    AssaultRifleSelect();
                   

                }
            }
        }
        else
        {
            animator.SetFloat("fastnes", Mathf.Abs(0));
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && liv >= 0)
        {
            animator.SetFloat("Death", Mathf.Abs(2));
            dead = true;
            gameObject.GetComponent<CircleCollider2D>().isTrigger = true;
            liv--;
            Invoke("paus", delay);
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
    void PistolSelect()
    {
           weaponSelect = "Pistol";
           animator.SetFloat("ar", Mathf.Abs(0));
           animator.SetFloat("pistol", Mathf.Abs(1));
           animator.SetFloat("shotgun", Mathf.Abs(0));
    }
    void ShotgunSelect()
    {
        if (UpgradeController.shotgunLevel >= 1)
        {
            weaponSelect = "Shotgun";
            animator.SetFloat("ar", Mathf.Abs(0));
            animator.SetFloat("pistol", Mathf.Abs(0));
            animator.SetFloat("shotgun", Mathf.Abs(1));
        }
    }
    void AssaultRifleSelect()
    {
        if (UpgradeController.assaultRifleLevel >= 1)
        {
              weaponSelect = "AssaultRifle";
              animator.SetFloat("ar", Mathf.Abs(1));
              animator.SetFloat("pistol", Mathf.Abs(0));
              animator.SetFloat("shotgun", Mathf.Abs(0));
        }
    }
    void paus()
    {
        animator.SetFloat("Death", Mathf.Abs(0));
        dead = false;
        gameObject.GetComponent<CircleCollider2D>().isTrigger = false;
    }
}
