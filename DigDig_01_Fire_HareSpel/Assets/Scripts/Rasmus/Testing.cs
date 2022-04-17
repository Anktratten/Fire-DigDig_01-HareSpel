using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            InvokeRepeating("testing", 0, 1);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CancelInvoke("testing");
        }
    }

    void testing()
    {
        Debug.Log("ducks");
    }
}
