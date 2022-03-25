using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopPriceToggle : MonoBehaviour
{
    public TextMeshProUGUI pistolCostText;
    public TextMeshProUGUI shotgunCostText;
    public TextMeshProUGUI assaultRifleCostText;

    public TextMeshProUGUI coinsText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pistolCostText.SetText("" + UpgradeController.pistolCost);
        shotgunCostText.SetText("" + UpgradeController.shotgunCost);
        assaultRifleCostText.SetText("" + UpgradeController.assaultRifleCost);

        coinsText.SetText("" + UpgradeController.coins);
    }



}
