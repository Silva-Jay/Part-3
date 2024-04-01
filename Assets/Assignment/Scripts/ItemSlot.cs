using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlot : MonoBehaviour
{
    Rigidbody2D rb;
    bool grabbed;
    protected KeyCode grabKey; //key associated with child item slot
    Vector3 originalSlot;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Debug.Log("Hello!");
        originalSlot = transform.position;
    }

    // Update is called once per frame
    protected void Update()
    {
        if (Input.GetKeyDown(grabKey))
        {
            grabbed = true;
        }

        if (grabbed == true)
        {
            rb.MovePosition(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }

        if (Input.GetKeyDown(KeyCode.Space) && grabbed == true) 
        {
            grabbed = false;
            rb.MovePosition(originalSlot);
        }
    }
    
}
