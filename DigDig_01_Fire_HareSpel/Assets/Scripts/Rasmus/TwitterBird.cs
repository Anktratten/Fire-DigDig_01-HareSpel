using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwitterBird : MonoBehaviour
{
    public GameObject player;
    bool transporting = true;
    float speed = 6;
    float rotationSpeed = 1;
    bool still = false;
    Vector3 attackTarget;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player_Arvid");
    }

    // Update is called once per frame
    void Update()
    {
        if (transporting == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(5, 3, 0), speed * Time.deltaTime);
        }
        else
        {
            if (still == false)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
                gameObject.GetComponent<SpriteRenderer>().flipY = true;
                Vector3 target = player.transform.position;
                target.z = 0;

                Vector3 ownPosition = transform.position;
                target.x = target.x - ownPosition.x;
                target.y = target.y - ownPosition.y;

                float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

            }
        }
        if (transform.position.x == 5 && transform.position.y == 3 && transporting == true)
        {
            transporting = false;

        }
    }
    void LaunchBird()
    {
        still = true;
        transform.position += transform.forward * Time.deltaTime * 6;
    }
}
