using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public Transform[] patrolPoints;

    public float chaseDistance = 10f;
    public float attackDistance = 2f;

    public int damage = 10;
    public float attackCooldown = 1.5f;

    private NavMeshAgent agent;
    private Animator animator;
    private EnemyScript enemyScript;

    private int currentPoint;
    private float attackTimer;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        enemyScript = GetComponent<EnemyScript>();

        if (patrolPoints.Length > 0)
        {
            agent.SetDestination(
                patrolPoints[0].position);
        }
    }

    void Update()
    {
        if (enemyScript.isDead)
        {
            agent.isStopped = true;
            return;
        }

        float distance =
            Vector3.Distance(
                transform.position,
                player.position);

        if (distance <= attackDistance)
        {
            Attack();
        }
        else if (distance <= chaseDistance)
        {
            Chase();
        }
        else
        {
            Patrol();
        }
    }

    void Patrol()
    {
        animator.SetBool("IsPatrolling", true);
        animator.SetBool("IsChasing", false);

        if (patrolPoints.Length == 0)
            return;

        if (!agent.pathPending &&
            agent.remainingDistance < 0.5f)
        {
            currentPoint++;

            if (currentPoint >= patrolPoints.Length)
                currentPoint = 0;

            agent.SetDestination(
                patrolPoints[currentPoint].position);
        }
    }

    void Chase()
    {
        animator.SetBool("IsPatrolling", false);
        animator.SetBool("IsChasing", true);

        agent.SetDestination(player.position);
    }

    void Attack()
    {
        animator.SetBool("IsPatrolling", false);
        animator.SetBool("IsChasing", false);

        agent.SetDestination(transform.position);

        transform.LookAt(player);

        attackTimer += Time.deltaTime;

        if (attackTimer >= attackCooldown)
        {
            attackTimer = 0;

            animator.SetTrigger("Attack");

            PlayerHealth hp =
                player.GetComponent<PlayerHealth>();

            if (hp != null)
            {
                hp.TakeDamage(damage);
            }
        }
    }
}

