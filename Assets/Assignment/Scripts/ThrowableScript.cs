using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableScript : ItemSlot
{

    protected override void Grab()
    {
        itemName = "Splash Bomb!";
        base.Grab();
    }
}
