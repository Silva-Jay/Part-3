using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableScript : ItemSlot
{
    protected override void Grab()
    {
        itemName = "Health Potion!";
        base.Grab();
    }
}
