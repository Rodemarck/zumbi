using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MudaCenaScript : MonoBehaviour
{
    public string proximaCena;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void chamaCena()
    {
        SceneManager.LoadScene(proximaCena);
    }
    
}
