using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTextController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseEnter()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }
    private void OnMouseExit()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }
}
