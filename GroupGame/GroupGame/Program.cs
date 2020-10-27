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


        //big small boolean status effect, global variables to ensure they can function in every method
        public static bool big;
        public static bool small;
        static void Main()
        {
            bool Big, Small;
            //Inventory array called Items. Remember to reference in method to be able to use the inventory.
            Inventory[] Items = new Inventory[6];
            // items designated slots - key 1, drink me bottle 2, eat me cake 3, 
            //call the start screen
            Start();
            //call the first room which begins the game
            FirstRoomOpen(Items);
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

        public static void FirstRoomOpen(Inventory[] Items)
        {
            // This method outputs the description of the room. Making this seperate keeps the console clear everytime the player performs an action.
            Console.WriteLine("You are in a room! There is a locked door in front of you. You can see a key inside the room.");
            Thread.Sleep(600);
            Console.WriteLine("");
            FirstRoom(Items);
        }

        public static void FirstRoom(Inventory[] Items)
        {
            
            //This is the method for the first location of the game

            //Beginning the game with simple input
            Console.WriteLine("What now? Use north south east and west to navigate! Type help to get tips!");
            Console.WriteLine("");
            string response = Console.ReadLine();
            response = response.ToLower(); // convert input to lowercase for error control
            

            //switch to interpert user input
            switch (response)
            {
                case "get key":
                case "key":
                case "pick up key":
                    Items[1].Name = "key";
                    Items[1].Desc = "An old fashioned key. I wonder what it unlocks?";
                    Console.WriteLine("You picked up the key!");
                    Console.WriteLine("");
                    Thread.Sleep(600);
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
                        Thread.Sleep(600);
                        Console.Clear();
                        SecondRoomOpen(Items);
                    }

                    else
                    {
                        Console.WriteLine("The door is locked. Maybe there is a key");
                        Console.WriteLine("");
                        Thread.Sleep(600);
                        FirstRoom(Items);
                    }
                    break;
                    // control for if the user goes the wrong direction
                case "east":
                case "go east":
                case "walk east":
                    Console.WriteLine("There is nowhere to go in that direction");
                    Console.WriteLine("");
                    Thread.Sleep(600);
                    FirstRoom(Items);
                    break;
                case "west":
                case "go west":
                case "walk west":
                    Console.WriteLine("There is nowhere to go in that direction");
                    Console.WriteLine("");
                    Thread.Sleep(600);
                    FirstRoom(Items);
                    break;
                case "south":
                case "go south":
                case "walk south":
                    Console.WriteLine("There is nowhere to go in that direction");
                    Console.WriteLine("");
                    Thread.Sleep(600);
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
                    Tips(Items);
                    FirstRoom(Items);
                    break;
                // in case the user inputs something the program cannot understand
                case "look":
                        FirstRoomOpen(Items); //lets user get a description of the room again in case they are lost
                    break;
                default:
                    AliceDonotUnderstand();
                    FirstRoom(Items);
                    break;

            }
            

        }

        public static void SecondRoomOpen(Inventory[] Items)
        {
            //opening for second room to keep console clear during game
            Console.WriteLine("You are in a new room."); // Pan: the description of new room needed in here!
            Console.WriteLine("You see a bottle of water with a note which says 'Drink me', and a box of cupcakes with a note which says 'Eat me'.");
            SecondRoom(Items);
        }

        public static void SecondRoom(Inventory[] Items)
        {
            Console.WriteLine("What next? Use north south east and west to navigate!");
            string response = Console.ReadLine();
            response = response.ToLower(); // convert input to lowercase for error control


            // switch to interpert user input
            switch (response)
            {
                case "get water":
                case "drink me":
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
                    Thread.Sleep(600);
                    SecondRoom(Items); // insert key item into items array then call the beginning of the room back
                    break;

                case "get cake":
                case "box":
                case "pickup box":
                case "get cupcake":
                case "cupcakes":
                case "cupcake":
                case "pickup cupcake":
                case "get the box of cupcakes":
                case "cake":
                    Items[3].Name = "Eat me cupcake";
                    Items[3].Desc = "It seems dosen't like normal cupcake.";
                    Console.WriteLine("You picked up a Eat me cupcake!");
                    Console.WriteLine("");
                    Thread.Sleep(600);
                    SecondRoom(Items); // insert key item into items array then call the beginning of the room back
                    break;

                case "use drink me":
                case "drink":
                case "drink water":
                case "drink bottle":
                case "use water":
                case "use bottle":
                    if (Items[2].Name == "Drink me bottle") //player must have item in inventory to use it
                    {
                        Items[2].Name = "";
                        Items[2].Desc = "";
                        Console.WriteLine("You begin to shrink!!");
                        Console.WriteLine("If you want to become big again, maybe you can try Eat me cupcake...?");
                        small = true; //player must use their item to change the status effect. They do not yet lose the item from their inventory.
                        big = false;
                        Console.WriteLine("");
                        Thread.Sleep(600);
                        SecondRoom(Items);
                    }

                    else
                    {
                        AliceDonotUnderstand();
                        SecondRoom(Items);
                    }
                    break;

                case "use cake":
                case "eat cake":
                case "eat me":
                    if (Items[3].Name == "Eat me cupcake")
                    {
                        Items[3].Name = "";
                        Items[3].Desc = "";
                        Console.WriteLine("Wow, you begin to grow and grow!! You are much to tall to fit through that teeny tiny door now!");
                        Console.WriteLine("If you want to become small again, maybe you can try Drink me water...?");
                        Console.WriteLine("");
                        Thread.Sleep(600);
                        SecondRoom(Items);
                    }

                    else
                    {
                        AliceDonotUnderstand();
                        SecondRoom(Items);
                    }
                    break;

                case "north":
                case "go north":
                case "walk north":
                case "tiny door":
                    // if statement to check if user used the Drink me bottle
                    Console.WriteLine("There is a small door.");
                    if (small == true)
                    {
                        Console.WriteLine("You are smaller enough. Now you can easily pass this door.");
                        Console.WriteLine("");
                        Thread.Sleep(600);
                        ThirdRoomOpen(Items);
                    }
                    else
                    {
                        Console.WriteLine("The door is too small for you. You can only put your finger in.");
                        Console.WriteLine("");
                        Thread.Sleep(600);
                        SecondRoom(Items);
                    }
                    break;

                // hidden room
                case "east":
                case "go east":
                case "walk east":
                    Console.WriteLine("There is a door in this direction, and lucky is not locked.");
                    if (small == true)
                    {

                    }
                    Console.WriteLine("");
                    Thread.Sleep(600);
                    FifthRoomOpen(Items);
                    break;

                // control for if the user goes the wrong direction
                case "west":
                case "go west":
                case "walk west":
                    Console.WriteLine("There is nowhere to go in that direction");
                    Console.WriteLine("");
                    Thread.Sleep(600);
                    SecondRoom(Items);
                    break;
                case "south":
                case "go south":
                case "walk south":
                    Console.WriteLine("You ");
                    Console.WriteLine("");
                    Thread.Sleep(600);
                    SecondRoom(Items);
                    break;

                // option for the user to check their inventory by calling inventory display method
                case "i":
                case "inventory":
                case "items":
                    InventoryDisplay(Items);
                    SecondRoom(Items);
                    break;

                // option for the user to get some help by calling tips display method
                case "t":
                case "tips":
                case "help":
                    Tips(Items);
                    SecondRoom(Items);
                    break;
                //let user get description of the room again if they are lost
                case "look":
                    SecondRoomOpen(Items); 
                    break;
                default:
                    AliceDonotUnderstand();
                    SecondRoom(Items);
                    break;
            }

        }

        public static void ThirdRoomOpen(Inventory[] Items)
        {
            //seperate opening from the rest of the method to keep console clear
            Console.WriteLine("You are in third room. There are huge stairs in front of you! They are much too big to climb!");
            Console.WriteLine("");
            ThirdRoom(Items);
        }

        public static void ThirdRoom(Inventory[] Items)
        {
            Console.WriteLine("What next? Use north south east and west to navigate!");
            string response = Console.ReadLine();
            response = response.ToLower();
            switch (response)
            {
                case "use cake":
                case "eat cake":
                case "eat me":
                    if (Items[3].Name == "Eat me cupcake")
                    {
                        Items[3].Name = "";
                        Items[3].Desc = "";
                        Console.WriteLine("Wow, you've begun to grow so tall!"); //using the item changes the status effects
                        Console.WriteLine("");
                        Thread.Sleep(600);
                        big = true;
                        small = false;
                        ThirdRoom(Items);
                    }

                    else
                    {
                        AliceDonotUnderstand();
                        ThirdRoom(Items);
                    }
                    break;

                case "west":
                case "go west":
                case "walk west":
                case "door":

                    // if statement to check if user has key in inventory
                    if (big == true) //player must eat cake to climb giant stairs
                    {
                        Console.WriteLine("You ate the cake you picked up and are big enough to climb the stairs. You can leave the room!");
                        Console.WriteLine("");
                        FourthRoom(Items);
                    }

                    else
                    {
                        Console.WriteLine("You're too small!! How could you get bigger? Did you eat the cupcakes?");
                        Console.WriteLine("");
                        ThirdRoom(Items);
                    }
                    break;

                case "east":
                case "go east":
                case "walk east":
                    Console.WriteLine("There is nowhere to go in that direction");
                    Console.WriteLine("");
                    ThirdRoom(Items);
                    break;
                case "north":
                case "go north":
                case "walk north":
                    Console.WriteLine("There is nowhere to go in that direction");
                    Console.WriteLine("");
                    ThirdRoom(Items);
                    break;
                case "south":
                case "go south":
                case "walk south":
                    Console.WriteLine("");
                    SecondRoomOpen(Items); //call the full second room methods to help user stay orientated
                    break;

                case "i":
                case "inventory":
                case "items":
                    InventoryDisplay(Items);
                    ThirdRoom(Items);
                    break;

               
                case "t":
                case "tips":
                case "help":
                    Tips(Items);
                    ThirdRoom(Items);
                    break;

                case "look":
                    ThirdRoomOpen(Items); //lets user get a description of the room again
                    break;

                default:
                    AliceDonotUnderstand();
                    ThirdRoom(Items);
                    break;

            }
        }

        public static void FourthRoom(Inventory[] Items)
        {
            //This is the method for the fourth room of the game
            Console.WriteLine("You reach the top of the stairs and enter another room with 4 doors");
            Console.ReadLine();
            Console.WriteLine("There are 3 doors grouped together along the east wall and the other door resides on the south wall by itself");
            Console.ReadLine();
            Console.WriteLine("Which way will you go?");
            string response = Console.ReadLine();
            response = response.ToLower();
            switch (response)
            {

                case "north":
                case "go north":
                case "walk north":
                case "door":
                    Console.WriteLine("You walk north and find a door being guarded by Tweedledee and Tweedledum, they have a riddle for you...");
                    Console.WriteLine("You must answer correctly in order to pass through the door.");
                    Console.WriteLine("");
                    break;
                case "west":
                case "go west":
                case "walk west":
                    Console.WriteLine("There is nowhere to go in that direction");
                    Console.WriteLine("");
                    break;
                case "south":
                case "go south":
                case "walk south":
                    Console.WriteLine("You chose south, thus you wen't back the way you came");
                    Console.WriteLine("");
                    break;
                case "east":
                case "go east":
                case "walk east":
                    break;
            }
        }

        public static void FifthRoomOpen(Inventory[] Items)
        {
            Console.WriteLine("You enter a bedroom.");   // Pan: more description of new room needed in here!
            Console.WriteLine("");
            FifthRoom(Items);
        }

        public static void FifthRoom(Inventory[] Items)
        {
            Console.WriteLine("What now? Use north south east and west to navigate! Type help to get tips!");
            Console.WriteLine("");
            string response = Console.ReadLine();
            response = response.ToLower(); // convert input to lowercase for error control

            //switch to interpert user input
            switch (response)
            {
                // the direction of backing to 2nd room 
                case "west":
                case "go west":
                case "walk west":
                    Console.WriteLine("back");
                    Console.WriteLine("");
                    Thread.Sleep(600);
                    SecondRoomOpen(Items);
                    break;

                // other directions
                case "north":
                case "go north":
                case "walk north":
                    Console.WriteLine("There is nowhere to go in that direction");
                    Console.WriteLine("");
                    Thread.Sleep(600);
                    FifthRoom(Items);
                    break;
                case "east":
                case "go east":
                case "walk east":
                    Console.WriteLine("There is nowhere to go in that direction");
                    Console.WriteLine("");
                    Thread.Sleep(600);
                    FifthRoom(Items);
                    break;
                case "south":
                case "go south":
                case "walk south":
                    Console.WriteLine("There is nowhere to go in that direction");
                    Console.WriteLine("");
                    Thread.Sleep(600);
                    FifthRoom(Items);
                    break;

                // option for the user to check their inventory by calling inventory display method
                case "i":
                case "inventory":
                case "items":
                    InventoryDisplay(Items);
                    FifthRoom(Items);
                    break;
                // option for user to get help if confused
                case "t":
                case "tips":
                case "help":
                    Tips(Items);
                    FifthRoom(Items);
                    break;
                //lets user get a description of the room again in case they are lost
                case "look":
                    FifthRoomOpen(Items); 
                    break;
                default:
                    AliceDonotUnderstand();
                    FifthRoom(Items);
                    break;
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

        public static void Tips(Inventory[] Items)
        {
            // when user needs help with what they want to enter, use this method
            Console.WriteLine("Enter north(n), south(s), west(w), east(e) to let Alice moving into different place.");
            Console.WriteLine("Use 'i' to check your inventory!");
            Console.WriteLine("Try to use look to get a feel for your surroundings again");
            Console.WriteLine("To get some items, type 'get' + the name of the item you want to get.");
            Console.WriteLine("Try using some of the items you have in your inventory!");
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

        public static void threeDoor(Inventory[]Item)
        {

        }
    }
}
