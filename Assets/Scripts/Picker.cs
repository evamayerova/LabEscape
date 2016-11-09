using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public struct InventoryItem
{
	public string name;
	public int count;
}

public class Inventory
{
	public List<InventoryItem> items = new List<InventoryItem> ();
	
	// add object to inventory
	public void AddObject (string name)
	{
		bool added = false;
		
		// try to find the same object in inventory
		for (int i = 0; i < items.Count; i++) {
			// if so, increase counter
			if (items[i].name == name)
			{
				// cannot be change directly, temp variable needed
				var item = items[i];
				item.count++;
				items[i] = item;
				added = true;
				break;
			}
		}
		
		if (!added) {
			// add completely new object
			items.Add(new InventoryItem(){name = name, count = 1});
		}
	}
}

public class Picker : MonoBehaviour {
	
	private Inventory inventory;
	// Use this for initialization
	void Start () {
		inventory = new Inventory ();
	}

	void OnTriggerEnter2D(Collider2D c)
	{
		// if trigger object is pickable, add item to inventory
		if (c.gameObject.tag == "Pick Up") {
			c.gameObject.SetActive (false);
			inventory.AddObject(c.name);
		}
	}
}
