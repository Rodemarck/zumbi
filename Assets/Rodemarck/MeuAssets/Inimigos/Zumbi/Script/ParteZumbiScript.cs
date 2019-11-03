using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ParteZumbiScript : MonoBehaviour
{
    public  GameObject Zumbi;

    public float Multiplicador;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void tiro(float value)
    {
        Debug.Log("hit" + value);
        Zumbi.SendMessage("dano",(-value * Multiplicador));
    }
}
