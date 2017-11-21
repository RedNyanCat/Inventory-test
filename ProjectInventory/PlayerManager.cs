using System;
using System.Collections.Generic;

namespace ProjectInventory
{
	
	public class Player
	{

		private double health; //how much health the player has
		private double hunger; //how much hunger the player has

		private double damage; //how much damage the player does

		private double maxHunger = 5.00; //max hunger (not-working)

		private String name; //the players display name

		private InventoryManager inv; //the players inventory manager

		private List<Entity> targets = new List<Entity>(); //the players targets (idk what this does personally)

		private int instance; //the players instance

		public Player (double health, double hunger, double damage, InventoryManager inv, String name) //setting the player up
		{

			//all of the stats
			this.health = health; 
			this.hunger = hunger;
			this.damage = damage;
			this.inv = inv;
			this.name = name;

			Program.getGamemanager ().addPlayer (this); //setting the player inside the main GameManager
			//this.instance = Program.getGamemanager ().getInstanceOfEntityFromEntities (this, this.etype);

		}

		public void setDamage(double damage){ //sets the damage of the player

			this.damage = damage;

		}

		public void giveLoot(Entity e){ //gives the entity the players inventory (broken?)

			foreach(Item i in inv.getInventory()){

				e.getInventoryManager ().InventoryAdd (i);

			}

			this.inv.clearInventory (); //works?

		}

		public void giveLoot(Player p){ //gives the player the players inventory (broken?)
			
			foreach(Item i in inv.getInventory()){

				p.getInventoryManager ().InventoryAdd (i);

			}

			this.inv.clearInventory (); //works?

		}

		public void calculateInstance(){ //calculates the players instance (should be private, fix later otherwise there WILL be problems

			this.instance = -1;

			foreach (Player p in Program.getGamemanager().getPlayerList()) {

				instance++;

			}

		}

		public void damageEntity(Entity e){ //damages the entity

			e.setHealth (e.getHealth () - damage); 

		}

		public void damagePlayer(Player p){ 

			p.setHealth (p.getHealth () - damage); //damages the player

		}

		public int getInstance(){ //gets the instance

			return this.instance;

		}

		public String getName(){ //gets the players name

			return this.name;

		}

		public void setHealth(double health){ // These are broken! (PlayerManager + entityManager), the health getting too high or low is far from fixed.

			/*if ((health + this.getHealth()) > maxHealth) {

				Console.WriteLine ("TOO HIIIGGGHHH");

				this.health = maxHealth;

			} else if ((health - this.getHealth()) < 0) {

				Console.WriteLine ("TOO SMMMAAALLLLL");

				this.health = 0;

			} else {*/

				this.health = health;

			//}

		}

		public void removeHealth(double h){ //removes the players health.

			this.setHealth(this.getHealth() - h);

		}

		public void setHunger(double hunger){ //sets the players hunger

			if (hunger > maxHunger) {

				this.hunger = maxHunger;

				return;

			}

			this.hunger = hunger;

		}

		public double getHealth(){ //gets the players health

			return this.health;

		}

		public double getHugner(){ //gets the players hunger

			return this.hunger;

		}

		public void addTarget(Entity e){ //adds a target (entity) to the players targets (idk what this does)

			this.targets.Add (e);

		}

		public void removeTarget(Entity e){ //removes a target (entity) from a players targets (idk what this does)

			this.targets.Remove (e);

		}

		public List<Entity> getTargets(){ //gets the targets (whole list, not the individuals)

			return this.targets;

		}

		/*public void damageEntity(Entity entity, /*int instance, *//*double damage){*/ // FIX THIS LATER // OTHERWISE YOU CANNOT ATTACK!! //

			//this.targets.Find(i => entity.getInstance() == instance).removeHealth(entity, damage);

			/*removeHealth (entity, damage);

		}*/

		public void giveItem(Item item, Player p){ //gives an item to a player

			this.inv.InventoryRemove (item);
			p.inv.InventoryAdd (item);

		}

		public void kill(Player p){ //kills a player instantly. (sets health to 0 and hunger to 0)

			p.setHealth (0);
			p.setHunger (0);

		}

		public void kill(Entity e){ //kills an entity instantly. (sets health to 0)

			e.setHealth (0);

		}

		public bool isDead(){ //checks if the player is dead

			if (getHealth() <= 0) {

				return true;

			}

			return false;

		}

		public bool isHungry(){ //checks if the player is hungry (un-tested and un-used)

			if (this.hunger < 0) {

				return true;

			}

			return false;

		}

		public void setInventoryManager(InventoryManager invManager){ //sets the ivnentory manager (can be duplicates but that can lead to problems

			this.inv = invManager;

		}

		public InventoryManager getInventoryManager(){ //gets the inventory manager

			return this.inv;

		}

		public String speech(String speech){ //lets the player speak in the console, but it doesnt do it automatically.

			return (this.name + " : " + instance + " : " + speech);

		}

	}

}

