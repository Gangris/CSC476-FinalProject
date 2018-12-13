using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding
{
    public class Triggers : MonoBehaviour
    {

        public GameObject T1MidTarget;
        public GameObject T2MidTarget;

        public void OnTriggerEnter(Collider other)
        {
            Debug.Log("Hello");
            if (other.gameObject.CompareTag("team1"))
            {
                ChangeDestination(other.gameObject, Team.team1);
            }
            else if (other.gameObject.CompareTag("team2"))
            {
                ChangeDestination(other.gameObject, Team.team2);
            }
        }

        public void ChangeDestination(GameObject o, Team t)
        {
            if (t == Team.team1)
            {
                AIDestinationSetter t1 = o.GetComponent<AIDestinationSetter>();
                t1.target = T1MidTarget.transform;
            }
            else
            {
                AIDestinationSetter t2 = o.GetComponent<AIDestinationSetter>();
                t2.target = T2MidTarget.transform;
            }
        }
    }
}
