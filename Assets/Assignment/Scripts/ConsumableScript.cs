using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableScript : ItemSlot
{
    string itemname = "Health Potion!";
    protected override void Grab()
    {
        itemName = itemname;
        base.Grab();
    }
    protected override void UseItem()
    {
        base.UseItem();
        StartCoroutine(Heal());
    }

    //drink potion
    IEnumerator Heal()
    {
        while (rb.rotation < 40)
        {
            rb.rotation += 1;
            yield return null;
        }

        while (rb.rotation > -20)
        {
            rb.rotation -= 1;
            yield return null;
        }

        while (rb.rotation < 0)
        {
            rb.rotation += 1;
            yield return null;
        }
    }
}
