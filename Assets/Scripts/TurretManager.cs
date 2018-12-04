using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretManager : DestructablePewPewTankObject
{
    GameObject[] enemies;
    public GameObject round;
    public GameObject turret;

    public string enemyTeam;
    public int turretDamage = 100;

    float timer = 0;
    int waitingTime = 1;

    void Start()
    {
        Bootstrap();
        this.maxHealth = 1000;
        this.health = 1000;
        if (this.team == Team.team1)
            enemyTeam = "team2";
        else
            enemyTeam = "team1";
    }

    private void Update()
    {
            enemies = GameObject.FindGameObjectsWithTag(enemyTeam);
        foreach (GameObject target in enemies)
        {
            float distance = Vector3.Distance(target.transform.position, transform.position);
            Vector2 targetPos = new Vector2(target.transform.position.x - transform.position.x, target.transform.position.y - transform.position.y);

            timer += Time.deltaTime;
            if (distance <= 5 && timer > waitingTime)
            {
                ShootTurret(targetPos);
                timer = 0;
            }
        }

    }

    void ShootTurret(Vector2 direction)
    {
        GameObject newRound = Instantiate(round, turret.transform.position, Quaternion.identity);
        RoundManager nrManager = newRound.GetComponent<RoundManager>();
        nrManager.velocity = 4;
        nrManager.direction = Mathf.Rad2Deg * Mathf.Atan2(direction.y, direction.x) - 90f;
        nrManager.owner = gameObject;
        nrManager.team = team;
        nrManager.damage = turretDamage;
        

        StartCoroutine(DelayedDestroyRound(newRound));
    }

    IEnumerator DelayedDestroyRound(GameObject newRound)
    {
        yield return new WaitForSeconds(3);
        Destroy(newRound);
    }
}
