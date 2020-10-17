using System;

namespace GroupGame
{
    class Program
    {
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
        }

        public static void FirstRoom()
        {
            //This is the method for the first location of the game

            //Beginning the game with simple input
            Console.WriteLine("You are in a room!");
            Console.WriteLine("What now? Use north south east and west to navigate!");
            string response = Console.ReadLine();

            //swicth to interpret the user input
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
        }

        public static void GameOver()
        {
            //This is the game over screen method
        }
    }
}
