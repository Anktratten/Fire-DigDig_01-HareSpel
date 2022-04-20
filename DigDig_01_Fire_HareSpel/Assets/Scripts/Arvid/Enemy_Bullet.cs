using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bullet : MonoBehaviour
{
    public int bs = 7; //bs = Bullet Speed
    public float shotgun;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (PauseController.isPaused == false)
        {
            transform.position = new Vector3(transform.position.x - bs * Time.deltaTime, transform.position.y + shotgun * Time.deltaTime, transform.position.z);
        }
        if (transform.position.x < -15)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }
}
