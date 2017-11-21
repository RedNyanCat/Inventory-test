using System;

namespace ProjectInventory
{
	
	public class Item
	{

		private type type; //type of object
		private int amount; //amount of that object

		public int maxItemStack = 10; //max items per stack (working)
		public int minItemStack = 1; //min items per stack (working)

		public Item (type type, int amount) //creating the item
		{

			this.type = type;

			if (amount >= this.maxItemStack) {

				this.amount = maxItemStack;

				return;

			}
			this.amount = amount;

		}

		public void addAmount(int i){ //adding an int to the item stack

			int newAmount = this.amount += i;

			if (!((newAmount) > this.maxItemStack)) {

				this.amount += i;

			}

		}

		public void decreaseAmount(int i){ //decreasing an int to the item stack

			int newAmount = this.amount -= i;

			if (!((newAmount) < (this.minItemStack - 1))) {

				this.amount -= i;

			}

		}

		public type getType(){ //getting the item stack type

			return this.type;

		}

		public int getAmount(){ //getting the amount of the item stack

			return this.amount;

		}

	}

}

