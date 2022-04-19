using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDud : MonoBehaviour
{
    float moveSpeed = 8;
    float transportSpeed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            InvokeRepeating("moveRight", 0, 0.1f * Time.deltaTime);
        }
        else
        {
            collision.gameObject.GetComponent<DumpWall>().DestroyWall();
            //animation skit
            Destroy(gameObject);
            Debug.Log(collision.gameObject.name);
        }
        Debug.Log(collision.gameObject.name);
    }
    void moveRight()
    {
        transform.position = new Vector3(transform.position.x + transportSpeed * Time.deltaTime, transform.position.y);
    }
}
