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
    private int i = 0;
    private NavMeshAgent agent;
    private bool chase = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = waypoints[i].position;
    }
    void Update()
    {
        if (Vector3.Distance(Player.position, transform.position) < 6 && !chase)
        {
            agent.destination = Player.position;
            chase = true;
            FindObjectOfType<audioManager>().Play("noticed");
        }
        else if (!chase && agent.remainingDistance <= 0.5f)
        {
            if (i > waypoints.Length + 1)
            {
                i = 0;
               
                agent.destination = waypoints[i].position;

            }
            else
            {
                i++;
                agent.destination = waypoints[i].position;
                Debug.Log("done");
            }
        }


    }
}
