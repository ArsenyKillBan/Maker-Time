using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public string playerTag = "Player";
    public int coinValue = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            
            if (CoinManager.Instance != null)
            {
                CoinManager.Instance.AddCoin(coinValue);
            }

            
            Destroy(gameObject);
        }
    }
}


