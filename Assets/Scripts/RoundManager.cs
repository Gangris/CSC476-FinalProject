using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
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

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetInstanceID() != owner.GetInstanceID())
        {
            Destroy(gameObject);
        }
    }
}
