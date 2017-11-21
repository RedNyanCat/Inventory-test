using System;
using System.Collections.Generic;

namespace ProjectInventory
{

	//TO DO, Fix giving inventories to players.
	
	class Program
	{

		private static GameManager gm = new GameManager(); //creates the GameManager and is needed everywhere, can create a new one but it will create problems with communication between objects examples; (Player + Player, Entity + Entity, Player + Entity, exc...).

		public static GameManager getGamemanager(){ //gets the GameManager that is created here.

			return gm;

		}

		public static void Main (string[] args)
		{

			Console.WriteLine ("Loading assets... " + DateTime.Now.ToString("hh:mm:ss") + "\n"); //starts loading the assets and time of starting the game (for debugging purposes)

			List<Item> items = new List<Item> (); //item list for starting out (player) (List<Item>)

			List<Entity> entities = new List<Entity> (); //entity list (List<Entity>)

			{ //item creation without interrupting anything else.

				Item i = new Item (type.FOOD, 2);
				Item j = new Item (type.TOOL, 2);

				items.Add (i);
				items.Add (j); 

			}

			Console.WriteLine ("Username here: "); //asks for a username.

			Player MainPlayer = CreateNewPlayer.createPlayer (items, Console.ReadLine()); //creates the player with the the name given on input.

			for (int i = 0; i < 2; i++) //Comment out if not working... (working)
			{

				Entity _entity1 = CreateNewEntity.createEntity (EntityType.BANDIT); //creates the entity

				_entity1.addTarget (MainPlayer); //adds the target to the entity (not-essential)

				MainPlayer.addTarget (_entity1); //adds the target to the player (not-essential)

				foreach(Item it in items){ //gets all the items in the starting inventory.

					_entity1.getInventoryManager().InventoryAdd(it); //gets the inventory manager and adds the item to it.

				}

				entities.Add (_entity1); //adds the entity to the List<Entity> without error.

				// SECOND ENTITY FOR TESTING

				/*Entity _entity2 = CreateNewEntity.createEntity (EntityType.BANDIT);

				_entity2.addTarget (MainPlayer);

				MainPlayer.addTarget (_entity2);

				entities.Add (_entity2);*/

			}

			for (int i = 0; i < 4; i++) { //this does nothing if the console isn't in full screen.

				Console.Clear (); //clears the console

			}

			MainPlayer.getInventoryManager ().displayInventory (); //Comment out if working.

			Console.WriteLine ("\n" + "Loaded assets! " + DateTime.Now.ToString("hh:mm:ss")); //announces that the game has finished loading.

			Console.WriteLine ("\n"+"You have engaged in battle! \n"); //announces the start of the game.

			MainPlayer.setHealth (11.0); //sets the main players health to be greater than all the enemies total health for debugging purposes.

			fight (MainPlayer, entities); //starts the fight. (80% tested, 90% working as from (10:31:40 21/11/2017)

		}

		public static void fight(Player MainPlayer, List<Entity> entities){ //Change the Player MainPlayer to a List<Player> for multiplayer reasons

			while (!MainPlayer.isDead () && entities.ToArray().Length > 0) { //makes sure the main player is not dead.

				//Console.ReadLine (); //debugging

				try{

					foreach (Entity e in entities) { //gets each entity.

						Console.ReadLine ();
						Console.WriteLine(e.speech ("test speech")); //test speech (works)

						/*MainPlayer.setHealth (MainPlayer.getHealth() -1.00);
						e.setHealth (e.getHealth () -1.00);*/

						MainPlayer.damageEntity (e);
						e.damagePlayer (MainPlayer);

						Console.WriteLine(e.speech (e.getHealth ().ToString()) + "\n"); //announces health of the enemy

						Console.WriteLine(MainPlayer.speech ("test speech")); //test speech, will replace later
						Console.WriteLine(MainPlayer.speech (MainPlayer.getHealth ().ToString())); //anounces health of the player

						//MainPlayer.kill (MainPlayer);

						if (e.isDead ()) {

							e.giveLoot(MainPlayer); //gives the loot to the player, broken.

							MainPlayer.getInventoryManager ().displayInventory (); // Comment out if working.

							MainPlayer.removeTarget (e); //removes the target from the player.
							entities.Remove (e); //removes the entity from existing, saving space (hopefully).

							Console.WriteLine (e.speech("has died!")); //announces the entities death.

							//maybe works. comment out if not neccessary. 
							//fight(MainPlayer, entities); || unneccessary code. //continues the fight because otherwise the fight will end because of a "System.InvalidOperationException" error.

							break; //stops this loop to stop CPU bottlenecking in larger fights

						}

						if (MainPlayer.isDead ()) {

							MainPlayer.giveLoot(e); //gives the entity the loot, working? (testing)

							e.getInventoryManager().displayInventory(); //testing the inventory.

							MainPlayer.getInventoryManager().displayInventory(); //Comment out if working.

							foreach (Entity en in entities){
								
								en.removeTarget (MainPlayer); //removes the player from the entity's targeting.

							}

							Console.WriteLine (MainPlayer.speech("has died!")); //announces the players death

							return; //stops the game, should be a break (multiplayer reasons).

						}

					}

				} catch (System.InvalidOperationException){

					if (entities.ToArray ().Length > 0) { //checks if the List<Entity> is bigger than 0, otherwise stop.

						fight (MainPlayer, entities); //continues the fight. works || dont know if it works, testing in progress, 17:32:45 21 NOV 2017

					} else {

						Console.WriteLine (MainPlayer.speech("has won!")); //announces the players victory

					}

				}

			}

		}

	}

}
