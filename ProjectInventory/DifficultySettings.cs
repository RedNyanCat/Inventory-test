using System;

namespace ProjectInventory
{
	
	public class DifficultySettings
	{

		private DifficultyLevels dl; //the difficulty itself
		private int dli; //difficulty integer

		public DifficultySettings (DifficultyLevels dl) //sets the difficulty
		{

			this.dl = dl;

			if(this.dl.Equals(DifficultyLevels.EASY)){ //easy difficulty

				dli = 1;

			}

			if(this.dl.Equals(DifficultyLevels.MEDIUM)){ //medium difficulty

				dli = 2;

			}

			if(this.dl.Equals(DifficultyLevels.HARD)){ //hardest difficulty

				dli = 3;

			}

		}

		public void setDifficulty (DifficultyLevels dl) //sets the difficulty
		{

			this.dl = dl;

			if(this.dl.Equals(DifficultyLevels.EASY)){ //easy difficulty

				dli = 1;

			}

			if(this.dl.Equals(DifficultyLevels.MEDIUM)){ //medium difficulty

				dli = 2;

			}

			if(this.dl.Equals(DifficultyLevels.HARD)){ //hardest difficulty

				dli = 3;

			}

		}

		public DifficultyLevels getDifficulty(){ //gets the current set difficulty

			return this.dl;

		}

		public int getDifficultyLevel(){ //gets the current set difficulty as an integer

			return this.dli;

		}

	}

}

