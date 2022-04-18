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
        if (UpgradeController.pistolButtonLocked == false && gameObject.name == "Pistol upgrade Button")
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
        if (UpgradeController.pistolButtonLocked == false && gameObject.name == "Shotgun upgrade Button")
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
        if (UpgradeController.pistolButtonLocked == false && gameObject.name == "Assault Rifle Upgrade Button")
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
