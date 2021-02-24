using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Ammo", menuName = "Items/Ammo", order = 20)]
public class ItemAmmo : ItemBase
{
    public int ammoCount = 5;

    public override string ShowInfo()
    {
        string old = base.ShowInfo();
        old += $"Кол-во снарядов: {ammoCount}";

        return old;
    }
}
