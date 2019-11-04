using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculoScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prox;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void acao()
    {
        if (prox != null)
        {
            prox.SendMessage("acao");
        }    
        Destroy(gameObject);
    }
}
