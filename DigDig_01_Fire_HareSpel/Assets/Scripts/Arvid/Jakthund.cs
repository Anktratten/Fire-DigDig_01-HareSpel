using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jakthund : MonoBehaviour
{
    int speed = 3;
    int plats = 5;
    int hp = 3;
    Text ScoreText;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        if (PauseController.isPaused == false)
        {
            if (Player.transform.position.y > transform.position.y)
            {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y + plats * Time.deltaTime, transform.position.z);
            }

            if (Player.transform.position.y < transform.position.y)
            {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y - plats * Time.deltaTime, transform.position.z);
            }

            if (hp < 1)
            {
                Destroy(gameObject);
                ScoreText.GetComponent<Score>().addscore(100);
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
}
