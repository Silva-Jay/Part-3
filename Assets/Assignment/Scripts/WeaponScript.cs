using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : ItemSlot
{
    string itemname = "Weapon!";
    protected override void Grab()
    {
        itemName = itemname;
        base.Grab();
    }

    protected override void UseItem()
    {
        base.UseItem();
        StartCoroutine(SwordSlash());
    }

    IEnumerator SwordSlash()
    {
        while (rb.rotation < 60)
        {
            rb.rotation += 1;
            yield return null;
        }

        while(rb.rotation > 0) 
        { 
            rb.rotation -= 1;
            yield return null;
        }
    }

}
