using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShopPriceToggle : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void DisableText()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }
    private void EnableText()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }
}
