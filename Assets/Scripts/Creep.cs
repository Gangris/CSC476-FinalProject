using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creep : DestructablePewPewTankObject {
    GameObject[] enemies;
    public GameObject round;
    public GameObject creep;

    public string enemyTeam;
    public int creepDamage = 25;

    float timer = 0;
    int waitingTime = 2;

    // Use this for initialization
    void Start () {
		Bootstrap();
	    this.maxHealth = 100;
	    this.health = 100;

	    if (gameObject.tag == "team1")
	    {
	        this.team = Team.team1;
	    }
	    else
	    {
	        this.team = Team.team2;
	    }
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
        GameObject newRound = Instantiate(round, creep.transform.position, Quaternion.identity);
        RoundManager nrManager = newRound.GetComponent<RoundManager>();
        nrManager.velocity = 4;
        nrManager.direction = Mathf.Rad2Deg * Mathf.Atan2(direction.y, direction.x) - 90f;
        nrManager.owner = gameObject;
        nrManager.team = team;
        nrManager.damage = creepDamage;


        StartCoroutine(DelayedDestroyRound(newRound));
    }

    IEnumerator DelayedDestroyRound(GameObject newRound)
    {
        yield return new WaitForSeconds(3);
        Destroy(newRound);
    }
}
