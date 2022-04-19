using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public enum PickupType
    {
        Coin,
        Health
    }
    /* public int score;
    public void AddScore(int amount)
    {
        score += amount;
    }
    */
    public void AddCoins(int amount)
    {
        UpgradeController.coins += amount;
        // To-do: update the UI
    }
        private void OnTriggerEnter2D(Collider2D collision)
        {
                // if the pickup type is 'Coin'
                if (collision.gameObject.tag == "Coin")
                {
                UpgradeController.coins += 20;
                Destroy(collision.gameObject);
                }
                // if the pickup type is 'Health'
                else if (collision.gameObject.tag == "Health")
                {
                NewMovement.liv++;
                Destroy(collision.gameObject);
            }
            }
        }
    




