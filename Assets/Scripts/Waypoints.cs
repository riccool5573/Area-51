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
    [SerializeField]
    private Animator anim;
    private bool isHiding;
    [SerializeField]
    private Hiding hiding;

    void Start()
    {
        FindObjectOfType<AudioManager>().Play("breathing");
        agent = GetComponent<NavMeshAgent>();
        agent.destination = new Vector3(UnityEngine.Random.Range(Player.transform.position.x - 10, Player.transform.position.x + 10.0f), 0, UnityEngine.Random.Range(Player.transform.position.z - 10, Player.transform.position.z + 10.0f));
      
    }

    void Update()
    {
       
        if (chase)
        {
            if (!isHiding)
                agent.destination = Player.position;
            else
            {
                chase = false;
                GetDestination();
            }


            if (Vector3.Distance(Player.position, transform.position) > 35)
            {
                chase = false;
                agent.speed = 5;
                
                anim.SetBool("isChasing", false);
                GetDestination();
            }
        }
        else if (Vector3.Distance(Player.position, transform.position) < 25 && !chase)
        {
            isHiding = hiding.GetHiding();
            if (!isHiding)
            {
                UnityEngine.Debug.Log("chase");
                //FindObjectOfType<AudioManager>().Play("noticed");

                FindObjectOfType<AudioManager>().Play("noticed");
                chase = true;
                StartCoroutine(Anim());
            }
            else GetDestination();


        }
        else if (!chase && agent.remainingDistance <= 0.5f)
        {
            GetDestination();
        }
    }


    IEnumerator Anim()
    {
        anim.SetBool("isRoaring", true);
        agent.speed = 0;
        yield return new WaitForSeconds(1);
        agent.speed = 14;
        anim.SetBool("isRoaring", false);
        anim.SetBool("isChasing", true);

    }

    private void GetDestination()
    {
        agent.destination = new Vector3(UnityEngine.Random.Range(Player.transform.position.x - 20, Player.transform.position.x + 20.0f), 0, UnityEngine.Random.Range(Player.transform.position.z - 20, Player.transform.position.z + 20.0f));
    }
}
