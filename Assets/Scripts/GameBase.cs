
using UnityEngine;

public abstract class GameBase : MonoBehaviour
{
    
    public abstract void Initialize();

    
    public virtual void Move(Vector2 direction, float speed)
    {
        
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = direction * speed;
        }
    }

    
    public virtual void StopMove()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.zero;
        }
    }
}

