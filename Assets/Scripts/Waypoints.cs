using System.Collections;
using System.Collections.Generic;
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
    private NavMeshAgent agent;
    private bool chase = false;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = waypoints[i].position;
    }

    void Update()
    {
        if (chase)
        {
            agent.destination = Player.position;
           
            
            if(Vector3.Distance(Player.position, transform.position) > 25)
            {
                chase = false;
                agent.speed = 3.5f;
            }
        }
        if (Vector3.Distance(Player.position, transform.position) < 35 && !chase)
        {
            //FindObjectOfType<AudioManager>().Play("noticed");
            chase = true;
            agent.speed = 15;

        }
        else if (!chase && agent.remainingDistance <= 0.5f)
        {
            if (i > waypoints.Length + 1)
            {
                i = 0;
             
            }
            else
            {
                i++;
                
                Debug.Log("done");
            }
            agent.destination = waypoints[i].position;
        }
    }
}
