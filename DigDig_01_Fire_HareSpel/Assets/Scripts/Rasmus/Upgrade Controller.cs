using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeController : MonoBehaviour
{
    public static float pistolCooldown = 0.5f;
    public static float shotgunCooldown = 1f;
    public static float assaultRifleCooldown = 0.1f;

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
            //Increase cost
        }
    }
    void ShotgunUpgrade()
    {
        if (coins >= shotgunCost)
        {
            coins = coins - shotgunCost;
            shotgunLevel++;
            //Increase cost
        }
    }
    void AssaultRifleUpgrade()
    {
        if (coins >= assaultRifleCost)
        {
            coins = coins - assaultRifleCost;
            assaultRifleLevel++;
            //Increase cost
        }
    }
}
