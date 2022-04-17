using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fox : MonoBehaviour
{
    public int speed;
    public int startup;
    Text ScoreText;
    int hp;
    bool dead;
    float delay = 0.5f;
    float prevSpeed = 1;
    public Animator animator;

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
            animator.speed = 1;

            if (dead == false)
            {
                if (transform.position.x < 8)
                {

                    transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
                }
                else
                {
                    transform.position = new Vector3(transform.position.x - startup * Time.deltaTime, transform.position.y, transform.position.z);
                }
            }


            if (transform.position.x < -15)
            {
                Destroy(gameObject);
            }
            if (hp < 1 && dead == false)
            {
                
                ScoreText.GetComponent<Score>().addscore(100);
                gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
                animator.SetFloat("Death", Mathf.Abs(1));
                dead = true;
                Invoke("yeet", delay);
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
            hp --;
        }

    }
    void yeet()
    { 
        Destroy(gameObject); 
    }
}
