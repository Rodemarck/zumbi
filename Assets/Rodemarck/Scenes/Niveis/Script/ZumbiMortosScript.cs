using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZumbiMortosScript : MonoBehaviour
{
    public bool ativo = true;

    public GameObject alvo;

    public Vida vida;
    // Start is called before the first frame update
    void Start()
    {
        vida = GetComponent<ZumbiScript>().vida;
    }

    // Update is called once per frame
    void Update()
    {
        if (ativo)
        {
            if (!vida.vivo())
            {
                ativo = false;
                alvo.SendMessage("acao");
            }
        }
    }
}
