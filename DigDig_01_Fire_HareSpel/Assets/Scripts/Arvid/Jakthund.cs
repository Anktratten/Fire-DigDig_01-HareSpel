using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jakthund : MonoBehaviour
{
    public int speed = 3;
    int hp;
    float delay = 0.5f;
    bool dead;
    Text ScoreText;
    public GameObject Player;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        hp = 3;
        ScoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseController.isPaused == false)
        {
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
                animator.SetFloat("Death", Mathf.Abs(1));
                dead = true;
                Invoke("yeet", delay);
            }

            if (transform.position.x < -15)
            {
                Destroy(gameObject);
            }
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            hp--;
        }

    }
    void yeet()
    {
        Destroy(gameObject);
    }
}
