using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHP = 100;
    public int currentHP;

    public Slider healthBar;

    public Transform respawnPoint;

    private CharacterController controller;
    private PLayerMover playerMover;
    private Animator animator;

    void Start()
    {
        currentHP = maxHP;

        controller = GetComponent<CharacterController>();
        playerMover = GetComponent<PLayerMover>();
        animator = GetComponent<Animator>();

        if (healthBar != null)
        {
            healthBar.maxValue = maxHP;
            healthBar.value = currentHP;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;

        if (healthBar != null)
            healthBar.value = currentHP;

        if (currentHP <= 0)
        {
            StartCoroutine(Respawn());
        }
    }

    IEnumerator Respawn()
    {
        if (animator != null)
            animator.SetTrigger("Death");

        playerMover.enabled = false;

        yield return new WaitForSeconds(2f);

        currentHP = maxHP;

        if (healthBar != null)
            healthBar.value = currentHP;

        controller.enabled = false;
        transform.position = respawnPoint.position;
        controller.enabled = true;

        playerMover.enabled = true;
    }
    public void Heal(int amount)
    {
        currentHP += amount;

        if (currentHP > maxHP)
            currentHP = maxHP;

        if (healthBar != null)
            healthBar.value = currentHP;
    }
}
