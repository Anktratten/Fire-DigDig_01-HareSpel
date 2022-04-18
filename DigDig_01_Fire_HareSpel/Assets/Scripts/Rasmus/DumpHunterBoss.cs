using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumpHunterBoss : MonoBehaviour
{
    bool transporting = true;
    public int speed = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= 7 && transporting == true)
        {
            transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
        }
        else if (transform.position.x <= 7)
        {
            transporting = false;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Dump Boss")
        {
            Destroy(gameObject);
        }
    }
}
