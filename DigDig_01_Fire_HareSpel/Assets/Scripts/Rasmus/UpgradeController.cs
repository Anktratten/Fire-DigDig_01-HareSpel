using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeController : MonoBehaviour
{
    public static int pistolLevel = 1;
    public static int shotgunLevel = 0;
    public static int assaultRifleLevel = 0;

    public static int coins = 999;

    public static int pistolCost;
    public static int shotgunCost;
    public static int assaultRifleCost;

    public GameObject pistolUpgradeButton;
    public GameObject shotgunUpgradeButton;
    public GameObject assaultRifleUpgradeButton;

    int[] pistolPrices = {0, 100, 150, 250};
    int[] shotgunPrices = { 150, 200, 280, 400 };
    int[] assaultRiflePrices = { 180, 220, 320, 450 };


    public SpriteState maxUpgrade;

    // Start is called before the first frame update
    void Start()
    {
        pistolCost = pistolPrices[pistolLevel + 1];
        shotgunCost = shotgunPrices[shotgunLevel + 1];
        assaultRifleCost = assaultRiflePrices[assaultRifleLevel + 1];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PistolUpgrade()
    {
        if (coins >= pistolCost)
        {
            coins = coins - pistolCost;
            pistolLevel++;
            pistolCost = pistolPrices[pistolLevel];
        }
        if (pistolLevel == 3)
        {
            //Lock upgrades
        }
    }
    public void ShotgunUpgrade()
    {
        if (coins >= shotgunCost)
        {
            coins = coins - shotgunCost;
            shotgunCost = shotgunPrices[shotgunLevel];
        }
        if (shotgunLevel == 3)
        {
            //Lock upgrades
        }
    }
    public void AssaultRifleUpgrade()
    {
        if (coins >= assaultRifleCost)
        {
            coins = coins - assaultRifleCost;
            assaultRifleLevel++;
            assaultRifleCost = assaultRiflePrices[assaultRifleLevel];
        }
        if (assaultRifleLevel == 3)
        {
            //Lock upgrades
        }
    }
}
