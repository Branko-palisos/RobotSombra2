using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Boss : MonoBehaviour
{
    public Transform player;
    public int health = 500;
    public GameObject deathEffect;
    public bool isInvulnerable = false;
    public bool isFlipped = false;
    public Rigidbody2D rb;
    public Transform target;
    public float speed = 7.0f;
    public GameObject explosion;
    public float rotateSpeed = 200.0f;
    public GameObject explosionEffect;
    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }
  
    public void TakeDamage(int damage)
    {
        if (isInvulnerable)
            return;

        health -= damage;

        if (health <= 200)
        {
            GetComponent<Animator>().SetBool("IsEnraged", true);
        }

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
   
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public int attackDamage = 20;
    public int enragedAttackDamage = 40;

    public Vector3 attackOffset;
    public float attackRange = 1f;
    public LayerMask attackMask;

    public void Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (colInfo != null)
        {
            colInfo.GetComponent<PlayerBehaviour>().TakeDamage(attackDamage);
        }
    }
    void Start()
    {
    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target == null)
        {
            return;
        }
        rb.velocity = transform.up * speed;
          Vector2 direction = (Vector2)target.position - rb.position;
       
        direction.Normalize();
        float rotateAmount = Vector3.Cross(direction, transform.up).z;
        rb.angularVelocity = -rotateAmount * rotateSpeed;
        rb.velocity = transform.up * speed;
    }
    void OnTriggerEnter2D()
    {
        explosion.SetActive(true);
        Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(gameObject);
        Debug.Log("Explosion");
    }
    public void EnragedAttack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (colInfo != null)
        {
            colInfo.GetComponent<PlayerBehaviour>().TakeDamage(enragedAttackDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Gizmos.DrawWireSphere(pos, attackRange);
    }
}