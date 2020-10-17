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
        }
    }
}
