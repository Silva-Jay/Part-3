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

    public override ChestType CanOpen()
    {
        return ChestType.Thief;
    }

    protected override void Attack()
    {
        speed = 5;
        destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        base.Attack();
        Instantiate(daggerPrefab, daggerSpawn.position, daggerSpawn.rotation);
        Instantiate(daggerPrefab, secondDaggerSpawn.position, secondDaggerSpawn.rotation);
        Invoke("reset", 0.5f);
    }

    void reset()
    {
        speed = 3;
        destination = transform.position;
    }

}
