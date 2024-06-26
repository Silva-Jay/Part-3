using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ThrowableScript : ItemSlot
{
    public GameObject powder;
    static string currentEffect;
    static int effectChoice;
    string itemname = "Splash Bomb!";

    protected override void Grab()
    {
        itemName = itemname;
        base.Grab();
    }

    protected override void UseItem()
    {
        base.UseItem();
        EffectSelect();
        effect.SetText(currentEffect);
        //throw powder
        GameObject.Instantiate(powder, transform.position, transform.rotation);
    }

    //randomly select effect in use
    static void EffectSelect()
    {
        effectChoice = Random.Range(0, 3);

        switch (effectChoice)
        {
            case 0:
                currentEffect = "Current effect: Poison";
                break;
            case 1:
                currentEffect = "Current effect: Slow";
                break;
            case 2:
                currentEffect = "Current effect: Burn";
                break;
            case 3:
                currentEffect = "Current effect: Confusion";
                break;
        }
    }

}
