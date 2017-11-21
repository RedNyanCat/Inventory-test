using System;
using System.Collections.Generic;

namespace ProjectInventory
{
	
	public class GameManager
	{

		private List<Entity> entities = new List<Entity>(); //List of all entities (List<Entity)
		private List<Player> players = new List<Player>(); //List of all players (List<Player>)

		public List<Entity> getEntitiesList(){ //gets all the entities in the list

			return this.entities;

		}

		public void addEntity(Entity e){ //add another entity to the list

			this.entities.Add (e);

		}

		public Entity getEntityFromEntities(Entity e, EntityType eType){ //gets an entity from the list (by type)

			return this.entities.Find (i => e.getEntityType() == eType);

		}

		public Entity getEntityFromEntities(Entity e, int instance){ //gets an entity from the list (by instance)

			return this.entities.Find (i => e.getInstance() == instance);

		}

		/*public Entity getEntityFromEntities(Entity e){ //works? (no)

			foreach (Entity en in entities) {

				if(en.Equals(e)){

					return en;

				}

			}

			return null;

			//return this.entities.Find(e);

		}*/

		public void removeEntity(Entity e){ //removes an entity from the list.

			this.entities.Remove (e);

		}

		/*public int getInstanceOfEntityFromEntities(Entity e){

			return this.entities.FindIndex (e);

		}*/

		/*public int getInstanceOfEntityFromEntities(Entity e){

			Entity[] entityArray = this.entities.ToArray ();

			foreach (Entity en in entityArray) {

				if(en.Equals(e)){

					return entityArray.....

				}

			}

		}*/

		public int getInstanceOfEntityFromEntities(Entity e, EntityType en){ //gets the instance of an entity by type

			return this.entities.FindIndex (i => e.getEntityType () == en);

		}

		// PLAYERS BELOW!!! //

		public List<Player> getPlayerList(){ //gets the player list

			return this.players;

		}

		public void addPlayer(Player p){ //adds a player to the list

			this.players.Add (p);

		}

		public Player getPlayerFromPlayers(Player p, String name){ //gets a player from the list (by name)

			return this.players.Find (i => p.getName() == name);

		}

		public Player getPlayerFromPlayer(Player p, int instance){ //gets a player from the list (by instance)

			return this.players.Find (i => p.getInstance() == instance);

		}

		public void removeEntity(Player p){ //removes a player from the list

			this.players.Remove (p);

		}

	}

}

