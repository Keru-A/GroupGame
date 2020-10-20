using System;
using System.Data;
using System.Globalization;
using System.Threading;

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

        public static void FourthRoom()
        {
            //This is the method for the fourth room of the game
            Console.WriteLine("You reach the top of the stairs and enter another room with 4 doors");
            Console.ReadLine();
            Console.WriteLine("There are 3 doors grouped together along the east wall and the other door resides on the south wall by itself");
            Console.ReadLine();
            Console.WriteLine("Will you go east or south?");
            string rm4Answer = Console.ReadLine();

         
            {
                if (rm4Answer == "east")
                {
                    Console.WriteLine("You approach the three mysterious looking doors...");
                    Console.ReadLine();
                }
                else if (rm4Answer == "south")
                {
                    Console.WriteLine("You approach the single door");
                    Console.ReadLine();
                }
              
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
