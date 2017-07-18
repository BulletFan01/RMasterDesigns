using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public string[] dialogue;
    public string npcName;
    bool tookHealth = false;

	/*public override void Interact()
    {
        DialogueSystem.Instance.AddNewDialogue(dialogue, npcName);
        Debug.Log("Interacting with NPC");
    }*/
    public void TookHealth()
    {
        tookHealth = true;
    }

    void OnTriggerEnter(Collider other)
    {     
        if(!tookHealth)
            DialogueSystem.Instance.AddNewDialogue(dialogue, npcName);
       // Interact();
    }
}
