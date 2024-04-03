using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemSlot : MonoBehaviour
{
    //Assignment 3 - Hotbar/Quick Equip System
    //All grapic assets drawn by Sophia Grasman

    //components
    protected Rigidbody2D rb;
    SpriteRenderer sr;

    //item currently grabbed
    protected bool grabbed;

    //vector for original hotbar position
    protected Vector3 originalSlot;

    //size of equipped item
    float size = 1;

    //original slot set?
    protected bool slotSet = false;

    //items
    public ItemSlot weapon;
    public ItemSlot throwable;
    public ItemSlot consumable;

    //finished replace coroutine?
    protected bool finishedReplace = true;

    //currently selected item
    ItemSlot selected;

    //text GUI
    public TextMeshProUGUI itemText;
    public TextMeshProUGUI usedNotif;
    public TextMeshProUGUI effect;
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
                usedNotif.SetText(" ");
                effect.SetText(" ");
                size = 1;
                StartCoroutine(Replace());
            }

            //grab item
            if (grabbed == true)
            {
                selected.Grab();
            }

            //use item
            if (Input.GetMouseButtonDown(0) && grabbed == true)
            {
                selected.StartCoroutine(UseItemFlash());
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

        Debug.Log("replaced!");

        selected = null;
        slotSet = false;
        itemName = string.Empty;

        finishedReplace = true;

    }

    //flash item when used
    protected virtual IEnumerator UseItemFlash()
    {
        selected.sr.color = Color.yellow;
        yield return new WaitForSeconds(.1f);
        selected.sr.color = Color.white;
        yield return new WaitForSeconds(.1f);
        selected.sr.color = Color.yellow;
        yield return new WaitForSeconds(.1f);
        selected.sr.color = Color.white;
        yield return new WaitForSeconds(.1f);

        selected.UseItem();

    }

    protected virtual void UseItem()
    {
        usedNotif.SetText("Item Used!");
    }
    
}
