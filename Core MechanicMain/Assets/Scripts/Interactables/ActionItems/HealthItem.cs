using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : ActionItem {
    public PlayerController pController;

    public override void Interact()
    {
        base.Interact();
        pController.IncreaseHealth();
        Debug.Log("Interacting with Health Item");
      
    }
}
