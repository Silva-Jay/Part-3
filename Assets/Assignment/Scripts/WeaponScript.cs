using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : ItemSlot
{

    protected override void Grab()
    {
        itemName = "Weapon!";
        base.Grab();
    }

}
