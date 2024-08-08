using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Enemy : MonoBehaviour
{
    protected float moveSpeed;
    protected int health;
    protected int damage;

    protected Transform player;

    private Player_Mov Playerscript;

    protected virtual void Start()
    {
        player = GameObject.FindWithTag("Player").transform;

        if (player != null)
        {
            Playerscript = player.GetComponent<Player_Mov>();
        }
    }

    protected virtual void Update()
    {
        if (player != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }
    }



    public virtual void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        Debug.Log($"{gameObject.name} took damage: {damageAmount}, health left: {health}");
        if (health <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Debug.Log($"{gameObject.name} died.");
        Destroy(gameObject);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        Player_Mov player = collision.GetComponent<Player_Mov>();
        if (player != null)
        {
            player.TakeDamage(damage);
            Die(); 
        }
    }

}


