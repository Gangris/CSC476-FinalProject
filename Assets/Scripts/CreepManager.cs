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
        Spawn();
        //calling Spawn function every spawnTime seconds.
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    public GameObject Team1Creep;
    public GameObject Team2Creep;
    public GameObject T1midSpawn;
    public GameObject T1botSpawn;
    public GameObject T1topSpawn;
    public GameObject T2midSpawn;
    public GameObject T2botSpawn;
    public GameObject T2topSpawn;
    public float spawnTime = 45f;

    void Spawn()
    {
        //creating a creep at each spawn point every time the Spawn function is called.
        Instantiate(Team1Creep, T1topSpawn.transform.position, Quaternion.identity);
        Instantiate(Team1Creep, T1midSpawn.transform.position, Quaternion.identity);
        Instantiate(Team1Creep, T1botSpawn.transform.position, Quaternion.identity);
        Instantiate(Team2Creep, T2topSpawn.transform.position, Quaternion.identity);
        Instantiate(Team2Creep, T2midSpawn.transform.position, Quaternion.identity);
        Instantiate(Team2Creep, T2botSpawn.transform.position, Quaternion.identity);
    }
}
