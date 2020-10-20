using System;
using System.Data;
using System.Dynamic;
using System.Threading;

namespace GroupGame
{
    class Program
    {
        public static string[] Inventory = new string[10];
        static void Main(string[] args)
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
            Console.WriteLine("You are in a room!");
            Console.WriteLine("What now? Use north south east and west to navigate!");
            string response = Console.ReadLine();

            //switch to interpret the user input
            switch (response)
            {
                case "north":
                    SecondRoom();
                    break;
                case "south":
                case "west":
                case "east":
                    GameOver();
                    break;
                default:
                    break;
            }
        }

        public static void SecondRoom()
        {
            //This is the method for the second location of the game
            Console.WriteLine("You are in another room. Congratulations!");

            Console.WriteLine("there is a potion on the ground");
            string response = Console.ReadLine();

            if (response == "get potion")
            {
                Inventory[0] = "potion";
                Console.WriteLine(Inventory[0]);
                Console.ReadLine();
            }
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
    }
}
