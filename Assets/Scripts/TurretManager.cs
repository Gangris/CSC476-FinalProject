using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretManager : DestructablePewPewTankObject
{
    void Start()
    {
        Bootstrap();
        this.maxHealth = 1000;
        this.health = 1000;
    }
}
