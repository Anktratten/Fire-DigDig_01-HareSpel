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
    
    
        public int value = 1;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            // if the pickup object has collided with the player,
            if (collision.CompareTag("Player"))
            {
                // if the pickup type is 'Coin'
                if (type == PickupType.Coin)
                {
                }
                // if the pickup type is 'Health'
                else if (type == PickupType.Health)
                {
                }
            }
        }
    



}
