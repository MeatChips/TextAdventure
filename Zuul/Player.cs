using System;

namespace Zuul
{ 
	public class Player
	{
		public Room CurrentRoom { get; set; }

        private int health;
        private bool isAlive;
        public int Health { get { return health; } }

        public int Damage(int amount)
        {
            health = health - amount;
            return health;
        }

        public int Heal(int amount)
        {
            health = health + amount;
            return health;
        }

        public bool PlayerIsAlive()
        {
            if (health == 0)
            {
                isAlive = false;
                Console.WriteLine("You died, better luck next time!");
            }
            else 
            {
                isAlive = true;
            }
            return isAlive;
        }

        public Player()
        {
            CurrentRoom = null;

            health = 100;
        }
		
	}
}
