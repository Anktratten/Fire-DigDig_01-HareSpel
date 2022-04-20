using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumpAirstrike : MonoBehaviour
{
    public GameObject bomb;
    int movementSpeed = 10;
    public GameObject bombDud;
    public bool isDud = false;
    bool bombDropped;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (PauseController.isPaused == false)
        {
            transform.position = new Vector3(transform.position.x - movementSpeed * Time.deltaTime, transform.position.y, 0);

            if (transform.position.x < -10)
            {
                Destroy(gameObject);
            }
            if (transform.position.x < 0 && bombDropped == false)
            {
                DropBomb();
            }
        }

    }
    void DropBomb()
    {
        if (isDud == false)
        {
            Instantiate(bomb, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);

        }
        else
        {
            Instantiate(bombDud, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        }
        bombDropped = true;
    }
}
