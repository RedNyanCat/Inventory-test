﻿using System;
using System.Collections.Generic;

namespace ProjectInventory
{
	
	public class InventoryManager
	{

		private List<Item> inv = new List<Item>(); //the List of items (empty)
		
		public InventoryManager (List<Item> starterInv) //starter inventory setting
		{

			this.inv = starterInv; //setting the starter inv

		}

		public void InventoryAdd(Item i){ //adding an itemstack to the inventory

			inv.Add (i);

		}

		public void InventoryRemove(Item i){ //removing an itemstack from the inventory

			inv.Remove (i);

		}

		public void clearInventory(){ //clearing the inventory

			this.inv.Clear ();

		}

		public List<Item> getInventory(){ //getting the inventory

			return this.inv;

		}

		public void displayInventory(){ //displaying the inventory (with printing to the console)

			Console.WriteLine ("\n"+"*************************");

			foreach (Item item in inv) {

				Console.WriteLine ("Type: " + item.getType() + ", Amount: " + item.getAmount());

			}

			Console.WriteLine ("*************************"+"\n");

		}

	}

}

