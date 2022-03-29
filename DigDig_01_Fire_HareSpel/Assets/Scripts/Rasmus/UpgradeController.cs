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

    public Sprite maxUpgradeSprite;
    public SpriteState lockedUpgrade;

    // Start is called before the first frame update
    void Start()
    {
        pistolCost = pistolPrices[pistolLevel];
        shotgunCost = shotgunPrices[shotgunLevel];
        assaultRifleCost = assaultRiflePrices[assaultRifleLevel];

        SpriteState lockedUpgradesSpriteStates = new SpriteState();
        lockedUpgradesSpriteStates.disabledSprite = maxUpgradeSprite;
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
            GetComponent<Button>().spriteState = lockedUpgrade;
            pistolUpgradeButton.GetComponent<Button>().interactable = false;
        }
    }
    public void ShotgunUpgrade()
    {
        if (coins >= shotgunCost)
        {
            coins = coins - shotgunCost;
            shotgunLevel++;
            shotgunCost = shotgunPrices[shotgunLevel];
        }
        if (shotgunLevel == 3)
        {
            GetComponent<Button>().spriteState = lockedUpgrade;
            shotgunUpgradeButton.GetComponent<Button>().interactable = false;
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
            GetComponent<Button>().spriteState = lockedUpgrade;
            shotgunUpgradeButton.GetComponent<Button>().interactable = false;
        }
    }
}
