using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.AI;

public class Waypoints : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Transform[] waypoints;
    [SerializeField]
    private Transform Player;
    private int i = 0; //rename waypointIndex
    [SerializeField]
    private NavMeshAgent agent;
    private bool chase = false;


    void Start()
    {
        FindObjectOfType<AudioManager>().Play("breathing");
        agent = GetComponent<NavMeshAgent>();
        agent.destination = new Vector3(UnityEngine.Random.Range(Player.transform.position.x - 10, Player.transform.position.x + 10.0f), 0, UnityEngine.Random.Range(Player.transform.position.z - 10, Player.transform.position.z + 10.0f));
    }

    void Update()
    {
        UnityEngine.Debug.Log(agent.remainingDistance);
        UnityEngine.Debug.Log(chase);
        if (chase)
        {
            agent.destination = Player.position;
            UnityEngine.Debug.Log("chasing");


            if (Vector3.Distance(Player.position, transform.position) > 35)
            {
                chase = false;
                agent.speed = 3.5f;
                UnityEngine.Debug.Log("no longer chasing");
            }
        }
        else if (Vector3.Distance(Player.position, transform.position) < 25 && !chase)
        {

            UnityEngine.Debug.Log("chase");
            //FindObjectOfType<AudioManager>().Play("noticed");

            FindObjectOfType<AudioManager>().Play("noticed");

            chase = true;
            agent.speed = 15;

        }
        else if (!chase && agent.remainingDistance <= 0.5f)
        {
          
           
            agent.destination = new Vector3(UnityEngine.Random.Range(Player.transform.position.x -10, Player.transform.position.x  + 10.0f), 0, UnityEngine.Random.Range(Player.transform.position.z - 10, Player.transform.position.z + 10.0f)); 
        }
    }
}
