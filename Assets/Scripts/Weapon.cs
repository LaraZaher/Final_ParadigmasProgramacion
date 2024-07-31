using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour

{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float projectileSpeed = 10f;
    public float fireRate = 0.5f;
    private float nextFireTime = 0f;



    public void Fire()
    {
        if (Time.time > nextFireTime)
        {

            Debug.Log("Disparando proyectil");
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = firePoint.right * projectileSpeed;
            }
        }
        nextFireTime = Time.time + fireRate;


    }
}

