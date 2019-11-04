using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntanciadorInimigosScript : MonoBehaviour
{
    public GameObject posicao;
    public GameObject inimigo;
    public GameObject contador;
    public int numero;
    
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
        for (int i = 0; i < numero; i++)
        {
            GameObject temp = Instantiate(inimigo) as GameObject;
            temp.AddComponent<ZumbiMortosScript>();
            temp.GetComponent<ZumbiMortosScript>().alvo = contador;
            temp.transform.position = posicao.transform.position;
        }
    }
    
}
