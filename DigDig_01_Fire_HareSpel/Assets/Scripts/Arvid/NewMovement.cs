using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewMovement : MonoBehaviour
{
    public Sprite pistolBunny;
    public Sprite shotgunBunny;
    public Sprite assaultRifleBunny;

    public float borderX = 8.57f;
    public float borderY = 4.7f;

    public int speed;
    public float coolDown; //Satt i editorn
    float nextTimeToFire = 0;
    string weaponSelect = "Pistol";

    float[] pistolCooldown = { 0.75f, 0.5f, 0.25f };
    float[] shotgunCooldown = { 2f, 1.5f, 1f };
    float[] assaultRifleCooldown = { 0.25f, 0.20f, 0.15f };

    public GameObject pistolBullet;
    public GameObject shotgunBullet;
    public GameObject shotgun_u1; //up1
    public GameObject shotgun_n1; //ner1
    public GameObject shotgun_u2;
    public GameObject shotgun_n2;
    public GameObject assaultRifleBullet;

    public Animator animator;
    float prevSpeed = 1;
    bool dead;
    public static int liv = 10;
    public float delay = 1f;

    float respawn_time = 1.8f;
    bool respawning = false;

    Text lives;

    // Start is called before the first frame update
    void Start()
    {
        PistolSelect();
        lives  = GameObject.Find("Lives Text").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (PauseController.isPaused == false)
        {
            animator.SetFloat("fastnes", Mathf.Abs(0));
            animator.speed = 1;

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
                if (respawning == false)
                {
                    //Pistol fire
                    if (Input.GetKey("space") && nextTimeToFire < Time.time && weaponSelect == "Pistol")
                    {
                        if (UpgradeController.pistolLevel == 1)
                        {
                            Instantiate(pistolBullet, new Vector3(transform.position.x + 0.21f, transform.position.y - 0.11f), Quaternion.identity);
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
                            nextTimeToFire = Time.time + pistolCooldown[2];
                        }
                    }
                    //Shotgun fire
                    if (Input.GetKey("space") && nextTimeToFire < Time.time && weaponSelect == "Shotgun")
                    {
                        if (UpgradeController.shotgunLevel == 1)
                        {
                            Instantiate(shotgun_u1, new Vector3(transform.position.x + 1, transform.position.y +0.1f, 0), Quaternion.identity);
                            Instantiate(shotgun_n1, new Vector3(transform.position.x + 1, transform.position.y -0.1f, 0), Quaternion.identity);
                            nextTimeToFire = Time.time + shotgunCooldown[0];
                        }
                        else if (UpgradeController.shotgunLevel == 2)
                        {
                            Instantiate(shotgunBullet, new Vector3(transform.position.x + 1, transform.position.y, 0), Quaternion.identity);
                            Instantiate(shotgun_u1, new Vector3(transform.position.x + 1, transform.position.y + 0.1f, 0), Quaternion.identity);
                            Instantiate(shotgun_n1, new Vector3(transform.position.x + 1, transform.position.y - 0.1f, 0), Quaternion.identity);
                            nextTimeToFire = Time.time + shotgunCooldown[1];
                        }
                        else if (UpgradeController.shotgunLevel == 3)
                        {
                            Instantiate(shotgunBullet, new Vector3(transform.position.x + 1, transform.position.y, 0), Quaternion.identity);
                            Instantiate(shotgun_u1, new Vector3(transform.position.x + 1, transform.position.y + 0.1f, 0), Quaternion.identity);
                            Instantiate(shotgun_n1, new Vector3(transform.position.x + 1, transform.position.y - 0.1f, 0), Quaternion.identity);
                            Instantiate(shotgun_u2, new Vector3(transform.position.x + 1, transform.position.y + 0.2f, 0), Quaternion.identity);
                            Instantiate(shotgun_n2, new Vector3(transform.position.x + 1, transform.position.y - 0.2f, 0), Quaternion.identity);
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
            var animator = GetComponent<Animator>();
            prevSpeed = animator.speed;
            animator.speed = 0;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && liv > 0 || collision.gameObject.tag == "Enemy_bullet" && liv > 0)
        {
            animator.SetFloat("Death", Mathf.Abs(2));
            dead = true;
            gameObject.GetComponent<CircleCollider2D>().isTrigger = true;
            liv--;
            Invoke("paus", delay);
            Invoke("spawn", respawn_time);
        }
        else if (collision.gameObject.tag == "Enemy"|| collision.gameObject.tag == "Enemy_bullet")
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
        animator.SetFloat("respawn", Mathf.Abs(1));
    }
    void spawn()
    {
        gameObject.GetComponent<CircleCollider2D>().isTrigger = false;
        animator.SetFloat("respawn", Mathf.Abs(0));
    }
}
