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
    void Start()
    {
        inventario = Inventory.instance;
        inventario.onItemChangedCallback += UpdateUI;
        slots = bolsa.GetComponentsInChildren<InventorySlot>();
    }

    private void Update()
    {
        if (Input.GetKeyDown("i"))
        {
            //if(outroCanvas != null)
            outroCanvas.SetActive(inventoryUI.activeSelf);
            inventoryUI.SetActive(!inventoryUI.activeSelf);
            Cursor.visible = inventoryUI.activeSelf;
            
        }
    }

    // Update is called once per frame
    void UpdateUI()
    {
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
