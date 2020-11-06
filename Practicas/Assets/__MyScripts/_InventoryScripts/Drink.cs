using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Food", menuName = "Inventario/Aliments/Generic Drink")]

public class Drink : Item
{
    public int restoreHP;
    public float weight; 

    public void Awake()
    {
        itemType = ItemType.Aliment;
    }

    public override void Use()
    {
        Debug.Log("Drinking "+name+"\n"+restoreHP.ToString()+" HP restored");
    }
}
