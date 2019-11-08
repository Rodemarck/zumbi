using System;
using UniGLTF;
using UniHumanoid;
using UnityEngine;

/* The base item class. All items should derive from this. */

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject {

    new public string name = "New Item";	// Name of the item
    public Sprite icon = null;				// Item icon
    public GameObject itemGameObject;
    public GameObject itemPickup;
    public bool arma;
    private JogadorScript script;    


    public JogadorScript Script
    {
        get {
            if (script == null)
            {
                script = GameObject.FindWithTag("Jogador").GetComponent<JogadorScript>();
            }

            return script;
        }
    }

    private void posiciona(GameObject gameObject)
    {
        gameObject.transform.parent = GameObject.Find("Arma").transform;
        gameObject.transform.localPosition= Vector3.zero;
        gameObject.transform.localScale = Vector3.one;
        gameObject.transform.localEulerAngles = Vector3.zero;
    }
    // Called when the item is pressed in the inventory
    public virtual void Use ()
    {
        if (arma)
        {
            if (GameObject.FindWithTag("Arma") == null)
            {
                Debug.Log("criando");
                GameObject temp = Instantiate(itemGameObject);
                posiciona(temp);
                temp.GetComponent<ArmaScript>().canvas = Script.mira;
                Script.armado();
            }
            else
            {
                remove();
            }
        }
    }

    public void remove()
    {
        Debug.Log("removendo "+GameObject.FindWithTag("Arma").name);
        Destroy(GameObject.FindWithTag("Arma"));
        Script.desarmado();
    }

    public void RemoveFromInventory ()
    {
        if (arma)
        {
            if(GameObject.FindWithTag("Arma") != null)
                remove();
            Inventory.instance.Remove(this);
            GameObject temp = Instantiate(itemPickup);
            posiciona(temp);
            temp.transform.parent = null;
            
        }
    }
	
}