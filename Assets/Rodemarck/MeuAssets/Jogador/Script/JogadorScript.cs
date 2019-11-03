using System;
using System.Collections;
using System.Collections.Generic;
using UniJSON;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[System.Serializable]
public class JogadorScript : MonoBehaviour
{
    private Vida vida;
    private bool Morto = false;
    private Animator Animador;
    private Vector3 Direcao = new Vector3();
    private CharacterController Controller;
    [SerializeField][Range(0,20)]public float velocidade = 10;
    [SerializeField][Range(0,30)]public float dpi = 20;
    private bool andar;
    private bool esq;
    private bool dir;
    private bool atirar;
    private bool pular;
    private float mouseX, mouseY;
    
    [SerializeField] private GameObject barraVida;



    void Start()
    {
        vida = new Vida();
        vida.Canvas = barraVida;
        vida.Camera = GameObject.FindWithTag("Camera");
        vida.VidaMax = 100f;
        vida.VidaAtual = 100f;
        Animador = GetComponent<Animator>();
        Controller = GetComponent<CharacterController>();
        Direcao = this.gameObject.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        mouseX += Input.GetAxis("Mouse X") * dpi; 
        mouseY += Input.GetAxis("Mouse Y") * -dpi;
        if((mouseX >= 30 && mouseX <= 150) && (mouseY >= 30 && mouseY <= 150))
            gameObject.transform.eulerAngles = new Vector3(mouseY,mouseX,0);
        Direcao.x  = CrossPlatformInputManager.GetAxis("Horizontal");
        Direcao.z = CrossPlatformInputManager.GetAxis("Vertical");
        Vector3 movimento = new Vector3(Direcao.x,0,Direcao.z);
        movimento*= velocidade;
        Vector3 v = this.gameObject.transform.eulerAngles;
        movimento = Quaternion.Euler(v.x,0,v.z) * movimento ;
        Controller.SimpleMove(movimento);
        andar = Direcao.z > 0;
        esq = Direcao.x < 0;
        dir = Direcao.x > 0;
        if (Input.GetMouseButtonDown(0))
            atirar = true;
        else if (Input.GetMouseButtonUp(0))
            atirar = false;
        pular = Input.GetKeyDown("space");
        Anima();
    }

    private void Anima()
    {
        if (atirar)
        {
            Animador.SetBool("tiro", atirar);
        }
        else
        {
            Animador.SetBool("anda", andar);
            Animador.SetBool("esq", esq);
            Animador.SetBool("dir", dir);
            Animador.SetBool("tiro", false);   
        }
        
    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (!Morto && collision.gameObject.tag == "MaoZumbi")
        {
            Animador.SetBool("damage",true);
            vida.VidaAtual -= 10;
            if (!vida.vivo())
            {
                Morto = true;
                Animador.SetBool("morto", true);
                return;
            }
        }
    }
}
