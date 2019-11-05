using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ArmaScript : MonoBehaviour
{
    public GameObject bala;
    public GameObject canvas;
    public GameObject cano;
    public Transform transform;
    public float velocidade;
    public float precisao = 100;
    public float Dano = 5;
    private int num = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (num > 0)
            num--;
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

        distorce();
    }

    void InstanciaBala()
    {
        if (bala != null && !Cursor.visible)
        {
            GameObject temp = Instantiate(bala) as GameObject;
            num += 5;
            temp.SendMessage("Potencia",Dano);
            temp.transform.position = cano.transform.position;
            temp.GetComponent<Rigidbody>().velocity = cano.transform.parent.forward * velocidade;
        }
    }

    void distorce()
    {
        foreach (Transform t in canvas.transform)
        {
            if(t.gameObject.name == "cima" || t.gameObject.name == "baixo")
                t.gameObject.transform.localScale = new Vector3(1,(float) (100 - num) / 100, 1);
            else 
                t.gameObject.transform.localScale = new Vector3(1,(float) (100 - num) / 100, 1);
        }
        
    }
}
