using System;
using System.Collections;
using System.Collections.Generic;
using UniJSON;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.EventSystems;

[System.Serializable]
public class JogadorScript : MonoBehaviour
{
    private Vida vida;
    private bool Morto = false;
    private Animator Animador;
    private CharacterController Controller;
    public GameObject mira;
    [SerializeField][Range(0,20)]public float velocidade = 10;
    [SerializeField][Range(0,30)]public float dpi = 20;
    private bool andar;
    private bool esq;
    private bool dir;
    private bool atirar;
    private bool Armado;
    private float mouseX, mouseY;
    private bool travar = true;
    private float h;
    private float v;
    public bool Travar
    {
        get => travar;
        set => travar = value;
    }
    
    
    [SerializeField]    private GameObject barraVida;
    

    void Start()
    {
        vida = new Vida();
        vida.Canvas = barraVida;
        vida.Camera = GameObject.FindWithTag("Camera");
        vida.VidaMax = 100f;
        vida.VidaAtual = 100f;
        Animador = GetComponent<Animator>();
        Controller = GetComponent<CharacterController>();
        
    }

    private void list(Transform transform)
    {
        Debug.Log(transform.gameObject.name);
        foreach (Transform t in transform)
        {
            list(t);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 frente;
        if (travar)
        {
            mouseX += Input.GetAxis("Mouse X") * dpi; 
            mouseY += Input.GetAxis("Mouse Y") * -dpi;
            
            gameObject.transform.eulerAngles = new Vector3(mouseY,mouseX,0);
            v = CrossPlatformInputManager.GetAxis("Vertical");
            h = CrossPlatformInputManager.GetAxis("Horizontal");
        }
        else
        {
            v = 0;
            h = 0;
        }
        

        Vector3 movimento = new Vector3(v,0,h);
        if (vida.Camera != null)
        {
            frente = Vector3.Scale(vida.Camera.transform.forward, new Vector3(1, 0, 1)).normalized;
            movimento = v*frente + h*vida.Camera.transform.right;
        }

        movimento *= velocidade;
       
        Controller.SimpleMove(movimento);
        
        if (Input.GetMouseButtonDown(0))
            atirar = true;
        else if (Input.GetMouseButtonUp(0))
            atirar = false;
        Anima();
    }

    public void armado()
    {
        Animador.SetBool("armado",true);
    }
    
    public void desarmado()
    {
        Animador.SetBool("armado",false);
    }
    private void Anima()
    {
        if (!Armado)
        {
            Animador.SetBool("socar",atirar);
        }
    }

    public void RecebeDano(float value)
    {
        if (vida.vivo())
        {
            vida.VidaAtual += value;
            Debug.Log(vida.VidaAtual);
        }
    }

    public void fap()
    {
        Debug.Log("ta na hora de fap");
    }

    private void OnAnimatorMove()
    {
        
    }
}
