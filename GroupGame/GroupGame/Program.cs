using System;
using System.Data;
using System.Dynamic;
using System.Globalization;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;

namespace GroupGame
{
    class Program
    {
        //Inventory struct to store information with each item
        public struct Inventory
        {
            public string Name;
            public string Desc;
        }
        static void Main()
        {
            //Inventory array called Items. Remember to reference in method to be able to use the inventory.
            Inventory[] Items = new Inventory[10];
            // items designated slots - key 1, drink me bottle 2, eat me cake 3, 
            //call the start screen
            Start();
            //call the first room which begins the game
            FirstRoom(Items);
            Console.ReadLine();
            
        }

        public static void Start()
        {
            //This is the method for the start screen
            Console.WriteLine("");
            Console.WriteLine(@"
                          __          __  _                            _                                       
                          \ \        / / | |                          | |                                      
                           \ \  /\  / /__| | ___ ___  _ __ ___   ___  | |_ ___                                 
                            \ \/  \/ / _ \ |/ __/ _ \| '_ ` _ \ / _ \ | __/ _ \                                
                             \  /\  /  __/ | (_| (_) | | | | | |  __/ | || (_) |                               
 __          __             _ \/  \/ \___|_|\___\___/|_| |_| |_|\___|  \__\___/             _                  
 \ \        / /            | |         | |               | |     /\      | |               | |                 
  \ \  /\  / /__  _ __   __| | ___ _ __| | __ _ _ __   __| |    /  \   __| |_   _____ _ __ | |_ _   _ _ __ ___ 
   \ \/  \/ / _ \| '_ \ / _` |/ _ \ '__| |/ _` | '_ \ / _` |   / /\ \ / _` \ \ / / _ \ '_ \| __| | | | '__/ _ \
    \  /\  / (_) | | | | (_| |  __/ |  | | (_| | | | | (_| |  / ____ \ (_| |\ V /  __/ | | | |_| |_| | | |  __/
     \/  \/ \___/|_| |_|\__,_|\___|_|  |_|\__,_|_| |_|\__,_| /_/    \_\__,_| \_/ \___|_| |_|\__|\__,_|_|  \___|
                                                                                                               
                                                                                                               
            ");     
            Console.WriteLine("");
            Console.WriteLine("A game by Alice Dowle, Saniya Vahora, Harry Wallace and Pan Zhi");
            Console.ReadLine();
            Console.Clear();

            //intro sequence to flow into the first room
            Console.Write("You're falling");
            Thread.Sleep(500);
            Console.Write(".");
            Thread.Sleep(500);
            Console.Write(".");
            Thread.Sleep(500);
            Console.WriteLine(".");
            Thread.Sleep(500);
            Console.WriteLine("");
            Console.WriteLine("Down a rabbit hole?");
            Thread.Sleep(800);
            Console.WriteLine("As your consciousness returns and your eyes reluctantly open you become aware of the lack of ground beneath your feet.");
            Console.WriteLine("With a confused wave of your arms you manevuer yourself upright, or at least what you think is upright, as you try to take in your slow moving surroundings. You are slowly falling down.");
            Console.WriteLine("and down.");
            Console.WriteLine("and down.");
            Console.WriteLine("The bottom of this chasm seems nowhere in sight nor are you in a hurry so you may aswell enjoy the perculiar sights covering the cavern walls. There's clocks, chairs, mirrors and upside down stairs");
            Console.WriteLine("You haven't as much time as you thought to grow accustomed with your new falling state of being because suddenly you feel your feet touch the floor.");
            Console.ReadLine();
            Console.Clear();

        }

        public static void FirstRoom(Inventory[] Items)
        {
            //This is the method for the first location of the game

            //Beginning the game with simple input
            Console.WriteLine("You are in a room! There is a locked door in front of you. You can see a key inside the room.");
            Console.WriteLine("What now? Use north south east and west to navigate!");
            string response = Console.ReadLine();
            response = response.ToLower();


            //switch to interpert user input
            switch (response)
            {
                case "get key":
                case "key":
                case "pickup key":
                    Items[1].Name = "key";
                    Items[1].Desc = "An old fashioned key. I wonder what it unlocks?";
                    Console.WriteLine("You picked up the key!");
                    FirstRoom(Items);
                    break;
                case "north":
                case "go north":
                case "walk north":
                case "door":
                    if (Items[1].Name == "key")
                    {
                        Console.WriteLine("The door unlocked!");
                        SecondRoom(Items);
                    }

                    else
                    {
                        Console.WriteLine("The door is locked. Maybe there is a key");
                        FirstRoom(Items);
                    }
                    break;
                case "east":
                case "go east":
                case "walk east":
                    Console.WriteLine("There is nowhere to go in that direction");
                    FirstRoom(Items);
                    break;
                case "west":
                case "go west":
                case "walk west":
                    Console.WriteLine("There is nowhere to go in that direction");
                    FirstRoom(Items);
                    break;
                case "south":
                case "go south":
                case "walk south":
                    Console.WriteLine("There is nowhere to go in that direction");
                    FirstRoom(Items);
                    break;
            }

        }

        public static void SecondRoom(Inventory[] Items)
        {
            //This is the method for the second location of the game
            Console.WriteLine("there is a potion");
            string response = Console.ReadLine();
            Items[0].Name = "key"; //this is to test if the program can check an array entry is filled and fill the next one

            int count = 0;
            if (response == "get potion")
            {
                if (Items[count].Name == null) //check if array is empty in order to pick up potion
                {
                    Items[count].Name = "potion";
                    Items[count].Desc = "health potion";
                }

                else //if the array is not empty it will increase count and fill
                {
                    count = count + 1;
                    Items[count].Name = "potion";
                    Items[count].Desc = "health potion";
                }

                Console.WriteLine(Items[0].Name);
                Console.WriteLine(Items[1].Name);
                Console.ReadLine(); //testing the arrays are filled
            }
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

        public static void GameOver(Inventory[] Items)
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
                FirstRoom(Items);
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
