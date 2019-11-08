using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class InventarioUI : MonoBehaviour
{
    private Inventory inventario;
    public Transform bolsa;
    private InventorySlot[] slots;
    public GameObject inventoryUI;
    public GameObject outroCanvas;
    public JogadorScript script;

    private void Awake()
    {
        
    }

    void Start()
    {
        inventario = Inventory.instance;
        inventario.onItemChangedCallback += UpdateUI;
        slots = bolsa.GetComponentsInChildren<InventorySlot>();
        script = GameObject.FindWithTag("Jogador").GetComponent<JogadorScript>();
        script.Travar = true;
        outroCanvas.SetActive(true);
        inventoryUI.SetActive(false);
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown("i"))
        {
            script.Travar = inventoryUI.activeSelf;
            outroCanvas.SetActive(inventoryUI.activeSelf);
            inventoryUI.SetActive(!inventoryUI.activeSelf);
            Cursor.visible = inventoryUI.activeSelf;
        }
    }

    // Update is called once per frame
    void UpdateUI()
    {
        Debug.Log("atulizando");
        Debug.Log(slots);
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventario.items.Count)
            {
                slots[i].AddItem(inventario.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
    
    
}
