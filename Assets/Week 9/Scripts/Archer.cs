using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Apple;

public class Archer : Villager
{
    public GameObject arrowPrefab;
    public Transform spawnPoint;
    public float delay = 0.466f;

    protected override void Attack()
    {
        destination = transform.position;
        base.Attack();
        Invoke("SpawnArrow", delay);
    }

    void SpawnArrow()
    {
        Instantiate(arrowPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    public override ChestType CanOpen()
    {
        return ChestType.Archer;
    }
}
