using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : Enemy
{
    public GameObject projectilePrefab;  
    public Transform firePoint;          
    public float fireRate = 1f;          
    private float nextFireTime = 0f;     

    protected override void Start()
    {
        base.Start();
        moveSpeed = 1f;   
        health = 100;     
        damage = 20;      
    }

    protected override void Update()
    {
        base.Update();
        Shooting();
    }

    void Shooting()
    {
        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void Shoot()
    {
        if (firePoint != null)
        {
            Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        }
    }

    protected override void Die()
    {
        Debug.Log("murio :P");
        
        base.Die();
    }
}
