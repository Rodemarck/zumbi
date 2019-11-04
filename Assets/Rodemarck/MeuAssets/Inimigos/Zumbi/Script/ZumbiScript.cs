using System;
using System.Collections;
using System.Collections.Generic;
using UniJSON;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[System.Serializable]
public class ZumbiScript : MonoBehaviour
{
    public Vida vida;
    public float Speed;
    public float Angularspeed;
    public float Dano;
    public bool Attack = false;
    public bool Death = false;
    public GameObject barraVida;
    
    private Animator Animator;

    private NavMeshAgent NavMeshAgent;
    private GameObject Player;

    public float GetDano()
    {
        return Dano;
    }
   

    public void RecebeDano(float value)
    {
        if (!Death)
        {
            vida.VidaAtual += value;
            if (!vida.vivo())
            {
                Death = true;
                Animator.SetBool("death", true);
            }
        }
    }
    public void sexo()
    {
        Debug.Log("esupro mental");
    }

    private void Awake()
    {
        vida = new Vida();
        vida.Canvas = barraVida;
        vida.Camera = GameObject.FindWithTag("Camera");
        vida.VidaMax = 100f;
        vida.VidaAtual = 100f;
    }

    void Start()
    {
        Speed = 10.0f;
        Angularspeed = 0.0f;
        
        
        Player = GameObject.FindWithTag("Jogador");
        NavMeshAgent = GetComponent<NavMeshAgent>();
        Animator = GetComponent<Animator>();
        NavMeshAgent.speed = Speed;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (!Death)
        {
            if (Vector3.Distance(Player.transform.position, this.gameObject.transform.position) < 100)
            {
                NavMeshAgent.destination = Player.transform.position;
                if (Vector3.Distance(Player.transform.position, this.gameObject.transform.position) < 3)
                {
                    Animator.SetBool("attack", true);
                }   
            }
            else
            {
                if (NavMeshAgent.destination != this.transform.position)
                {
                    NavMeshAgent.destination = this.transform.position;
                }
            }
        }
    }
}
