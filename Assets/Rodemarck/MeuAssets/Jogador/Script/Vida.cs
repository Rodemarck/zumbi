using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    private float vidaMax;
    private float vidaAtual;
    private GameObject canvas;
    private GameObject _camera;
    public bool vivo()
    {
        return vidaAtual > 0f;
    }

    public float VidaAtual
    {
        get => vidaAtual;
        set {
            if (value < 0)
            {
                vidaAtual = 0;
                
            }
            else if (value > vidaMax)
            {
                vidaAtual = vidaMax;
            }
            else
            {
                vidaAtual = value;  
            } 
            renderiza();
        }
    }

    public float VidaMax
    {
        get => vidaMax;
        set
        {
            if (value >= 0)
            {
                if (value < vidaAtual)
                    vidaAtual = value;
                vidaMax = value;
            }
                
        }
    }

    public GameObject Canvas
    {
        get => canvas;
        set => canvas = value;
    }

    public GameObject Camera
    {
        get => _camera;
        set => _camera = value;
    }

    private void renderiza()
    {
        canvas.transform.localScale = new Vector3((vidaAtual/vidaMax),1,1);
    }

    private void LateUpdate()
    {
        if (_camera != null)
        {
            transform.LookAt(_camera.transform.forward);
            transform.Rotate(0, 180, 0);
        }
        else Debug.Log("null");
    }
}
