using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hunter : MonoBehaviour

{
    public int speed = 3;
    int hp;
    float delay = 0.5f;
    bool dead;
    Text ScoreText;
    public GameObject Player;
    public Animator animator;
    public float Cooldown;
    float nextTimeToFire = 0;
    public Transform Shot;

    bool transporting = true;
    // Start is called before the first frame update
    void Start()
    {
        hp = 1;
        ScoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseController.isPaused == false)
        {
            if (dead == false)
            {
                animator.SetFloat("fastnes", Mathf.Abs(0));

                if (transform.position.x <= 7 && transporting == true)
                {
                    transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y + speed * Time.deltaTime, transform.position.z);
                    animator.SetFloat("fastnes", Mathf.Abs(1));
                }
                else if (transform.position.x >= 7)
                {
                    transporting = false;
                    transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y - speed * Time.deltaTime, transform.position.z);
                    animator.SetFloat("fastnes", Mathf.Abs(1));
                }
                else
                {

                }

                if (nextTimeToFire < Time.time)
                {
                    Instantiate(Shot, new Vector3(transform.position.x + 0.1f, transform.position.y, 0), Quaternion.identity);
                    nextTimeToFire = Time.time + Cooldown;
                }

                if (Player.transform.position.y > transform.position.y)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);
                    animator.SetFloat("fastnes", Mathf.Abs(1));
                }

                else if (Player.transform.position.y < transform.position.y)
                { 
                    transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, transform.position.z);
                    animator.SetFloat("fastnes", Mathf.Abs(1));
                }
                else
                {
                   
                }
            }
        }
        if (hp < 1 && dead == false)
        {
            dead = true;
            ScoreText.GetComponent<Score>().addscore(100);
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            animator.SetFloat("Death", Mathf.Abs(1));
            
            Invoke("yeet", delay);
        }

    }
    void yeet()
    {
        Destroy(gameObject);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            hp--;
        }

    }
}