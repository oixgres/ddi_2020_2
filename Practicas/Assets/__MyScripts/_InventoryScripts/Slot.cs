using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public bool use3d = false;

    public Item item;
    public Image image;
    public Text itemCount;
    private Inventory inventory;

  //  public GameObject inventoryObject3D;
  //  public GameObject originalObject3D;

    // Start is called before the first frame update
    void Start()
    {
        // inventory = FindObjectOfType<Inventory>();
        inventory = Inventory.inventoryInstance;

        if (inventory == null)
            return;

        if (use3d == false)
            image.sprite = item.sprite; //1:00:16
        
    }

    public void setItem(Item item)
    {
        //  inventoryObject3D.GetComponent<MeshFilter>().mesh = gameObject.GetComponent<MeshFilter>().mesh;
        //  inventoryObject3D.GetComponent<MeshRenderer>().material = gameObject.GetComponent<MeshRenderer>().material;

        if (use3d == false)
        {
            Debug.Log("Asignando imagen");

            this.item = item;
            image.sprite = item.sprite;
            image.enabled = true;

            for (int i = 0; i < inventory.itemsCount.Count; i++)
                if (inventory.items[i] == item)
                    itemCount.text = inventory.itemsCount[i].ToString();

        }
        else
        {
            Debug.Log("Asignando objeto 3d");
        }
    }

    public void clear()
    {
        if (use3d == false)
        {
            this.item = null;
            image.sprite = null;
            image.enabled = false;
        }
    }
    public void removeFromInventory()
    {
        if (this.item != null)
        {
            for (int i = 0; i < inventory.items.Count; i++)
            {
                if (item == inventory.items[i])
                {
                    if (inventory.itemsCount[i] == 1)/*Si solo tenemos un item*/
                    {
                        inventory.items.RemoveAt(i);
                        inventory.itemsCount.RemoveAt(i);
                        itemCount.text = "0";
                        image.enabled = false;
                        this.GetComponent<Button>().enabled = false;
                    }
                    else /*Si tenemos mas de un item*/
                    {
                        inventory.itemsCount[i]--;
                        itemCount.text = inventory.itemsCount[i].ToString();
                    }
                }
            }
        }
    }

    public void useItem()
    {
        if (use3d == false)
            if (item != null)
            {
                item.Use();

                if (item.itemType == ItemType.Aliment)
                    removeFromInventory();
            }
            else
                image.enabled = false;
        else
            item.Use();
    }
}
