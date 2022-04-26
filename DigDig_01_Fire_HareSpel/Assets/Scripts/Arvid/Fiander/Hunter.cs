using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hunter : MonoBehaviour

{
    public GameObject coin;
    public int speed = 3;
    int hp;
    float delay = 0.5f;
    float prevSpeed = 1;
    bool dead;
    Text ScoreText;
    public GameObject Player;
    public Animator animator;
    public float Cooldown;
    float nextTimeToFire = 0;
    public Transform Shot;

    bool transporting = true;
    bool walking = true;
    // Start is called before the first frame update
    void Start()
    {
        hp = 1;
        ScoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        Player = GameObject.Find("Player_Arvid");
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseController.isPaused == false)
        {
            animator.speed = 1;

            if (dead == false)
            {
                animator.SetFloat("fastnes", Mathf.Abs(0));

                if (transform.position.x >= 7 && transporting == true)
                {
                    transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
                    animator.SetFloat("fastnes", Mathf.Abs(1));
                }
                else if (transform.position.x <= 7)
                {
                    transporting = false;
                    animator.SetFloat("fastnes", Mathf.Abs(1));
                }
                else
                {

                }

                if (transporting == false)
                {
                    if (nextTimeToFire < Time.time)
                    {
                        Instantiate(Shot, new Vector3(transform.position.x + 0.1f, transform.position.y, 0), Quaternion.identity);
                        nextTimeToFire = Time.time + Cooldown;
                    }

                    if (walking == true)
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, transform.position.z);
                        animator.SetFloat("fastnes", Mathf.Abs(1));

                        if (transform.position.y <= -4.7f)
                        {
                            walking = false;
                        }

                    }

                    else if (walking == false)
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);
                        animator.SetFloat("fastnes", Mathf.Abs(1));
                        if (transform.position.y >= 4.7f)
                        {
                            walking = true;
                        }

                    }
                }
            }
        }
        else
        {
            var animator = GetComponent<Animator>();
            prevSpeed = animator.speed;
            animator.speed = 0;
        }

        if (hp < 1 && dead == false)
        { Instantiate(coin, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            dead = true;
            ScoreText.GetComponent<Score>().addscore(200);
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            animator.SetFloat("Death", Mathf.Abs(1));
            
            Invoke("yeet", delay);
        }

    }
    void yeet()
    {
        EnemySpawner.huntersActive--;
        Destroy(gameObject);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            hp -= collision.gameObject.GetComponent<BulletDamage>().damage;
        }
    }
}
