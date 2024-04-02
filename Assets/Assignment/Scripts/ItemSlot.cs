using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemSlot : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    bool grabbed;
    protected KeyCode grabKey; //key associated with child item slot
    Vector3 originalSlot;
    float size = 1;

    //item label variables
    public TextMeshProUGUI itemText;
    protected string itemName;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
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
            itemText.SetText(itemName);
        }

        if (Input.GetKeyDown(KeyCode.Space) && grabbed == true) 
        {
            grabbed = false;
            StartCoroutine(Replace());
            itemText.SetText(" ");
        }

    }

    //Place the item back in its slot when it gets deselected
    IEnumerator Replace()
    {
        while (size > 0)
        {
            size -= 1.3f * Time.deltaTime;
            transform.localScale = new Vector3 (size, size, size);
            yield return null;
        }

        rb.MovePosition(originalSlot);

        while (size < 1)
        {
            size += 1.3f * Time.deltaTime;
            transform.localScale = new Vector3(size, size, size);
            yield return null;
        }
    }
    
}
