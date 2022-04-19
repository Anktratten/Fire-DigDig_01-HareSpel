using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Jakthund_Weak : MonoBehaviour
{
    public int speed = 3;
    int hp;
    float delay = 0.5f;
    bool dead;
    Text ScoreText;
    GameObject Player;
    public Animator animator;
    float prevSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        hp = 1;
        ScoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        Player = GameObject.Find("Player_Arvid");
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseController.isPaused == false)

        {
            animator.speed = 1;

            if (dead == false)
            {
                if (Player.transform.position.y > transform.position.y)
                {
                    transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y + speed * Time.deltaTime, transform.position.z);
                }

                if (Player.transform.position.y < transform.position.y)
                {
                    transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y - speed * Time.deltaTime, transform.position.z);
                }
            }
            if (hp < 1 && dead == false)
            {
                ScoreText.GetComponent<Score>().addscore(100);
                gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
                animator.SetFloat("Death", Mathf.Abs(1));
                dead = true;
                Invoke("yeet", delay);
            }

            if (transform.position.x < -15)
            {
                Destroy(gameObject);
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
        if (collision.gameObject.tag == "Bullet")
        {
            hp -= collision.gameObject.GetComponent<BulletDamage>().damage;
        }

    }
    void yeet()
    {
        Destroy(gameObject);
    }
}
