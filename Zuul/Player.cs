﻿using System;

namespace Zuul
{
    public class Player
    {
        public Room CurrentRoom { get; set; }

        private int health;
        private bool isAlive;
        public int Health { get { return health; } }

        private Inventory inventory;

        public Player()
        {
            CurrentRoom = null;

            health = 100;

            // 25kg is pretty heavy to carry around all day.
            inventory = new Inventory(25);
        }

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
        public void Status()
        {
            Console.WriteLine("You have " + health + " Health left.");
            Console.WriteLine("You have these items in your inventory: "); ;
        }

        public bool TakeFromChest(string itemName)
        {
            Item item = CurrentRoom.Chest.Get(itemName);
            if (item == null)
            {
                Console.WriteLine(itemName + "does not exist in the current room.");
                return false;
            }
            if (inventory.Put(itemName, item))
            {
                Console.WriteLine("You picked up a" + itemName + "and added it to your inventory.");
                return true;
            }
            Console.WriteLine("You don't have enough space in your inventory left to carry, the item: " + itemName);
            CurrentRoom.Chest.Put(itemName, item);
            return false;
        }

        public bool DropFromChest(string itemName)
        {
            Item item = inventory.Get(itemName);
            if (item == null)
            {
                return false;
            }
            Console.WriteLine("You dropped a" + itemName + "on the ground.");
            CurrentRoom.Chest.Put(itemName, item);
            return true;
        }
    }
}
