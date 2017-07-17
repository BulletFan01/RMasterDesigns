using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour {

    public Item itemRuby;

	// Use this for initialization
	void Start () {
        itemRuby = new Item("Ruby","Give to Mr. Sly", "Give", false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
