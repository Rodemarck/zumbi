using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlavancaScript : MonoBehaviour
{
    public GameObject alvo;
    public GameObject prox;
    public string itemNome;
    public bool ativo;
    private Inventory iventario;
    private Transform player;
        
    public void setar(bool value)
    {
        ativo = value;
    }
    
    void Start()
    {
        iventario = Inventory.instance;
        player = GameObject.FindWithTag("Jogador").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (ativo)
        {
            if (Input.GetKeyDown("e"))
            {
                if (itemNome == null || iventario.Existe(itemNome))
                {
                    if (Vector3.Distance(transform.position, player.position) < 2)
                    {
                        alvo.SendMessage("acao");
                        if(prox != null)
                            prox.SendMessage("acao");  
                    }
                }
            }
        }
    }
}
