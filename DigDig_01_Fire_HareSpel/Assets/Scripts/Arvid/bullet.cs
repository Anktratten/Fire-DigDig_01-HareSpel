using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public int bs; //bs = BulletSpeed
    public float shotgun;
    bool walled;
    private void Start()
    {
        bs = 10;
    }
    void Update()
    {
        if (PauseController.isPaused == false)
        {
            if (walled == false)
            {
                transform.position = new Vector3(transform.position.x + bs * Time.deltaTime, transform.position.y + shotgun * Time.deltaTime, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x - bs * Time.deltaTime, transform.position.y, transform.position.z);
            }
         }   
            if (transform.position.x >= 9)
            { 
                Destroy(gameObject); 
            }

            if (transform.position.x < -15)
            {
                Destroy(gameObject);
            }
        
    }   
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "wall")
        {
            walled = true;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
            gameObject.tag = "Enemy";
        }
    }
}
