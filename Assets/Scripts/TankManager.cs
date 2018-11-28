using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankManager : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject tankBody;
    public int baseMoveMultiplyer = 4;
    public int upgradeMoveMultiplyer = 0;

	void Start ()
	{
	    rb = GetComponent<Rigidbody>();
	    Transform tbtrans = gameObject.transform.Find("Body");
	    tankBody = tbtrans.gameObject;
	}
	
	void Update () {
	    MovementInput();
    }

    void MovementInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(tankBody.transform.up * (baseMoveMultiplyer + upgradeMoveMultiplyer));
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(-tankBody.transform.up * (baseMoveMultiplyer + upgradeMoveMultiplyer));
        }

        if (Input.GetKey(KeyCode.A))
        {
            //rb.AddForce(Vector3.left);
            tankBody.transform.Rotate(0, 0, 1f);
        }

        if (Input.GetKey(KeyCode.D))
        {
            //rb.AddForce(Vector3.right);
            tankBody.transform.Rotate(0, 0, -1f);
        }
    }
}
