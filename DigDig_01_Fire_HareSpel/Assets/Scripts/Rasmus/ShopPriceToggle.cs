using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


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

    public void DisableText()
    {
        if (gameObject.GetComponent<Button>().interactable == true)
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
    public void EnableText()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }
}
