using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumpWall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            collision.gameObject.GetComponent<SpriteRenderer>().flipY = true;
            collision.gameObject.tag = "Enemy";
            collision.gameObject.GetComponent<bullet>().bs *= -1;
        }
    }
    public void DestroyWall()
    {
        Destroy(gameObject);
        DumpBoss.wallUp = false;
    }
}
