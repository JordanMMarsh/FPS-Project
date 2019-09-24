using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float turnSpeed = 5f;
    [SerializeField] float damage = 10f;
    PlayerHealth playerHealth;
    Animator animator;

    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerHealth = target.GetComponent<PlayerHealth>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceToTarget = Vector3.Distance(transform.position, target.position);
        if (isProvoked)
        {
            EngageTarget(distanceToTarget);
        }
        else if (distanceToTarget <= chaseRange)
        {
            isProvoked = true;            
        }     
    }

    public void SetProvoked(bool isProvoked)
    {
        this.isProvoked = isProvoked;
    }

    private void EngageTarget(float distanceToTarget)
    {
        if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
        else
        {
            ChaseTarget();
        }        
    }

    private void AttackTarget()
    {
        animator.SetBool("isMoving", false);
        animator.SetBool("isAttacking", true);
        FaceTarget();
    }

    private void ChaseTarget()
    {
        animator.SetBool("isAttacking", false);
        animator.SetBool("isMoving", true);
        navMeshAgent.SetDestination(target.position);
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    //Called by animation event during isAttacking state animation
    public void HitTarget()
    {
        playerHealth.DealDamage(damage);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
