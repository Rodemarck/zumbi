using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class ZumbiScript : MonoBehaviour
{
    public float Health;
    public float Speed;
    public float Angularspeed;
    public bool Attack;
    public bool Death;
    
    private Animator Animator;

    private NavMeshAgent NavMeshAgent;
    private GameObject Player;
    void Start()
    {
        Speed = 0.0f;
        Angularspeed = 0.0f;
        Attack = false;
        Death = false;
        Health = 100;
        Player = GameObject.FindWithTag("Player");
        NavMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        NavMeshAgent.destination = Player.transform.position;
            
    }
}
