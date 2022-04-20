using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject menu;
    public GameObject shop;
    public GameObject gameOverMenu;

    bool oneTime;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (NewMovement.liv <= 0 && oneTime == false)
        {
            oneTime = true;
            OpenGameOver();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OpenShopMenu();
        }

    }

    public void OpenShopMenu()
    {
        menu.SetActive(true);
        isPaused = true;
        shop.GetComponent<ShopPriceController>().ShopButtonsToggle();
    }

    public void CloseShopMenu()
    {
        menu.SetActive(false);
        isPaused = false;
    }
    public void OpenGameOver()
    {
        gameOverMenu.SetActive(true);
        NewMovement.liv = 10;
        isPaused = true;
    }
}
