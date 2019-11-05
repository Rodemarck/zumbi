using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaScript : MonoBehaviour
{
    public bool aberto;
    public bool vertical;
    public float deslocamento;
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
        Vector3 v = new Vector3();
        v.x = transform.position.x;
        v.y = transform.position.y;
        v.z = transform.position.z;
        if (aberto)
        {
            if (vertical)
                v.y += deslocamento;
            else
                v.x += deslocamento;
            Debug.Log("fechando "+gameObject.name);
        }
        else
        {
            if (vertical)
                v.y -= deslocamento;
            else
                v.x -= deslocamento;
            Debug.Log("abrindo "+gameObject.name);
        }

        if (prox != null)
        {
            Debug.Log("o prox e "+prox.name);
            prox.SendMessage("acao");
        }
        aberto = !aberto;
        transform.position = v;
    }
}
