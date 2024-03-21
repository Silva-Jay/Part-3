using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using TMPro;

public class CharacterControl : MonoBehaviour
{
    public static Villager SelectedVillager { get; private set; }
    public static CharacterControl instance;
    public TextMeshProUGUI characterText;

    public Villager merchant;
    public Villager thief;
    public Villager archer;
    float villagerSize = 1;

    private void Start()
    {
        instance = this;
        SetSelectedVillager(merchant);
    }
    public static void SetSelectedVillager(Villager villager)
    {
        if(SelectedVillager != null)
        {
            SelectedVillager.Selected(false);
        }
        SelectedVillager = villager;
        SelectedVillager.Selected(true);

        changeText();
    }

    private void Update()
    {
        if (SelectedVillager != null)
        {
            if (SelectedVillager.movement.x > 0)
            {
                SelectedVillager.transform.localScale = new Vector2(-villagerSize, villagerSize);
            }
            else if (SelectedVillager.movement.x < 0)
            {
                SelectedVillager.transform.localScale = new Vector2(villagerSize, villagerSize);
            }
        }
    }
    public void ResizeVillager(float value)
    {
        villagerSize = value;
    }

    static void changeText()
    {
        instance.characterText.text = (SelectedVillager.name); 
    }

    public void CharacterDropdown(Int32 value)
    {
        switch (value)
        {
            case 0:
                SetSelectedVillager(merchant);
                break;
            case 1:
                SetSelectedVillager(archer);
                break;
            case 2:    
                SetSelectedVillager(thief); 
                break;
        }
    }
    
}
