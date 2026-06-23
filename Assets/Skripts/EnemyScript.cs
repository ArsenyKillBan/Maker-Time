using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class EnemyScript : MonoBehaviour
{
    public int HP = 100;

    public Animator animator;
    public Slider healthBar;

    public bool isDead = false;

    void Update()
    {
        if (healthBar != null)
            healthBar.value = HP;
    }

    public void TakeDamage(int damageAmount)
    {
        if (isDead) return;

        HP -= damageAmount;

        if (HP <= 0)
        {
            Die();
        }
        else
        {
            animator.SetTrigger("Damage");
        }
    }

    void Die()
    {
        isDead = true;

        animator.SetTrigger("Death");

        GetComponent<Collider>().enabled = false;

        if (healthBar != null)
            healthBar.gameObject.SetActive(false);

        GameManager.Instance.AddKill();

        Destroy(gameObject, 5f);
    }
}