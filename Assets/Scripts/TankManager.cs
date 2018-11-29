﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankManager : MonoBehaviour
{
    public GameObject round;

    public Rigidbody rb;
    public GameObject tankBody;
    public GameObject tankTurret;
    public List<GameObject> playerRounds = new List<GameObject>();
    public float baseMoveMultiplier = 4;
    public float upgradeMoveMultiplier = 0;
    public float baseRoundVelocity = 4;
    public float upgradeRoundVelocity = 0;
    public float baseRoundDuration = 1;
    public float upgradeRoundDuration = 0;

	void Start ()
	{
	    rb = GetComponent<Rigidbody>();

	    Transform tbtrans = gameObject.transform.Find("Body");
	    tankBody = tbtrans.gameObject;

	    Transform tttrans = gameObject.transform.Find("Turret");
	    tankTurret = tttrans.gameObject;
	}
	
	void Update ()
	{
	    CenterCamera();
	    MovementInput();
	    UpdateTurret();
	}

    void CenterCamera()
    {
        Camera.main.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -10);
    }

    void MovementInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            // Add multiplayer method for server to handle movement
            rb.AddForce(tankBody.transform.up * (baseMoveMultiplier + upgradeMoveMultiplier));
        }

        if (Input.GetKey(KeyCode.S))
        {
            // Add multiplayer method for server to handle movement
            rb.AddForce(-tankBody.transform.up * (baseMoveMultiplier + upgradeMoveMultiplier));
        }

        if (Input.GetKey(KeyCode.A))
        {
            // Add multiplayer method for server to handle rotation
            tankBody.transform.Rotate(0, 0, 1f);
        }

        if (Input.GetKey(KeyCode.D))
        {
            // Add multiplayer method for server to handle rotation
            tankBody.transform.Rotate(0, 0, -1f);
        }
    }

    void UpdateTurret()
    {
        // Add multiplayer method to handle turret rotation (due to shooting bullets)
        Vector3 mouse = Input.mousePosition;
        mouse = Camera.main.ScreenToWorldPoint(mouse);
        Vector2 direction = new Vector2(mouse.x - transform.position.x, mouse.y - transform.position.y);

        tankTurret.transform.up = direction;

        if (Input.GetMouseButtonDown(0))
        {
            if (playerRounds.Count < 4)
            {
                ShootTurret(direction);
            }
        }
    }

    void ShootTurret(Vector2 direction)
    {
        GameObject newRound = Instantiate(round, tankTurret.transform.Find("Barrel").position, Quaternion.identity);
        newRound.GetComponent<RoundManager>().velocity = baseRoundVelocity + upgradeRoundVelocity;
        newRound.GetComponent<RoundManager>().direction = Mathf.Rad2Deg * Mathf.Atan2(direction.y, direction.x) - 90f;
        newRound.GetComponent<RoundManager>().owner = gameObject;
        playerRounds.Add(newRound);
        
        StartCoroutine(DelayedDestroyRound(newRound));
    }

    IEnumerator DelayedDestroyRound(GameObject newRound)
    {
        yield return new WaitForSeconds(baseRoundDuration + upgradeRoundDuration);
        playerRounds.Remove(newRound);
        Destroy(newRound);
    }
}
