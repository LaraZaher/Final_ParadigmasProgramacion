using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntermediateEnemy : Enemy
{
    private void Awake()
    {
        moveSpeed = 3f;
        health = 10;
        damage = 2;
    }
}
