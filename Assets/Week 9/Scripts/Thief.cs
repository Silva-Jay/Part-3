using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Thief : Villager
{
    public GameObject daggerPrefab;
    public Transform daggerSpawn;
    public Transform secondDaggerSpawn;
    Coroutine dashing;
    float dashSpeed = 7;
    protected override void Attack()
    {
        if (dashing != null)
        {
            StopCoroutine(dashing);
        }
        dashing = StartCoroutine(Dash());
    }
    IEnumerator Dash()
    {
        //dash towards mouse
        speed = dashSpeed;
        destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        while (speed > 3)
        {
            yield return null;
        }

        base.Attack();
        yield return new WaitForSeconds(0.1f);
        Instantiate(daggerPrefab, daggerSpawn.position, daggerSpawn.rotation);
        yield return new WaitForSeconds(0.2f);
        Instantiate(daggerPrefab, secondDaggerSpawn.position, secondDaggerSpawn.rotation);
    }

    public override ChestType CanOpen()
    {
        return ChestType.Thief;
    }

}
