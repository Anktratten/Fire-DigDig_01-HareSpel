using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumpBoss : MonoBehaviour
{
    bool transporting = true;
    float speed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= 5 && transporting == true)
        {
            transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
        }
        else if (transform.position.x <= 5)
        {
            transporting = false;
        }
    }
}
