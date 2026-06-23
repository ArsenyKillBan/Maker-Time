using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance;

    public int coins = 0;
    public TMP_Text coinsText;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateUI();
    }

    public void AddCoin(int amount)
    {
        coins += amount;
        UpdateUI();
    }

    void UpdateUI()
    {
        if (coinsText != null)
        {
            coinsText.text = "Coins: " + coins;
        }
    }
}
