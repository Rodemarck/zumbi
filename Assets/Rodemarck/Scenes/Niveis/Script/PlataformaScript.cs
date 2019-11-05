using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaScript : MonoBehaviour
{
    public GameObject alvo;
    public GameObject prox;
    public bool ativo;
    
    public string itemNome;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setar(bool value)
    {
        ativo = value;
    }

    private void OnCollisionEnter(Collision other)
    {
        
        if (ativo)
        {
            if (itemNome == null || Inventory.instance.Existe(itemNome))
            {
                alvo.SendMessage("acao");
                if (prox != null)
                {
                    prox.SendMessage("acao");
                }
            }
            
        }
    }
    
    
}
