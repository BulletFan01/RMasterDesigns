using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item {
    public string ItemName { get; set; }
    public string Description { get; set; }
    public string ActionName { get; set; }//Drink, use, drop, give
    public bool ItemModifier { get; set; }//Does it modify a stat of the player

    public Item(string _ItemName, string _Description, string _ActionName, bool _ItemModifier)
    {
        this.ItemName = _ItemName;
        this.Description = _Description;
        this.ActionName = _ActionName;
        this.ItemModifier = _ItemModifier;
    }
}
