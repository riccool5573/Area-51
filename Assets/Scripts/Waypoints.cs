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
    [SerializeField]
    private Hiding hiding;
    private bool isHiding;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = new Vector3(UnityEngine.Random.Range(Player.transform.position.x - 10, Player.transform.position.x + 10.0f), 0, UnityEngine.Random.Range(Player.transform.position.z - 10, Player.transform.position.z + 10.0f));
    }

    void Update()
    {
        GetHiding();
        if (chase)
        {
            if(!isHiding)
            agent.destination = Player.position;
            


            if (Vector3.Distance(Player.position, transform.position) > 35 || isHiding)
            {
                chase = false;
                agent.speed = 5;

                anim.SetBool("isChasing", false);
                if (!isHiding)
                    GetDestination(10);
                if (isHiding)
                    GetDestination(100);
            }
        }
        else if (Vector3.Distance(Player.position, transform.position) < 25 && !chase && !isHiding)
        {

            UnityEngine.Debug.Log("chase");
            FindObjectOfType<AudioManager>().Play("noticed");
            chase = true;
            StartCoroutine(Anim());


        }
        else if (!chase && agent.remainingDistance <= 0.5f)
        {
            if (!isHiding)
                GetDestination(10);
            if (isHiding)
                GetDestination(100);
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

    private void GetHiding()
    {
       isHiding = hiding.GetHiding();
    }
    private void GetDestination(float offset)
    {
        agent.destination = new Vector3(UnityEngine.Random.Range(Player.transform.position.x - offset, Player.transform.position.x + offset), 0, UnityEngine.Random.Range(Player.transform.position.z - offset, Player.transform.position.z + offset));
    }
}
