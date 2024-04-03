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

    protected override void UseItem()
    {
        base.UseItem();
        StartCoroutine(SwordSlash());
    }

    protected IEnumerator SwordSlash()
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
