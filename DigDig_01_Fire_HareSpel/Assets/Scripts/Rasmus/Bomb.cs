using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    float moveSpeed = 8;
    bool exploding = false;
    BoxCollider2D myCollider;
    Animator animator;
    public RuntimeAnimatorController bomb;

    // Start is called before the first frame update
    void Start()
    {
        myCollider = gameObject.GetComponent<BoxCollider2D>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime);
        }
        else if (exploding == false)
        {
            gameObject.tag = "Enemy";
            animator.runtimeAnimatorController = bomb;
            exploding = true;
            myCollider.size = new Vector2(0.75f, 0.75f);
            Invoke("Destroy", 0.35f);
        }
    }
    void Destroy()
    {
        Destroy(gameObject);
    }
}
