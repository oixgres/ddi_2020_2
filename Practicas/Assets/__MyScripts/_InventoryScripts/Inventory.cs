using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    static protected Inventory s_InventoryInstance;
    static public Inventory inventoryInstance { get { return s_InventoryInstance; } }

    public int space = 3;
    public bool freespace = true;
    public List<Item> items = new List<Item>();
    public List<int> itemsCount = new List<int>();

    public delegate void OnChange();
    public OnChange onChange;

    public void Awake()
    {
        s_InventoryInstance = this;
    }

    public void Add(Item item)
    {
        if (items.Count < space)
        {
            if (items.Contains(item) != true)
            {
                items.Add(item);
                itemsCount.Add(1);

               if (onChange != null)
                    onChange.Invoke();

                Debug.LogWarning("Nuevo item no." + items.Count.ToString() + "\n El espacio es: "+space.ToString());

            }
            else
                for (int i = 0; i < items.Count; i++)
                {
                    if (items[i] == item)
                        itemsCount[i]++;
                }    
        }
        else
        {
            Debug.LogWarning("There's no enough space");
        }
    }

    public void Remove(Item item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
            
            if (onChange != null)
                onChange.Invoke();
        }
        else
        {
            Debug.LogWarning("Couldn't find item");
        }
    }
}
