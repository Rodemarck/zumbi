using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class BalaScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float dano;
    public float potencia;
    
    public void Potencia(float value){
        potencia = value;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.SendMessage("tiro", dano * potencia);
        Destroy(this.gameObject);
    }
}
