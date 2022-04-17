using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Fiander : MonoBehaviour
{
    float nextTimeToFire = 0;
    public Transform Shot;
    public float Cooldown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseController.isPaused == false)
        {
            if (nextTimeToFire < Time.time)
            {
                Instantiate(Shot, new Vector3(transform.position.x + 0.1f, transform.position.y, 0), Quaternion.identity);
                nextTimeToFire = Time.time + Cooldown;
            }
        }
    }
}
