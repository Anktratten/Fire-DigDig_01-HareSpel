using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopPriceController : MonoBehaviour
{
    public TextMeshProUGUI pistolCostText;
    public TextMeshProUGUI shotgunCostText;
    public TextMeshProUGUI assaultRifleCostText;

    public GameObject pistolUpgradeButton;
    public GameObject shotgunUpgradeButton;
    public GameObject assaultRifleUpgradeButton;

    public TextMeshProUGUI coinsText;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ShopButtonsToggle()
    {
        pistolCostText.SetText("" + UpgradeController.pistolCost);
        shotgunCostText.SetText("" + UpgradeController.shotgunCost);
        assaultRifleCostText.SetText("" + UpgradeController.assaultRifleCost);

        coinsText.SetText("" + UpgradeController.coins);

        if (UpgradeController.pistolCost <= UpgradeController.coins && UpgradeController.pistolButtonLocked == false)
        {
            pistolUpgradeButton.GetComponent<Button>().interactable = true;
        }
        else
        {
            pistolUpgradeButton.GetComponent<Button>().interactable = false;
            pistolUpgradeButton.GetComponent<ShopPriceToggle>().EnableText();
        }

        if (UpgradeController.shotgunCost <= UpgradeController.coins && UpgradeController.shotgunButtonLocked == false)
        {
            shotgunUpgradeButton.GetComponent<Button>().interactable = true;
        }
        else
        {
            shotgunUpgradeButton.GetComponent<Button>().interactable = false;
            shotgunUpgradeButton.GetComponent<ShopPriceToggle>().EnableText();
        }

        if (UpgradeController.shotgunCost <= UpgradeController.coins && UpgradeController.assaultRifleButtonLocked == false)
        {
            assaultRifleUpgradeButton.GetComponent<Button>().interactable = true;
        }
        else
        {
            assaultRifleUpgradeButton.GetComponent<Button>().interactable = false;
            assaultRifleUpgradeButton.GetComponent<ShopPriceToggle>().EnableText();
        }
    }
}


