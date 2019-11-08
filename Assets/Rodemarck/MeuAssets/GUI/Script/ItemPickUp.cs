using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    private GameObject player;
    public GameObject canvas;
    public GameObject alvo;
    public GameObject prox;
    public Item item;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Jogador");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            if (Vector3.Distance(transform.position, player.transform.position) < 2)
            {
                Debug.Log("pegando a " + item.name);
                PickUp();
                if (alvo != null)
                {
                    alvo.SendMessage("acao");
                    if (prox != null)
                    {
                        prox.SendMessage("acao");
                    }
                }
            }
        }
    }

    public void acao()
    {
        PickUp();
    }

    public void PickUp()
    {
        Debug.Log("pegando item");
        bool check = Inventory.instance.Add(item);
        if(check)
            Destroy(gameObject);
    }
    
}
