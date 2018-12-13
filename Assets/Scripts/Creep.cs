using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creep : DestructablePewPewTankObject {

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
	
	// Update is called once per frame
	void Update () {
		
	}
}
