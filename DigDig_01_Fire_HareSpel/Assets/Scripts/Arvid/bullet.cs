using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public int bs;
    void Update()
    {
        if (PauseController.isPaused == false)
        {
            transform.position = new Vector3(transform.position.x + bs * Time.deltaTime, transform.position.y, transform.position.z);
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

        }
    }
}
