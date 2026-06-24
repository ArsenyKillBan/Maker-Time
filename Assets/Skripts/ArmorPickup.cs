using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorPickup : MonoBehaviour
{
    public int hpBonus = 50; 

    private bool playerNearby = false;
    private PlayerHealth playerHealth;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
            playerHealth = other.GetComponent<PlayerHealth>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
            playerHealth = null;
        }
    }

    private void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.F))
        {
            EquipArmor();
        }
    }

    void EquipArmor()
    {
        if (playerHealth != null)
        {
            playerHealth.Heal(hpBonus);
            Destroy(gameObject);
        }
    }
}
