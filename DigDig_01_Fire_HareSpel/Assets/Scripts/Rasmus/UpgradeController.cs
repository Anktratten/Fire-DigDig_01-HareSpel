using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeController : MonoBehaviour
{
    public static int pistolLevel = 1;
    public static int shotgunLevel = 1;
    public static int assaultRifleLevel = 1;

    public static int coins = 999;

    public static int pistolCost = 200;
    public static int shotgunCost = 300;
    public static int assaultRifleCost = 400;

    public GameObject pistolUpgradeButton;
    public GameObject shotgunUpgradeButton;
    public GameObject assaultRifleUpgradeButton;



    public SpriteState maxUpgrade;

    // Start is called before the first frame update
    void Start()
    {
        
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
            //Decrease cooldown
            //Increase cost
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
            shotgunLevel++;
            //Decrease cooldown
            //Increase cost
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
            //Decrease cooldown
            //Increase cost
        }
        if (assaultRifleLevel == 3)
        {
            //Lock upgrades
        }
    }
}
