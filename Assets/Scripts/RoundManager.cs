using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : PewPewTankObject
{
    public float velocity = 0.0f;
    public float direction;
    public GameObject owner;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.rotation = Quaternion.Euler(0, 0, direction);
		transform.Translate(Vector3.up * Time.deltaTime * velocity);
	}

    void OnTriggerEnter(Collider collision)
    {
        var col = collision.gameObject;
        while (col.GetComponent<PewPewTankObject>() == null && collision.gameObject.transform.parent != null)
        {
            col = col.transform.parent.gameObject;
        }

        PewPewTankObject t = col.GetComponent<PewPewTankObject>();
        if (t != null)
        {
            if (t.team != this.team)
            {
                Destroy(this);
            }
        }
    }
}
