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
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        
        Vector3 frente;
        mouseX += Input.GetAxis("Mouse X") * dpi; 
        mouseY += Input.GetAxis("Mouse Y") * -dpi;

        gameObject.transform.eulerAngles = new Vector3(mouseY,mouseX,0);

        float v = CrossPlatformInputManager.GetAxis("Vertical");
        float h = CrossPlatformInputManager.GetAxis("Horizontal");
        Vector3 movimento = new Vector3(v,0,h);
        if (vida.Camera != null)
        {
            frente = Vector3.Scale(vida.Camera.transform.forward, new Vector3(1, 0, 1)).normalized;
            movimento = v*frente + h*vida.Camera.transform.right;
        }

        movimento *= velocidade;
        /*
        
        
        
        
        
        // Calculate the move direction relative to the character's yaw rotation
        Quaternion yawRotation = Quaternion.Euler(0.0f, gameObject.transform.eulerAngles.y, 0.0f);
        Vector3 forward = yawRotation * Vector3.forward;
        Vector3 right = yawRotation * Vector3.right;
        Vector3 movementInput = (forward * _playerInput.MoveInput.y + right * _playerInput.MoveInput.x);
        
        
        Direcao.x  = CrossPlatformInputManager.GetAxis("Horizontal");
        Direcao.z = CrossPlatformInputManager.GetAxis("Vertical");
        Vector3 movimento = new Vector3(Direcao.x,0,Direcao.z);
        movimento*= velocidade;

        /*Vector3 v = gameObject.transform.eulerAngles;
        movimento = Quaternion.Euler(v.x,0,v.z) * movimento ;
        */
        Controller.SimpleMove(movimento);
        /*andar = Direcao.z > 0;
        esq = Direcao.x < 0;
        dir = Direcao.x > 0;*/
        if (Input.GetMouseButtonDown(0))
            atirar = true;
        else if (Input.GetMouseButtonUp(0))
            atirar = false;
        pular = Input.GetKeyDown("space");
        Anima();
    }

    private void Anima()
    {
        /*if (atirar)
        {
            Animador.SetBool("anda", false);
            Animador.SetBool("esq", false);
            Animador.SetBool("dir", false);
            Animador.SetBool("tiro", true);
            
        }
        else
        {
            Animador.SetBool("anda", andar);
            Animador.SetBool("esq", esq);
            Animador.SetBool("dir", dir);
            Animador.SetBool("tiro", false);   
        }*/
        
    }

    public void RecebeDano(float value)
    {
        if (vida.vivo())
        {
            vida.VidaAtual += value;
            Debug.Log(vida.VidaAtual);
        }
    }


}
