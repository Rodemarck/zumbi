using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaosZumbi : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Jogador")
        {
            other.gameObject.SendMessage("RecebeDano",15);
        }
    }
}
