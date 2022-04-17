using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_Chungus : MonoBehaviour
{
    public float speed;
    public int hp;
    float delay = 0.5f;
    float prevSpeed = 1;
    bool dead;
    Text ScoreText;
    public GameObject Player;
    public Animator animator;
    public float Cooldown;
    float nextTimeToFire = 0;
    public Transform Shot;

    // Start is called before the first frame update
    void Start()
    {
        ScoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
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
                if (transform.position.x >= 6)
                {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y/* + speed * Time.deltaTime*/, transform.position.z);
                animator.SetFloat("fastnes", Mathf.Abs(1));
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
        {
            dead = true;
            ScoreText.GetComponent<Score>().addscore(2000);
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            animator.SetFloat("Death", Mathf.Abs(1));

            Invoke("yeet", delay);
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
