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
        Debug.Log("removendo "+gameObject.name);
        if (prox != null)
        {
            Debug.Log("o prox e "+prox.name);
            prox.SendMessage("acao");
        }
        Destroy(gameObject);
    }
}
