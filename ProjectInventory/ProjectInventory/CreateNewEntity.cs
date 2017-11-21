using System;
using System.Collections.Generic;

namespace ProjectInventory
{
	
	public class CreateNewEntity
	{

		//double health, double maxhealth, InventoryManager inv, EntityType type

		public static Entity createEntity(EntityType e){ //creates a new entity with an entity type

			Entity en = new Entity (5.00, 0.50, new InventoryManager (new List<Item> ()), e);

			en.calculateInstance ();

			return en;
		}

		public static Entity createEntity(EntityType e, double health){ //creates a new entity with an entity type and a double health

			Entity en = new Entity (health, 0.50, new InventoryManager (new List<Item> ()), e);

			en.calculateInstance ();

			return en;
		}

		public static Entity createEntity(EntityType e, double health, double damage, List<Item> items){ //creates an entity with an entity type, double health, double damage and a List<Item>

			Entity en = new Entity (health, damage, new InventoryManager (items), e);

			en.calculateInstance ();

			return en;
		}

		public static Entity createEntity(EntityType e, List<Item> items){ //creates a new entity with an entity type and a List<Item>

			Entity en = new Entity (5.00, 0.50, new InventoryManager (items), e);

			en.calculateInstance ();

			return en;

		}

	}

}

