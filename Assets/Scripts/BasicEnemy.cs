using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    public Transform player; 
    public float moveSpeed = 2f;
    public float health = 10f;
    public float knockbackForce = 5f;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (player == null)
        {
            player = GameObject.FindWithTag("Player").transform;
        }
    }

    private void FixedUpdate()
    {
        
        Vector2 direction = (player.position - transform.position).normalized;
        
        rb.velocity = direction * moveSpeed;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(1f);
            Vector2 knockbackDirection = (transform.position - collision.transform.position).normalized;
            rb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        
        Destroy(gameObject);
    }
}
