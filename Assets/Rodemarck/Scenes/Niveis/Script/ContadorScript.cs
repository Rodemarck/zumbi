using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContadorScript : MonoBehaviour
{
    public int numero;
    public int num;
    public GameObject alvo;
    public GameObject prox;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void acao()
    {
        Debug.Log("conta");
        if (num < numero)
        {
            num++;
            if (num == numero)
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
