using System;
using System.ComponentModel.Design;
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
            Inventory[] Items = new Inventory[6];
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
    __          __            \/  \/ \___|_|\___\___/|_| |_| |_|\___|  \__\___/                _                  
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
            Console.WriteLine("As your consciousness returns and your eyes reluctantly open you become aware of the lack of ground beneath your feet.\n" +
                "With a confused wave of your arms you manevuer yourself upright, or at least what you think is upright, as you try to \n" +
                "take in your slow moving surroundings. You are slowly falling down.");
            Thread.Sleep(600);
            Console.WriteLine("And down.");
            Thread.Sleep(600);
            Console.WriteLine("And down.");
            Thread.Sleep(600);
            Console.WriteLine("The bottom of this chasm seems nowhere in sight nor are you in a hurry so you may aswell enjoy the perculiar sights \n" +
                "covering the cavern walls. There's clocks, chairs, mirrors and upside down stairs.\n" +
                "You haven't as much time as you thought to grow accustomed with your new falling state of being because suddenly you \n" +
                "feel your feet touch the floor.");
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
            response = response.ToLower(); // convert input to lowercase for error control


            //switch to interpert user input
            switch (response)
            {
                case "get key":
                case "key":
                case "pickup key":
                    Items[1].Name = "key";
                    Items[1].Desc = "An old fashioned key. I wonder what it unlocks?";
                    Console.WriteLine("You picked up the key!");
                    Console.WriteLine("");
                    FirstRoom(Items); // insert key item into items array then call the beginning of the room back
                    break;
                case "north":
                case "go north":
                case "walk north":
                case "door":
                    // if statement to check if user has key in inventory
                    if (Items[1].Name == "key")
                    {
                        Console.WriteLine("The door unlocked!");
                        Console.WriteLine("");
                        SecondRoom(Items);
                    }

                    else
                    {
                        Console.WriteLine("The door is locked. Maybe there is a key");
                        Console.WriteLine("");
                        FirstRoom(Items);
                    }
                    break;
                    // control for if the user goes the wrong direction
                case "east":
                case "go east":
                case "walk east":
                    Console.WriteLine("There is nowhere to go in that direction");
                    Console.WriteLine("");
                    FirstRoom(Items);
                    break;
                case "west":
                case "go west":
                case "walk west":
                    Console.WriteLine("There is nowhere to go in that direction");
                    Console.WriteLine("");
                    FirstRoom(Items);
                    break;
                case "south":
                case "go south":
                case "walk south":
                    Console.WriteLine("There is nowhere to go in that direction");
                    Console.WriteLine("");
                    FirstRoom(Items);
                    break;
                    // option for the user to check their inventory by calling inventory display method
                case "i":
                case "inventory":
                case "items":
                    InventoryDisplay(Items);
                    FirstRoom(Items);
                    break;
                    // option for user to get help if confused
                case "t":
                case "tips":
                case "help":
                    tips();
                    FirstRoom(Items);
                    break;
                    // in case the user inputs something the program cannot understand
                default:
                    AliceDonotUnderstand();
                    FirstRoom(Items);
                    break;

            }

        }

        public static void SecondRoom(Inventory[] Items)
        {
            //This is the method for the second room of the game
            Console.WriteLine("You are in a new room."); // Pan: the description of new room needed in here!
            Console.WriteLine("You see a bottle of water with notes which says 'Drink me', and a box of cupcakes with notes which says 'Eat me'.");
            Console.WriteLine("What next? Use north south east and west to navigate!");
            string response = Console.ReadLine();
            response = response.ToLower(); // convert input to lowercase for error control


            // switch to interpert user input
            switch (response)
            {
                case "get water":
                case "water":
                case "pickup water":
                case "get bottle":
                case "bottle":
                case "pickup bottle":
                case "get the bottle of water":
                    Items[2].Name = "Drink me bottle";
                    Items[2].Desc = "It seems dosen't like normal water.";
                    Console.WriteLine("You picked up a Drink me bottle!");
                    Console.WriteLine("");
                    SecondRoom(Items); // insert key item into items array then call the beginning of the room back
                    break;

                case "get box":
                case "box":
                case "pickup box":
                case "get cupcake":
                case "cupcake":
                case "pickup cupcake":
                case "get the box of cupcakes":
                    Items[3].Name = "Eat me cupcake";
                    Items[3].Desc = "It seems dosen't like normal cupcake.";
                    Console.WriteLine("You picked up a Eat me cupcake!");
                    Console.WriteLine("");
                    SecondRoom(Items); // insert key item into items array then call the beginning of the room back
                    break;

                case "north":
                case "go north":
                case "walk north":
                case "tiny door":
                    // if statement to check if user used the Drink me bottle
                    Console.WriteLine("There is a small door.");
                    if (Items[1].Name == "key") // need to be fix
                    {
                        Console.WriteLine("You are smaller enough. Now you can easily pass this door.");
                        Console.WriteLine("");
                        ThirdRoom(Items);
                    }
                    else
                    {
                        Console.WriteLine("The door is too small for you. You can only put your finger in.");
                        Console.WriteLine("");
                        SecondRoom(Items);
                    }
                    break;

                // hidden room
                case "east":
                case "go east":
                case "walk east":
                    Console.WriteLine("There is nowhere to go in that direction");
                    Console.WriteLine("");
                    SecondRoom(Items);
                    break;

                // control for if the user goes the wrong direction
                case "west":
                case "go west":
                case "walk west":
                    Console.WriteLine("There is nowhere to go in that direction");
                    Console.WriteLine("");
                    SecondRoom(Items);
                    break;
                case "south":
                case "go south":
                case "walk south":
                    Console.WriteLine("You ");
                    Console.WriteLine("");
                    SecondRoom(Items);
                    break;

                // option for the user to check their inventory by calling inventory display method
                case "i":
                case "inventory":
                case "items":
                    InventoryDisplay(Items);
  // Pan: I think we can move this pause command into the method.
                    SecondRoom(Items);
                    break;

                // option for the user to get some help by calling tips display method
                case "t":
                case "tips":
                case "help":
                    tips();
                    SecondRoom(Items);
                    break;

                default:
                    AliceDonotUnderstand();
                    SecondRoom(Items);
                    break;
            }
        }

        public static void ThirdRoom(Inventory[] Items)
        {
            
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

        public static void tips()
        {
            // when user needs help with what they want to enter, use this method
            Console.WriteLine("Enter north(n), south(s), west(w), east(e) to let Alice moving into different place.");
            Console.WriteLine("To get some items, type 'get' + the name of the item you want to get.");
            Console.ReadLine();
        }

        public static void AliceDonotUnderstand()
        {
            //when user typing anything which is not in switch cases, use this method
            Random rand = new Random();
            int temp = rand.Next(1, 5);
            switch(temp)
            {
                case 1:
                    Console.WriteLine("Alice is just a child. She doesn't understand what you said.");
                    break;
                case 2:
                    Console.WriteLine("Alice seems confused.");
                    break;
                case 3:
                    Console.WriteLine("Alice doesn't understand what you said. Please try again.");
                    break;
                case 4:
                    Console.WriteLine("She doesn't know what she wants to do.");
                    break;
                case 5:
                    Console.WriteLine("'I cannot understand what it is.' Alice said.");
                    break;
            }
            Console.ReadLine();
        }

        public static void InventoryDisplay(Inventory[] Items)
        {
            //inventory display method. Call this for the user to view the inventory contents
            Console.Write("Items".PadRight(20));
            Console.WriteLine("Description".PadRight(20));
            Console.Write($"- {Items[1].Name} -".PadRight(20));
            Console.WriteLine($"- {Items[1].Desc} -".PadRight(20));
            Console.Write($"- {Items[2].Name} -".PadRight(20));
            Console.WriteLine($"- {Items[2].Desc} -".PadRight(20));
            Console.Write($"- {Items[3].Name} -".PadRight(20));
            Console.WriteLine($"- {Items[3].Desc} -".PadRight(20));
            Console.Write($"- {Items[4].Name} -".PadRight(20));
            Console.WriteLine($"- {Items[4].Desc} -".PadRight(20));
            Console.Write($"- {Items[5].Name} -".PadRight(20));
            Console.WriteLine($"- {Items[5].Desc} -".PadRight(20));
            Console.ReadLine();
        }
    }
}
