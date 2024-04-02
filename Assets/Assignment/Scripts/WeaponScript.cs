using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : ItemSlot
{
    protected override void Start()
    {
        base.Start();
        grabKey = KeyCode.Q;
        itemName = "Weapon";
    }

}
