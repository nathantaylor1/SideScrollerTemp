using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public KeyCode attackKey = KeyCode.X;

    private void Awake()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(attackKey))
        {
            PerformAttack();
        }
    }

    private void PerformAttack()
    {
        
    }
}
