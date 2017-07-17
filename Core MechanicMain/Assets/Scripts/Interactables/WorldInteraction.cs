using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WorldInteraction : MonoBehaviour {
    //NavMeshAgent playerAgent;
    public Transform target;


    private void Start()
    {
        //playerAgent = GetComponent<NavMeshAgent>();   
        
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            GetInteraction();
        }
    }

    void GetInteraction()
    {
        Ray interactionRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit interactionInfo;
        if(Physics.Raycast(interactionRay, out interactionInfo, Mathf.Infinity))
        {
            //STORE OBJECT THAT YOU HIT
            GameObject interactedObject = interactionInfo.collider.gameObject;
            if(interactedObject.tag == "Interactable Object")
            {
                Debug.Log("Interactable Object Interacted");
                interactedObject.GetComponent<Interactable>().MoveToInteraction(interactedObject, target);
;           }
            /*else
            {
               playerAgent.destination = interactionInfo.point;
            }*/
        }
    }
}
