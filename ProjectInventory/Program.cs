using System;
using System.Collections.Generic;

namespace ProjectInventory
{

	//TO DO, Fix giving inventories to players (done).
	//DO NOT SET DAMAGE TO LOWER THAN 1.0*!
	
	class Program
	{

		private static DifficultySettings ds = new DifficultySettings(DifficultyLevels.NULL);

		private static GameManager gm = new GameManager(); //creates the GameManager and is needed everywhere, can create a new one but it will create problems with communication between objects examples; (Player + Player, Entity + Entity, Player + Entity, exc...).

		public static GameManager getGamemanager(){ //gets the GameManager that is created here.

			return gm;

		}

		public static void Main (string[] args)
		{

			Console.WriteLine ("Loading assets... " + DateTime.Now.ToString("hh:mm:ss") + "\n"); //starts loading the assets and time of starting the game (for debugging purposes)

			List<Item> items = new List<Item> (); //item list for starting out (player) (List<Item>)
			List<Entity> entities = new List<Entity> (); //entity list (List<Entity>)
			List<Player> players = new List<Player> (); //player list (List<Player>)

			{ //item creation without interrupting anything else.

				Item i = new Item (type.FOOD, 2);
				Item j = new Item (type.TOOL, 2);

				items.Add (i);
				items.Add (j); 

			}

			int a = 0;

			//Console.WriteLine ("Player count here: "); //asks for a username.

			while (ds.getDifficulty ().Equals (DifficultyLevels.NULL)) {

				Console.WriteLine ("Difficulty Level: (easy, medium, hard)"); //asks for a username.

				String s = Console.ReadLine ();

				if (s.Equals ("easy")) {

					ds.setDifficulty (DifficultyLevels.EASY);

				} else if (s.Equals ("medium")) {

					ds.setDifficulty (DifficultyLevels.MEDIUM);

				} else if (s.Equals ("hard")) {

					ds.setDifficulty (DifficultyLevels.HARD);

				} 

				Console.WriteLine ("\n"+"Current difficulty: " + ds.getDifficulty() +"\n");

			}

			try{

				while (a == 0){

					Console.WriteLine ("Player count here: "); //asks for a username.

					a = int.Parse(Console.ReadLine()); //gets the int

					if (a > 12){

						a = 12; 

					}

				}

				Console.WriteLine ("Player count is: " + a + "\n");

			} catch (System.FormatException){

				a = 1;

				Console.WriteLine ("Player count is: " + a + "\n");

			}

			for(int i = 0; i < a; i++){

				Console.WriteLine ("Player " + i + ", Username here: "); //asks for a username.

				Player Player_ = CreateNewPlayer.createPlayer (items, Console.ReadLine()); //creates a new player

				players.Add (Player_); //adds the player to the List<Player>

			}

			//Player MainPlayer = CreateNewPlayer.createPlayer (items, Console.ReadLine()); //creates the player with the the name given on input.

			for (int i = 0; i < 5; i++) //Comment out if not working... (working)
			{

				Entity _entity1 = CreateNewEntity.createEntity (EntityType.BANDIT, 5.00/*, 0.10, items*/); //creates the entity //do not go above 5.00 for health!!!
				
				foreach (Player p in players) {

					_entity1.addTarget (p); //adds the target to the entity (not-essential)

					p.addTarget (_entity1); //adds the target to the player (not-essential)

				}

				/*foreach (Item it in items) { //gets all the items in the starting inventory.

					_entity1.getInventoryManager ().InventoryAdd (it); //gets the inventory manager and adds the item to it.

				}*/

				_entity1.setDamage(0.25 * ds.getDifficultyLevel());

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

			Console.WriteLine ("\n" + "Loaded assets! " + DateTime.Now.ToString ("hh:mm:ss")); //announces that the game has finished loading.

			Console.WriteLine ("\n" + "You have engaged in battle! \n"); //announces the start of the game.

			foreach (Player p in players) {

				p.getInventoryManager ().displayInventory (); //Comment out if working.

				p.setHealth (10.0); //sets the main players health to be greater than all the enemies total health for debugging purposes.

				//p.setDamage (0.10);

			}

			fight (players, entities); //starts the fight. (80% tested, 90% working as from (10:31:40 21/11/2017) || 85% tested, 75% working as from (09:28:20 22/11/2017)

		}

		public static void fight(List<Player> players, List<Entity> entities){ //Change the Player MainPlayer to a List<Player> for multiplayer reasons

			while (players.ToArray().Length > 0 && entities.ToArray().Length > 0) { //makes sure the main player is not dead.

				//Console.ReadLine (); //debugging

				try{

					foreach (Entity e in entities) { //gets each entity.

						foreach(Player p in players){ //gets each player.

							/*MainPlayer.setHealth (MainPlayer.getHealth() -1.00);
							e.setHealth (e.getHealth () -1.00);*/

							String s = Console.ReadLine();

							if(s.Equals("!heal")){ //THIS IS BEING TESTED. THIS CAN AND WILL BREAK. //FIXXXX

								bool j = false;

								for (int i = 1; i < 11; i++){

									Item it = new Item(type.FOOD, i);

									if(!j){
								//if(p.getInventoryManager().getInventory().Contains(i)){
								
										if(p.removePartItemBool(it, 1)){

											j = true;

										}

									}

									if(j){

										p.setHealth(p.getHealth() + 0.20);
										p.getInventoryManager().displayInventory();

									}

								/*} else {

									Console.WriteLine("Not enough food!"+"\n");

								}*/

								}

							} else if(s.Equals("!attack")){

								Item i = new Item(type.TOOL, 1);

								p.damageEntity (e);
								p.getInventoryManager().InventoryRemove(i);
								p.getInventoryManager().displayInventory();

							} else {

								//p.damageEntity (e);

							} //DOWN TO HERE NEEDS FIXING

							e.damagePlayer (p);

							Console.WriteLine(e.speech ("test speech")); //test speech (works)
							Console.WriteLine(e.speech (e.getHealth ().ToString()) + "\n"); //announces health of the enemy

							Console.WriteLine(p.speech ("test speech")); //test speech, will replace later
							Console.WriteLine(p.speech (p.getHealth ().ToString())); //anounces health of the player

							//MainPlayer.kill (MainPlayer);

							if (e.isDead ()) {

								e.giveLoot(p); //gives the loot to the player, broken, gives everyone loot, only killer should get loot.

								//p.getInventoryManager ().displayInventory (); // Comment out if working.

								p.removeTarget (e); //removes the target from the player.
								entities.Remove (e); //removes the entity from existing, saving space (hopefully).

								Console.WriteLine ("\n"+e.speech("has died!")); //announces the entities death.

								//maybe works. comment out if not neccessary. 
								//fight(MainPlayer, entities); || unneccessary code. //continues the fight because otherwise the fight will end because of a "System.InvalidOperationException" error.
									
								break; //stops this loop to stop CPU bottlenecking in larger fights

							}

							if (p.isDead ()) {

								p.giveLoot(e); //gives the entity the loot, working? (testing)

								//e.getInventoryManager().displayInventory(); //testing the inventory.

								//p.getInventoryManager().displayInventory(); //Comment out if working.

								foreach (Entity en in entities){
									
									en.removeTarget (p); //removes the player from the entity's targeting.

								}

								Console.WriteLine ("\n"+p.speech("has died!")); //announces the players death

								players.Remove(p);

								break; //stops the game, should be a break (multiplayer reasons). || fixed

							}

						}

					}

				} catch (System.InvalidOperationException){

					if (entities.ToArray ().Length > 0) { //checks if the List<Entity> is bigger than 0, otherwise stop.

						fight (players, entities); //continues the fight. works || dont know if it works, testing in progress, 17:32:45 21 NOV 2017

					} else {

						//Console.WriteLine (p.speech("has won!")); //announces the players victory

					}

				}

			}

		}

	}

}
