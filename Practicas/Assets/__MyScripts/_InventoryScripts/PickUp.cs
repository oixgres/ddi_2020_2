using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : Interactable
{
    public GameObject inventoryObject3D = null;

    private Inventory inventory;
    public Item item;

    // Start is called before the first frame update
    void Start()
    {
        //inventory = FindObjectOfType<Inventory>(); //colocar el script hasta arriba
        inventory = Inventory.inventoryInstance;

        if (inventory == null)
        {
            Debug.LogWarning("No se encontro el inventario");
        }
    }

    public override void interact()
    {
        Debug.Log("Tomando Item");
        
        if (inventoryObject3D != null)
        {
            inventoryObject3D.GetComponent<MeshFilter>().mesh = gameObject.GetComponent<MeshFilter>().mesh;
            inventoryObject3D.GetComponent<MeshRenderer>().material = gameObject.GetComponent<MeshRenderer>().material;
            
        }
        else
            inventory.Add(item);

        if (inventory.freespace)//Añadi esta condicion por que no se eliminaba el ultimo item del inventario
        {
            Destroy(gameObject);

            if (inventory.items.Count == inventory.space)
                inventory.freespace = false;
        }
    }
}
