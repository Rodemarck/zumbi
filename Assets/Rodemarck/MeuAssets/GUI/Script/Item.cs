using UniGLTF;
using UniHumanoid;
using UnityEngine;

/* The base item class. All items should derive from this. */

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject {

    new public string name = "New Item";	// Name of the item
    public Sprite icon = null;				// Item icon
    public bool isDefaultItem = false;      // Is the item default wear?
    private bool procura;
    public GameObject itemGameObject;
    

    // Called when the item is pressed in the inventory
    public virtual void Use ()
    {
        /*procura = true;
        find(GameObject.FindWithTag("Jogador").transform);*/

    }

    public void find(Transform trans)
    {
        Debug.Log(trans.gameObject.name);
        if (trans.gameObject.name == "Arma")
        {
            procura = false;
            foreach (Transform t in trans)
            {
                Destroy(t.gameObject);
            }

            GameObject temp = Instantiate(itemGameObject) as GameObject;
            temp.GetComponent<ArmaScript>().canvas = GameObject.Find("BarraDeVida");
            temp.transform.parent = trans;
        }
            
        foreach (Transform t in trans)
        {
            if (!procura)
                return;
            find(t);
        }
    }

    public void RemoveFromInventory ()
    {
        Inventory.instance.Remove(this);
    }
	
}