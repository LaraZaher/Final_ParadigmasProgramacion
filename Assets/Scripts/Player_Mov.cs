using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Mov : GameBase
{
    public float moveSpeed = 5f;
    public Weapon weapon;
    public float health = 10f;

    private Rigidbody2D rb;

    //variables para las animaciones
    private float moveInputX;
    private float moveInputY;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        Initialize();
    }

    public override void Initialize()
    {
        
        moveSpeed = 5f;
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
        
        Debug.Log("murio :p");
        Destroy(gameObject); 
    }

    private void Update()
    {
        moveInputX = Input.GetAxisRaw("Horizontal");
        moveInputY = Input.GetAxisRaw("Vertical");

        animator.SetFloat("MovimientoX", moveInputX);
        animator.SetFloat("MovimientoY", moveInputY);

        if(moveInputX != 0 || moveInputY != 0)
        {
            animator.SetFloat("UltimoX", moveInputX);
            animator.SetFloat("UltimoY", moveInputY);
        }
        Move(new Vector2(moveInputX, moveInputY), moveSpeed);


        if (Input.GetKeyDown(KeyCode.Space) && weapon != null)
        {
            weapon.Fire();
        }
    }

}
