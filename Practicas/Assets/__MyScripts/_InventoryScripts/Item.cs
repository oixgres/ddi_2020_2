using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemType
{ 
    Weapon,
    Equip,
    Collectable,
    Aliment
}

[CreateAssetMenu(fileName = "Nuevo Item", menuName = "Inventario/Generic Item")]

public class Item : ScriptableObject 
{
    public Sprite sprite = null;
    public ItemType itemType = ItemType.Weapon;

    public virtual void Use()
    {
        Debug.Log("Usando item");
    }
}