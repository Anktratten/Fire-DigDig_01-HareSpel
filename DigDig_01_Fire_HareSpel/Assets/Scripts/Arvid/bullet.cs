using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public int bs; //bs = BulletSpeed
    bool walled;
    void Update()
    {
        if (PauseController.isPaused == false)
        {
            if (walled == false)
            {
                transform.position = new Vector3(transform.position.x + bs * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x - bs * Time.deltaTime, transform.position.y, transform.position.z);
            }
            
            if (transform.position.x >= 9)
            { 
                Destroy(gameObject); 
            }
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
        }
    }
}
