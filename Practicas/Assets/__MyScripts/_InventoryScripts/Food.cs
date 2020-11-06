using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


[CreateAssetMenu(fileName = "New Food", menuName = "Inventario/Aliments/Generic Food")]
public class Food : Item
{
    public float restoreHP;
    public float weight; //in kg

    public void Awake()
    {
        itemType = ItemType.Aliment;
    }

    public override void Use()
    {
        Debug.Log("Eating "+name+"\n"+restoreHP.ToString()+" HP points restored");
    }
}
