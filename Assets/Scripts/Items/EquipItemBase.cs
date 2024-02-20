using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipItemBase
{
    public int slot;
    public string itemName;
    public List<string> functions;

}
public class Weapon : EquipItemBase
{
    int damage;
    int attackSpeed;
    Weapon()
    {
        this.slot = 1;
    }
}
