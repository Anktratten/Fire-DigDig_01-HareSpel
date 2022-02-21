using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    void Update()
    {
        {
            transform.position = new Vector3(transform.position.x + 10.0f * Time.deltaTime, transform.position.y, transform.position.z);
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
