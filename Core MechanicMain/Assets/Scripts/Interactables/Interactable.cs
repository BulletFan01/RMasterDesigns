using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {
    /*public NavMeshAgent playerAgent;

	public virtual  void MoveToInteraction(NavMeshAgent playerAgent)
    {
        this.playerAgent = playerAgent;
    }*/
    private Transform thisTarget;
    GameObject thisInteractedObject;
    private bool hasInteracted = true;

    public virtual void MoveToInteraction(GameObject interactedObject, Transform target)
    {

        thisTarget = target;
        thisInteractedObject = interactedObject;
        float distance = Vector3.Distance(thisTarget.position, thisInteractedObject.transform.position);
        if (distance <= 1.5)
        {
            Debug.Log(distance);
            hasInteracted = false;
        }
    }

    void Update()
    {
        if(!hasInteracted)
        {
             hasInteracted = true;
             Interact();                     
        }
    }

    public virtual void Interact()
    {
        Debug.Log("Interacting with base class");
    }
}
