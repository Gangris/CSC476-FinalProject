using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepManager : DestructablePewPewTankObject
{
    private void Start()
    {
        Bootstrap();
        this.health = 400;
        this.maxHealth = 400;
    }
}
