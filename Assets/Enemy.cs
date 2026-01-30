using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public GameObject deathEffect;
    public GameObject explosion;
    public GameObject explosionEffect;
    public void Start()
    {
        explosion.SetActive(false);
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
        }
    }    
    void Die()
    {
        explosion.SetActive(true);
        Instantiate(explosionEffect, transform.position, transform.rotation);
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
