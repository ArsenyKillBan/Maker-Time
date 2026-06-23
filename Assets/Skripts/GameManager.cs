using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int kills = 0;
    public TMP_Text killsText;

    void Awake()
    {
        Instance = this;
    }

    public void AddKill()
    {
        kills++;

        if (killsText != null)
            killsText.text = "Kills: " + kills;
    }
}
