using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 5f;
    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void AddDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0) MakeDead();
    }

    private void MakeDead()
    {
        Destroy(gameObject);
    }
}
