using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        IntermediateEnemy intermediateEnemy = collision.GetComponent<IntermediateEnemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
        if (intermediateEnemy != null)
        {
            intermediateEnemy.TakeDamage(damage);
            Destroy(gameObject);


        }
    }
}









