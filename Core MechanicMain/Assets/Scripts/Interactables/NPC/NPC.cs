using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public string[] dialogue;
    public string[] dialogue1;
    public string npcName;
    bool tookHealth = false;
    bool finished = false;

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
        else
        {
            if (!finished)
            {
                DialogueSystem.Instance.AddNewDialogue(dialogue1, npcName);
                finished = true;
            }
        }
       // Interact();
    }
}
