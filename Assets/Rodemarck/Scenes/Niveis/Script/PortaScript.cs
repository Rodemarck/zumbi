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
        }
        else
        {
            if (vertical)
                v.y -= deslocamento;
            else
                v.x -= deslocamento;
        }
        aberto = !aberto;
        transform.position = v;
    }
}
