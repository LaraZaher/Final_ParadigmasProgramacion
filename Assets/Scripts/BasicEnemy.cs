using UnityEngine;

public class BasicEnemy : Enemy
{
    private void Awake()
    {
        moveSpeed = 2f;
        health = 2;
        damage = 1;
    }
}

