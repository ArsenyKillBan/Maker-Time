using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    public int damageAmount = 20;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "enemy")
        {
            other.GetComponent<EnemyScript>().TakeDamage(damageAmount);
        }
    }
}