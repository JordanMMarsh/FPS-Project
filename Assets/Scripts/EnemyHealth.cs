using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float startingHealth = 100f;
    private float currentHealth;

    private void Start()
    {
        currentHealth = startingHealth;
    }

    public void DealDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log(currentHealth + " health remaining.");
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
