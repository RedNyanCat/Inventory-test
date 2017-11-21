using System;
using System.Collections.Generic;

namespace ProjectInventory
{
	
	public class CreateNewPlayer
	{

		public static Player createPlayer(String name){ //creates a new player with just the input of a name

			Player p = new Player (5.00, 5.00, 0.50, new InventoryManager (new List<Item> ()), name);

			p.calculateInstance ();

			return p;

		}

		public static Player createPlayer(List<Item> items, String name){ //creates a new player with input of a name and a List<Item>

			Player p =  new Player (5.00, 5.00, 0.50, new InventoryManager (items), name);

			p.calculateInstance ();

			return p;

		}

		public static Player createPlayer(List<Item> items, double health, String name){ //creates a new player with input of a name, a double (health) and a List<Item>

			Player p = new Player (health, 5.00, 0.50, new InventoryManager (items), name);

			p.calculateInstance ();

			return p;

		}

		public static Player createPlayer(List<Item> items, double health, double hunger, String name){ //creates a new player with input of a name, a double health, a double hunger, and a List<Item>

			Player p = new Player (health, hunger, 0.50, new InventoryManager (items), name);

			p.calculateInstance ();

			return p;

		}

		public static Player createPlayer(List<Item> items, double health, double hunger, double damage, String name){ //creates a new player with input of a name, a double hunger, a double health, a double damage and a List<Item>

			Player p = new Player (health, hunger, damage, new InventoryManager (items), name);

			p.calculateInstance ();

			return p;

		}

		public static Player createPlayer(double health, String name){ //creates a new player with a double health and a String name

			Player p = new Player (health, 5.00, 0.50, new InventoryManager (new List<Item> ()), name);

			p.calculateInstance ();

			return p;

		}

		public static Player createPlayer(double health, double hunger, String name){ //creates a new player with a double for health, a double for hunger and a String name

			Player p =  new Player (health, hunger, 0.50, new InventoryManager (new List<Item> ()), name);

			p.calculateInstance ();

			return p;

		}

	}

}

