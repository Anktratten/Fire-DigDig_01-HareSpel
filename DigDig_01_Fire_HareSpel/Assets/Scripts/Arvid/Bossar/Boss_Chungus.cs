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

    Vector3 targetLocation;

    float [] positions;
    float current_location;

    public float Cooldown;
    float nextTimeToFire = 0;

    public float Walk_cooldown;
    float walk = 0;

    public Transform Shot;
    public Transform Shotgun_down;
    public Transform Shotgun_up;
    public Transform spread_down;
    public Transform spread_up;


    // Start is called before the first frame update
    void Start()
    {
        ScoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        positions[1] = -3;
        positions[2] = 0;
        positions[3] = 3;
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
                else
                {
                    animator.SetFloat("shoot", Mathf.Abs(1));
                    if (nextTimeToFire < Time.time)
                    {
                        Instantiate(Shot, new Vector3(transform.position.x + -1.0f, transform.position.y, -0.1f), Quaternion.identity);
                        Instantiate(Shotgun_down, new Vector3(transform.position.x + -0.9f, transform.position.y, -0.1f), Quaternion.identity);
                        Instantiate(Shotgun_up, new Vector3(transform.position.x + -0.9f, transform.position.y, 0.1f), Quaternion.identity);
                        Instantiate(spread_down, new Vector3(transform.position.x + -0.8f, transform.position.y, -0.1f), Quaternion.identity);
                        Instantiate(spread_up, new Vector3(transform.position.x + -0.8f, transform.position.y, 0.1f), Quaternion.identity);

                        animator.SetFloat("shoot", Mathf.Abs(1));

                        nextTimeToFire = Time.time + Cooldown;
                    }

                    InvokeRepeating("randomizer", 0, Walk_cooldown);
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
    void deez()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetLocation, speed * Time.deltaTime);
    }
    private void randomizer()
    {
        current_location = targetLocation.y;
        do
        {
            int result = Random.Range(1, 3);
            if (result == 1)
            {
                targetLocation = new Vector3(transform.position.x, positions[1], transform.position.z);
            }
            else if (result == 2)
            {
                targetLocation = new Vector3(transform.position.x, positions[2], transform.position.z);
            }
            else if (result == 3)
            {
                targetLocation = new Vector3(transform.position.x, positions[3], transform.position.z);
            }
        } while (current_location == targetLocation.y);
    }
}
