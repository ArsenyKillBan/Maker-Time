using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DamageScript : MonoBehaviour
{
    public int damageAmount = 20;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            EnemyScript enemy =
                other.GetComponent<EnemyScript>();

            if (enemy != null)
            {
                enemy.TakeDamage(damageAmount);
            }
        }
    }
}