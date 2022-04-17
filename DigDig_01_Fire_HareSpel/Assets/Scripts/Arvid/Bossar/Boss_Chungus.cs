using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_Chungus : MonoBehaviour
{
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
}
