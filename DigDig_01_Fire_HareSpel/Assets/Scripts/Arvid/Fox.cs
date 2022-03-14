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

    // Start is called before the first frame update
    void Start()
    {
        hp = 1;
        ScoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
    }
    private void OnDestroy()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseController.isPaused == false)
        {
            if (transform.position.x < 8)
            {

                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x - startup * Time.deltaTime, transform.position.y, transform.position.z);
            }
            if (transform.position.x < -15)
            {
                Destroy(gameObject);
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
            hp --;
        }

    }
}
