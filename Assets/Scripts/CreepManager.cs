using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Pathfinding
{
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
        //T1MidTarget = the T2Base. T2MidTarget = T1Base
        public GameObject T1MidTarget;
        public GameObject T2MidTarget;
        //top and bottom triggers that send creeps on to the base.
        public GameObject TopTrigger;
        public GameObject BottomTrigger;

        public float spawnTime = 1f;

        void Spawn()
        {
            //creating a creep at each spawn point every time the Spawn function is called.
            GameObject T1topS = Instantiate(Team1Creep, T1topSpawn.transform.position, Quaternion.identity);
            AIDestinationSetter t1ts = T1topS.GetComponent<AIDestinationSetter>();
            t1ts.target = TopTrigger.transform;

            GameObject T1midS = Instantiate(Team1Creep, T1midSpawn.transform.position, Quaternion.identity);
            AIDestinationSetter t1ms = T1midS.GetComponent<AIDestinationSetter>();
            t1ms.target = T1MidTarget.transform;

            GameObject T1botS = Instantiate(Team1Creep, T1botSpawn.transform.position, Quaternion.identity);
            AIDestinationSetter t1bs = T1botS.GetComponent<AIDestinationSetter>();
            t1bs.target = BottomTrigger.transform;

            GameObject T2topS = Instantiate(Team2Creep, T2topSpawn.transform.position, Quaternion.identity);
            AIDestinationSetter t2ts = T2topS.GetComponent<AIDestinationSetter>();
            t2ts.target = TopTrigger.transform;

            GameObject T2midS = Instantiate(Team2Creep, T2midSpawn.transform.position, Quaternion.identity);
            AIDestinationSetter t2ms = T2midS.GetComponent<AIDestinationSetter>();
            t2ms.target = T2MidTarget.transform;

            GameObject T2botS = Instantiate(Team2Creep, T2botSpawn.transform.position, Quaternion.identity);
            AIDestinationSetter t2bs = T2botS.GetComponent<AIDestinationSetter>();
            t2bs.target = BottomTrigger.transform;


        }
    }
}