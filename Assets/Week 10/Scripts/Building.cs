using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public Transform bottom;
    public Transform middle;
    public Transform top;
    float interpolation;

    // Start is called before the first frame update
    void Start()
    {
        bottom.localScale = new Vector3(1, 0, 1);
        middle.localScale = new Vector3(1, 0, 1);
        top.localScale = new Vector3(1, 0, 1);

        StartCoroutine (Build());
    }

    IEnumerator Build()
    {
        while (bottom.localScale != Vector3.one)
        {
            bottom.localScale = Vector3.Lerp(new Vector3(1, 0, 1), Vector3.one, interpolation);
            interpolation += 0.01f;
            yield return null;
        }

        interpolation = 0;

        while (middle.localScale != Vector3.one)
        {
            middle.localScale = Vector3.Lerp(new Vector3(1, 0, 1), Vector3.one, interpolation);
            interpolation += 0.01f;
            yield return null;
        }

        interpolation = 0;

        while (top.localScale != Vector3.one)
        {
            top.localScale = Vector3.Lerp(new Vector3(1, 0, 1), Vector3.one, interpolation);
            interpolation += 0.01f;
            yield return null;
        }
    }
}
