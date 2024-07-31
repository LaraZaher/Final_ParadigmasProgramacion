using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Mov : GameBase
{
    public float moveSpeed = 5f;
    public Weapon weapon;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Initialize();
    }

    public override void Initialize()
    {
        
        moveSpeed = 5f;
    }


    private void Update()
    {
        float moveInputX = Input.GetAxis("Horizontal");

        float moveInputY = Input.GetAxis("Vertical");
        Move(new Vector2(moveInputX, moveInputY), moveSpeed);


        if (Input.GetKeyDown(KeyCode.Space) && weapon != null)
        {
            weapon.Fire();
        }
    }

}
