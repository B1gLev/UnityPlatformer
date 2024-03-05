using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private GameObject bloodDrops;
    [SerializeField] private float maxHealth = 10f;
    [SerializeField] private Slider healthBar;
    [SerializeField] private Image bloodScreenFX;
    [SerializeField] private float fadeSmooth = 2f;
    
    private bool getDamage;
    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;
        getDamage = false;
    }

    private void Update()
    {
        if (getDamage) bloodScreenFX.color = new Color(255, 255, 255, .8f);
        else
        {
            bloodScreenFX.color = Color.Lerp(bloodScreenFX.color, new(255, 255, 255, 0f), Time.deltaTime * fadeSmooth);
        }
        getDamage = false;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        getDamage = true;
        healthBar.value = currentHealth;
        Instantiate(bloodDrops, transform.position, transform.rotation);
        if (currentHealth < 0) MakeDead();
    }

    private void MakeDead()
    {
        Destroy(gameObject);
        bloodScreenFX.color = new(255,255, 255, 1f);
    }
}
