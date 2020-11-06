using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Weapon", menuName = "Inventario/Weapons/Generic Weapon")]
public class Weapon : Item
{
    public int atk;
    public int def;
    public int mag;

    public string weaponName;

    private bool equipped = false;

    public override void Use()
    {
        if (equipped == false)
        {
            Debug.Log(weaponName + " equipped\n ATK +" + atk + "\n DEF +" + def + "\nMAG + " + mag);
            equipped = true;
        }
        else
            Debug.Log(weaponName+" already equipped");
    }
}
