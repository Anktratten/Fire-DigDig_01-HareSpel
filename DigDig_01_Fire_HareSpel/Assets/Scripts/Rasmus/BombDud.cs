using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDud : MonoBehaviour
{
    public RuntimeAnimatorController bomb;
    Animator animator;
    float moveSpeed = 8;
    float transportSpeed = 10;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PauseController.isPaused == false)
        {
            if (transform.position.y > 0)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime);
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (PauseController.isPaused == false)
        {
            if (collision.gameObject.tag == "Bullet")
            {
                InvokeRepeating("moveRight", 0, 0.1f * Time.deltaTime);
                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.name == "Dump Wall(Clone)")
            {
                CancelInvoke("moveRight");
                collision.gameObject.GetComponent<DumpWall>().DestroyWall();
                animator.runtimeAnimatorController = bomb;
                Invoke("Destroy", 0.35f);
            }
        }

    }
    void moveRight()
    {
        transform.position = new Vector3(transform.position.x + transportSpeed * Time.deltaTime, transform.position.y);
    }
        void Destroy()
    {
        Destroy(gameObject);
    }
}
