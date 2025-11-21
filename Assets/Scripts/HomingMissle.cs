using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HomingMissle : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public float speed = 7.0f;
    public GameObject explosion;
    public float rotateSpeed = 200.0f;
    public GameObject explosionEffect;
    private Rigidbody2D rb; 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
        explosion.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 direction =(Vector2) target.position - rb.position;
        direction.Normalize();
        float rotateAmount = Vector3.Cross(direction, transform.up).z;
        rb.angularVelocity = -rotateAmount * rotateSpeed;
        rb.velocity = transform.up * speed;
       
    }
    void OnTriggerEnter2D()
    {
        explosion.SetActive(true);
        Instantiate(explosionEffect, transform.position,transform.rotation);
        Destroy(gameObject);
        Debug.Log("Explosion");
    }
}
