using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 10;
    public float lifeTime = 2f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            BasicEnemy basicEnemy = collision.gameObject.GetComponent<BasicEnemy>();
            if (basicEnemy != null)
            {
                basicEnemy.TakeDamage(damage);
                Destroy(gameObject);
            }
        }

    }
}


        


