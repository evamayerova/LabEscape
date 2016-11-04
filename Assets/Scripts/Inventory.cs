using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public struct InventoryItem
{
	public string name;
	public int count;
}

public class Inventory : MonoBehaviour {

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
