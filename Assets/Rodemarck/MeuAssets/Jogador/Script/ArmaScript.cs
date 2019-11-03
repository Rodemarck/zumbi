using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ArmaScript : MonoBehaviour
{
    public GameObject bala;
    public Transform transform;
    public float velocidade;
    public float Dano = 5;
    // Start is called before the first frame update
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!IsInvoking("InstanciaBala"))
            {
                InvokeRepeating("InstanciaBala",0f,0.1f);
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            CancelInvoke("InstanciaBala");
        }
    }

    void InstanciaBala()
    {
        if (bala != null)
        {
            GameObject temp = Instantiate(bala) as GameObject;
            temp.SendMessage("Potencia",Dano);
            temp.transform.position = transform.position;
            temp.GetComponent<Rigidbody>().velocity = transform.parent.forward * velocidade;
        }
    }
}
