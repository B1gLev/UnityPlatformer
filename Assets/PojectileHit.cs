using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PojectileHit : MonoBehaviour
{
    [SerializeField] private GameObject explosionEffect;
    [SerializeField] private float damage;

    private ProjectileController controller;

    private void Awake()
    {
        controller = GetComponentInParent<ProjectileController>();
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.layer == LayerMask.NameToLayer("Hitable"))
        {
            controller.Stop();
            Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);

            if (target.CompareTag("enemy"))
            {
                EnemyHealth enemyHealth = target.gameObject.GetComponent<EnemyHealth>();
                enemyHealth.AddDamage(damage);
            }
        }
    }
}
