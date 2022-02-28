using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    public int speed;
    public int startup;

    // Start is called before the first frame update
    void Start()
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
        }
    }
}
