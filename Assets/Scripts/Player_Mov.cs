using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Mov : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        float moveInputX = Input.GetAxis("Horizontal");

        float moveInputY = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(moveInputX * moveSpeed, moveInputY * moveSpeed);
    }


}
