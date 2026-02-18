using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    // Start is called before the first frame update
   
   public Transform firepoint;
    public GameObject bulletPrefab;
    public int damage = 40;
    public GameObject impactEffect;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        // shooting logic
        Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        RaycastHit2D hitInfo = Physics2D.Raycast(firepoint.position, firepoint.right);
        if (hitInfo)
        {
            Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
            if(enemy != null )
            {
                enemy.TakeDamage(damage);
            }
            Instantiate(impactEffect, hitInfo.point, Quaternion.identity);
        }
    }
}
