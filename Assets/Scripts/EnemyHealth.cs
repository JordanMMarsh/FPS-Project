using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float startingHealth = 100f;
    EnemyAI enemyAI;
    private float currentHealth;

    private void Start()
    {
        enemyAI = GetComponent<EnemyAI>();
        currentHealth = startingHealth;
    }

    public void DealDamage(float damage)
    {
        enemyAI.SetProvoked(true);
        currentHealth -= damage;
        Debug.Log(currentHealth + " health remaining.");
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
