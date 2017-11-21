using System;
using System.Collections.Generic;

namespace ProjectInventory
{

	// REMEMBER THAT AN ENTITY CAN HAVE SEPERATE LOOT TO ITS INVENTORY THAT CAN BE GIVEN INSTEAD OF ITS CURRENT INVENTORY, A GOOD ALTERNITIVE IF NEED BE //

	public class Entity
	{

		private double health; //entitys health
		private InventoryManager inv; //inventory manager

		private double damage; //player damage

		private List<Item> loot = new List<Item> (); //entitys inventory (starter)

		private List<Player> targets = new List<Player> (); //

		private String name;
		private EntityType etype;
		private int instance; //remove if instance does not
		
		public Entity (double health, double damage, InventoryManager inv, EntityType type) //remove instance if it doesnt work.
		{

			this.health = health;
			this.damage = damage;
			this.inv = inv;

			this.name = type.ToString();
			//this.instance = instance; //remove if instance does not work

			this.etype = type;

			Program.getGamemanager ().addEntity (this);
			//this.instance = Program.getGamemanager ().getInstanceOfEntityFromEntities (this, this.etype);

		}

		public void setDamage(double damage){ //setting the damage

			this.damage = damage;

		}

		public void giveLoot(Player p){ //give loot to a player (works?)

			foreach(Item i in inv.getInventory()){

				p.getInventoryManager ().InventoryAdd (i);

			}

			this.inv.clearInventory ();

		}

		public void giveLoot(Entity e){ //give loot to an entity (works?)

			foreach(Item i in inv.getInventory()){

				e.getInventoryManager ().InventoryAdd (i);

			}

			this.inv.clearInventory ();

		}

		public void calculateInstance(){ //calculates the instance of the entity (should be private)

			this.instance = -1;

			foreach (Entity e in Program.getGamemanager().getEntitiesList()) {

				instance++;

			}

		}

		public EntityType getEntityType(){ //gets the entity type

			return this.etype;

		}

		public void damageEntity(Entity e){ //damages an entity

			e.setHealth (e.getHealth () - damage);

		}

		public void damagePlayer(Player p){ //damages a player

			p.setHealth (p.getHealth () - damage);

		}

		public void setupLoot(List<Item> items){ //sets up the player loot

			foreach (Item item in items) {

				this.loot.Add (item);

			}

		}

		public int getInstance(){ // remove if instance does not work //works?

			return this.instance;

		}

		public EntityType type(){ //gets the entity type || duplicate of getEntityType()

			return this.type();

		}

		/*public void damagePlayer(Player player, /*int instance, *//*double damage){

			//this.targets.Find(i => player.getInstance() == instance).removeHealth(player, damage);

			removeHealth (player, damage);

		}*/

		public void addTarget(Player p){ //adds a player as a target

			this.targets.Add (p);

		}

		public void removeTarget(Player p){ //removes a player as a target

			this.targets.Remove (p);

		}

		public List<Player> getTargets(){ //gets targets

			return this.targets;

		}

		public void setHealth(double health){ //sets the health (commented broken)

			/*if ((this.health + health) > maxhealth) {

				this.health = maxhealth;

			} else if ((this.health - health) < 0) {

				this.health = 0;

			} else {*/

				this.health = health;

			//}

		}

		public void removeHealth(double h){ //removes the health of this entity

			this.setHealth(this.getHealth() - h);

		}

		public void kill(Player p){ //kills a player instantly(sets health and hunger to 0)

			p.setHealth (0);
			p.setHunger (0);

		}

		public void kill(Entity e){ //kills an entity instantly (sets health to 0)

			e.setHealth (0);

		}

		public double getHealth(){ //gets the entitys health

			return this.health;

		}

		public bool isDead(){ //checks if the entity is dead

			if (this.health <= 0) {

				return true;

			}

			return false;

		}

		public void setInventoryManager(InventoryManager invMan){ //sets the inventory manager (can cause problems if someone uses this, inventories can be overridden)

			this.inv = invMan;

		}

		public InventoryManager getInventoryManager(){ //gets the current inventory manager

			return this.inv;

		}

		public List<Item> getLoot(){ //gets the entities loot it has

			return this.loot;

		}

		public String speech(String speech){ //makes the entity speak (does not print to console)

			return (this.name + " : " + instance + " : " + speech);

		}

	}

}

