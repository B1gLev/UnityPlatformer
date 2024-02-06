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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("destroyable"))
        {
            controller.Stop();
            Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
