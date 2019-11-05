using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_level1 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject texto;
    private string[] textos;
    private int n = 0;
    private bool w=false, a=false, s=false, d=false, tiro=false;
    private bool basico = true;
    void Start()
    {
        textos = new string[30];
        textos[0] = "precione w para andar para frente";
        textos[1] = "precione s para andar para tras";
        textos[2] = "precione d para andar para direita";
        textos[3] = "precione a para andar para tras";
        textos[4] = "click com o botao esquerdo para atirar";
        textos[5] = "atire no botão cinza";
        textos[6] = "sai da sala";
        textos[7] = "mata a porra do zumbi";
        textos[8] = "avance";
        textos[9] = "mate todos, ou morra tentando";
        acao();
        
    }
 
    // Update is called once per frame
    void Update()
    {
        if (basico)
        {
            if (w && s && d && a)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    tiro = true;
                    basico = false;
                    GameObject.Find("Botao1").SendMessage("setar",true);
                    acao();
                }
            }
            else if (w && s && d)
            {
                if (Input.GetKeyDown("a"))
                {
                    a = true;
                    acao();
                }
            }
            else if (w && s)
            {
                if (Input.GetKeyDown("d"))
                {
                    d = true;
                    acao();
                }
            }
            else if (w)
            {
                if (Input.GetKeyDown("s"))
                {
                    s = true;
                    acao();
                }
            }
            else
            {
                if (Input.GetKeyDown("w"))
                {
                    w = true;
                    acao();
                }
            }
        }
    }

    public void acao()
    {
        if (n == 10) 
            SceneManager.LoadScene("Fase2");
        else
            texto.GetComponent<Text>().text = textos[n++];
        
    }

}
