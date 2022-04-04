using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bullet : MonoBehaviour
{
    public int bs = 7;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x - bs * Time.deltaTime, transform.position.y, transform.position.z);

        if (transform.position.x < -15)
        {
            Destroy(gameObject);
        }
    }
}