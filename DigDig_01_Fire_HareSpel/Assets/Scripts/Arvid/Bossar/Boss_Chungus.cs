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
    public static bool dead;
    Text ScoreText;
    public GameObject Player;
    public Animator animator;

    Vector3 targetLocation;

    float [] positions = new float[4];
    float current_location;

    public float Cooldown;
    float nextTimeToFire = 0;

    float Animal_spawn = 10;
    float animal_cooldown = 0;

    public float Walk_cooldown;
    float walk = 0;

    public Transform Shot;
    public Transform Shotgun_down;
    public Transform Shotgun_up;
    public Transform spread_down;
    public Transform spread_up;

    public Transform fiande_nere;
    public Transform fiande_uppe;

    public Transform Djur;

    bool smtn = false;

    // Start is called before the first frame update
    void Start()
    {
        ScoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        positions[1] = -3f;
        positions[2] = 0f;
        positions[3] = 3f;
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
                animator.SetFloat("shoot", Mathf.Abs(0));

                if (transform.position.x >= 6)
                {
                  transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y/* + speed * Time.deltaTime*/, transform.position.z);
                  animator.SetFloat("fastnes", Mathf.Abs(1));
                  Instantiate(fiande_nere, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity, gameObject.transform);
                  Instantiate(fiande_nere, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity, gameObject.transform);
                  Instantiate(fiande_uppe, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity, gameObject.transform);
                  Instantiate(fiande_uppe, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity, gameObject.transform);
                }
                else
                {
                    deez();
                    animator.SetFloat("shoot", Mathf.Abs(1));

                    if (animal_cooldown <Time.time && smtn == true)
                    {
                        Instantiate(Djur, new Vector3(transform.position.x + 6.0f, transform.position.y - 5.0f), Quaternion.identity);
                        Instantiate(Djur, new Vector3(transform.position.x + 6.0f, transform.position.y + 5.0f), Quaternion.identity);

                        animal_cooldown = Time.time + Animal_spawn;

                    }
                    else if (nextTimeToFire < Time.time && smtn == true)
                    {
                        Instantiate(Shot, new Vector3(transform.position.x + -1.0f, transform.position.y, -0.1f), Quaternion.identity);
                        Instantiate(Shotgun_down, new Vector3(transform.position.x + -0.9f, transform.position.y, -0.1f), Quaternion.identity);
                        Instantiate(Shotgun_up, new Vector3(transform.position.x + -0.9f, transform.position.y, 0.1f), Quaternion.identity);
                        Instantiate(spread_down, new Vector3(transform.position.x + -0.8f, transform.position.y, -0.1f), Quaternion.identity);
                        Instantiate(spread_up, new Vector3(transform.position.x + -0.8f, transform.position.y, 0.1f), Quaternion.identity);

                        animator.SetFloat("shoot", Mathf.Abs(1));

                        nextTimeToFire = Time.time + Cooldown;
                    }
                    if (smtn == false)
                    {
                        InvokeRepeating("randomizer", 0, Walk_cooldown);
                        smtn = true;
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
            int result = Random.Range(1, 4);
            if (result == 1)
            {
                targetLocation = new Vector3(transform.position.x, positions[1], transform.position.z);
                animator.SetFloat("fastnes", Mathf.Abs(1));
            }
            else if (result == 2)
            {
                targetLocation = new Vector3(transform.position.x, positions[2], transform.position.z);
                animator.SetFloat("fastnes", Mathf.Abs(1));
            }
            else if (result == 3)
            {
                targetLocation = new Vector3(transform.position.x, positions[3], transform.position.z);
                animator.SetFloat("fastnes", Mathf.Abs(1));
            }
        } while (current_location == targetLocation.y);
    }
}
