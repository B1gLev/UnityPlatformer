using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private float damageRate = 1f;
    [SerializeField] private float damage = 2f;
    [SerializeField] private float pushForce;

    private float nextDamage;

    private void Start()
    {
        nextDamage = 0f;
    }

    private void OnTriggerStay2D(Collider2D player)
    {
        if (player.CompareTag("Player") && nextDamage < Time.time)
        {
            PlayerHealth playerHealth = player.gameObject.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damage); 
            nextDamage = Time.time + damageRate;
        }
    }

    private void PushBack(Transform pusher)
    {
    }
}
