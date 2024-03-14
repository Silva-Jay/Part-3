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

    private void Start()
    {
        instance = this;
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

    static void changeText()
    {
        instance.characterText.text = (SelectedVillager.name); 
    }
    
}
