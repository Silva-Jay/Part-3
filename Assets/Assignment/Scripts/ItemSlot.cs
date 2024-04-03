using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemSlot : MonoBehaviour
{
    //All grapic assets drawn by Sophia Grasman

    Rigidbody2D rb;
    SpriteRenderer sr;
    protected bool grabbed;
    protected Vector3 originalSlot;
    float size = 1;
    protected bool slotSet = false;

    public ItemSlot weapon;
    public ItemSlot throwable;
    public ItemSlot consumable;

    bool finishedReplace = true;

    ItemSlot selected;

    //item label variables
    public TextMeshProUGUI itemText;
    static protected string itemName;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (finishedReplace == true)
        {

            //set selected item based on key press
            if (Input.GetKeyDown(KeyCode.Q) && grabbed == false)
            {
                grabbed = true;
                selected = weapon;
            }
            else if (Input.GetKeyDown(KeyCode.W) && grabbed == false)
            {
                grabbed = true;
                selected = throwable;
            }
            else if (Input.GetKeyDown(KeyCode.E) && grabbed == false)
            {
                grabbed = true;
                selected = consumable;
            }

            //set original position when item is selected
            if (slotSet == false && selected != null)
            {
                originalSlot = selected.transform.position;
                slotSet = true;
            }

            //reset if space is pressed
            if (Input.GetKeyDown(KeyCode.Space) && grabbed == true)
            {
                grabbed = false;
                itemText.SetText(" ");
                StartCoroutine(Replace());
            }

            //grab item
            if (grabbed == true)
            {
                selected.Grab();
            }
        }

    }

    protected virtual void Grab()
    {
        rb.MovePosition(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        itemText.SetText(itemName);
    }

    //Place the item back in its slot when it gets deselected
    protected IEnumerator Replace()
    {
        finishedReplace = false;
        while (size > 0)
        {
            size -= 1.3f * Time.deltaTime;
            selected.transform.localScale = new Vector3 (size, size, size);
            yield return null;
        }

        selected.rb.MovePosition(originalSlot);

        while (size < 1)
        {
            size += 1.3f * Time.deltaTime;
            selected.transform.localScale = new Vector3(size, size, size);
            yield return null;
        }

        selected = null;
        slotSet = false;
        itemName = string.Empty;

        finishedReplace = true;

    }

    
    
}
