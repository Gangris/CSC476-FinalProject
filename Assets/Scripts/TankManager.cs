using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankManager : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject tankBody;
    public GameObject tankTurret;
    public int baseMoveMultiplyer = 4;
    public int upgradeMoveMultiplyer = 0;

	void Start ()
	{
	    rb = GetComponent<Rigidbody>();

	    Transform tbtrans = gameObject.transform.Find("Body");
	    tankBody = tbtrans.gameObject;

	    Transform tttrans = gameObject.transform.Find("Turret");
	    tankTurret = tttrans.gameObject;
	}
	
	void Update () {
	    MovementInput();
	    UpdateTurretPosition();
	}

    void MovementInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            // Add multiplayer method for server to handle movement
            rb.AddForce(tankBody.transform.up * (baseMoveMultiplyer + upgradeMoveMultiplyer));
        }

        if (Input.GetKey(KeyCode.S))
        {
            // Add multiplayer method for server to handle movement
            rb.AddForce(-tankBody.transform.up * (baseMoveMultiplyer + upgradeMoveMultiplyer));
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

    void UpdateTurretPosition()
    {
        Vector3 mouse = Input.mousePosition;
        mouse = Camera.main.ScreenToWorldPoint(mouse);
        Vector2 direction = new Vector2(mouse.x - transform.position.x, mouse.y - transform.position.y);

        tankTurret.transform.up = direction;
    }
}
