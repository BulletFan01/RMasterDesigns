using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : ActionItem {
    public PlayerController pController;
    public NPC npc;

    public override void Interact()
    {
        base.Interact();
        
        Debug.Log("Interacting with Health Item");
      
    }

    void OnTriggerEnter(Collider other)
    {
       
            Destroy(this.gameObject);
            pController.IncreaseHealth(35);
            npc.TookHealth();
    }
}
