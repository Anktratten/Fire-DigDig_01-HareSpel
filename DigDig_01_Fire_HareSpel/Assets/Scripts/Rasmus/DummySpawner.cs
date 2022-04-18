using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummySpawner : MonoBehaviour
{
    public GameObject hunterBossDummy;
    bool spawn = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(spawn == true)
        {
            Instantiate(hunterBossDummy, new Vector3 (transform.position.x, transform.position.y, 0), Quaternion.identity);
            Invoke("SpawnDump", 3);
            spawn = false;
        }
    }
    void SpawnDump()
    {

    }
}
