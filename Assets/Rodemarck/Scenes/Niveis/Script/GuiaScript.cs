using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuiaScript : MonoBehaviour
{
    public bool ativo;
    public float distancia;
    public GameObject prox;
    private GameObject jogador;

    // Start is called before the first frame update
    void Start()
    {
        jogador = GameObject.FindWithTag("Jogador");
    }

    public void acao()
    {
        ativo = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (ativo)
        {
            if (Vector3.Distance(gameObject.transform.position, jogador.transform.position) < distancia)
            {
                jogador.SendMessage("acao");
                if (prox != null)
                {
                    prox.SendMessage("acao");
                }

                ativo = false;
            }
        }
    }
}
