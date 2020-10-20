using System;
using System.Data;
using System.Threading;

namespace GroupGame
{
    class Program
    {
        static void Main()
        {
            //call the start screen
            Start();
            //call the first room which begins the game
            FirstRoom();
            Console.ReadLine();
            
        }

        public static void Start()
        {
            //This is the method for the start screen
            Console.WriteLine("Welcome to the game!");
            Thread.Sleep(500);
            Console.Clear();
        }

        public static void FirstRoom()
        {
            //This is the method for the first location of the game

            //Beginning the game with simple input
            Console.WriteLine("You are in a room! You can see a key inside the room.");
            Console.WriteLine("What now? Use north south east and west to navigate!");
            string response = Console.ReadLine();
            int key = 0;     //(Change the keys into a item if inventory is finished)

            //If statements to interpret the user input
            //get item
            if (response == "get key")
            {
                Console.WriteLine("You got a key. The shape of this sliver key has a very old design.");
                key += 1;     //(Change the keys into a item if inventory is finished)
            }
            //correct way to enter next room
            else if (response == "east")
            {
                if (key == 1)     //(Change the keys into a item if inventory is finished)
                {
                    Console.WriteLine("The locked door is open!");
                    key -= 1;     //(Change the keys into a item if inventory is finished)
                    SecondRoom();
                }
                else
                {
                    Console.WriteLine("You see a door in front of you. But it is locked.");
                    Console.WriteLine("Try to find something to unlock it.");
                }
            }
            //other ways
            else if (response == "north")
            {

            }
            else if (response == "south")
            {
                Console.WriteLine("There is nothing except a wall.");
            }
            else if (response == "west")
            {

            }
            else
            {
                AliceDonotUnderstand();
            }
        }

        public static void SecondRoom()
        {
            //This is the method for the second location of the game
            Console.WriteLine("You are in another room. Congratulations!");
        }

        public static void GameOver()
        {
            //This is the game over screen method
            Console.WriteLine("You fell down a pit and died :(");
            Console.WriteLine("Game Over");

            //ask to play again
            Console.WriteLine("Play again? Y/N");
            string response = Console.ReadLine();

            //if statement to check answer
            if (response == "Y")
            {
                Console.Clear();
                Start();
                FirstRoom();
            }

            else
            {
                Console.WriteLine("Thanks for playing!");
                Console.ReadLine();
            }
        }
        public static void AliceDonotUnderstand()
        {
            //This is 
            Random rand = new Random();
            int temp = rand.Next(1, 5);
        }
    }
}
