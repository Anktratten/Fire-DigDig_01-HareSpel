using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeController : MonoBehaviour
{
    public static int pistolLevel = 1;
    public static int shotgunLevel = 0;
    public static int assaultRifleLevel = 0;

    public static int coins = 0;

    int pistolCost;
    int shotgunCost;
    int assaultRifleCost;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PistolUpgrade()
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
    void ShotgunUpgrade()
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
    void AssaultRifleUpgrade()
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
