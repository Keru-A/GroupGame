using System;
using System.ComponentModel.Design;
using System.Data;
using System.Dynamic;
using System.Globalization;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Windows.Markup;

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
            //Inventory array called Items. Remember to reference in method to be able to use the inventory.
            Inventory[] Items = new Inventory[6];
            // items designated slots - key 1, drink me bottle 2, eat me cake 3, 
            //call the start screen
            Start(Items);
            Console.ReadLine();

        }

        public static void Start(Inventory[] Items)
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
            // Menu to start and exit the game
            Console.WriteLine("");
            Console.WriteLine("A game by Alice Dowle, Saniya Vahora, Harry Wallace and Pan Zhi");
            Console.WriteLine("");
            Console.WriteLine("Please select an option\n" +
                "1 Enter the rabbit hole\n" +
                "2 Turn back\n");
            string response = Console.ReadLine();

            switch (response)
            {
                case "1":
                    Console.Clear();
                    Opening(Items);
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("Thanks for playing!");
                    break;
                default:
                    Console.WriteLine("Input not recognised");
                    Console.ReadLine();
                    Console.Clear();
                    Start(Items);
                    break;
            }

        }

        public static void Opening(Inventory[] Items)
        {
            //opening 'cutscene' then calls first room
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
            FirstRoomOpen(Items);
        }

        public static void FirstRoomOpen(Inventory[] Items)
        {
            // This method outputs the description of the room. Making this seperate keeps the console clear everytime the player performs an action.
            Console.WriteLine("You look around in bewilderment. You are in a dark hallway with high walls, so high you cannot see the ceiling or even the hole you fell down.\n" +
                "At the north end of the hallway in front of you is a single decrepid door. The door handle almost resembles a nose... And are those an angry pair of eyes resting above it?");
            Thread.Sleep(600);
            Console.WriteLine("'This door is impassable!' Spat the door handle impetuously.\n" +
                "'Impossible?' You ask, 'Surely nothing is impossible.'\n" +
                "'No... Im-PASS-able. You cannot pass it, for it is locked' came the smug response.\n" +
                "Disappointed you cast your eyes back around the room and notice a table that was not there before... and a key lying atop it!");
            Thread.Sleep(600);
            Console.WriteLine("");
            FirstRoom(Items);
        }

        public static void FirstRoom(Inventory[] Items)
        {
            //This is the method for the first location of the game

            //Beginning the game with simple input
            Console.WriteLine("You are in the first room. What will Alice do now? Type help to get tips!");
            Console.WriteLine("");
            string response = Console.ReadLine();
            response = response.ToLower(); // convert input to lowercase for error control


            //switch to interpert user input
            switch (response)
            {
                case "get key":
                case "key":
                case "pick up key":
                    if (Items[1].Name == null && Items[1].Desc == null)     // statement for removing item after player gets it
                    {
                        Items[1].Name = "key";
                        Items[1].Desc = "An old fashioned key. I wonder what it unlocks?";
                        Console.WriteLine("You walk over to the table and pick up the key. It is rather old fashioned looking. It matches the ancient door");
                    }
                    else
                    {
                        Console.WriteLine("You have already get the key in your bag. Type 'i' to check your items.");
                    }
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
                        Console.WriteLine("You approach the door, armed with the rusted key. Before the grumpy door knob can protest and shout at you, you insert the key. The door knob's demeanor changes and he smiles.\n" +
                            "'This door is passable now'\n" +
                            "'Yes thank you, I can see that...'\n" +
                            "And so you head through the door.");
                        Console.WriteLine("");
                        Thread.Sleep(600);
                        SecondRoomOpen(Items);
                    }

                    else
                    {
                        Console.WriteLine("You approach the door, only for the door handle to shout at you. 'I said this door is locked!'");
                        Console.WriteLine("");
                        Thread.Sleep(600);
                        FirstRoom(Items);
                    }
                    break;
                // control for if the user goes the wrong direction
                case "east":
                case "go east":
                case "walk east":
                    Console.WriteLine("There is nowhere to go in that direction, only tall walls that reach out of sight.");
                    Console.WriteLine("");
                    Thread.Sleep(600);
                    FirstRoom(Items);
                    break;
                case "west":
                case "go west":
                case "walk west":
                    Console.WriteLine("There is nowhere to go in that direction, only tall walls that reach out of sight.");
                    Console.WriteLine("");
                    Thread.Sleep(600);
                    FirstRoom(Items);
                    break;
                case "south":
                case "go south":
                case "walk south":
                    Console.WriteLine("There is nowhere to go in that direction, only tall walls that reach out of sight.");
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
            Console.WriteLine("The door closes behind you as you step into a very confusing room. Is it upside down? The doors start at the ceiling don't reach the floor, and it looks like there is furntiture on the ceiling!\n" +
                "At the far end of the dusty room you see a window at the bottom of the wall. As you get closer you see it is extremely tiny! You could barely fit your hand through it if you tried...\n" +
                "Looking up you can see two perculiar items on the table above you. It looks like a little bottle of some mysterious liquid, and some delicious cakes! Maybe if you reach up on your tippy toes you could grab them?");
            Thread.Sleep(600);
            Console.WriteLine("");
            SecondRoom(Items);
        }

        public static void SecondRoom(Inventory[] Items)
        {
            Console.WriteLine("You are in the second room. What will Alice do now? Type help to get tips!");
            Console.WriteLine("");
            string response = Console.ReadLine();
            response = response.ToLower(); // convert input to lowercase for error control


            // switch to interpert user input
            switch (response)
            {
                case "get bottle":
                case "pickup bottle":
                case "pick up bottle":
                case "get potion":
                case "pickup potion":
                case "pick up potion":
                case "bottle":
                case "potion":
                    if (Items[2].Name == null && Items[2].Desc == null)     // statement for removing item after player gets it
                    {
                        Items[2].Name = "Drink me bottle";
                        Items[2].Desc = "It seems dosen't like normal water.";
                        Console.WriteLine("You reach up as high as you can and your fingers touch the tag dangling from the bottle, just enough for you to tug it down. The little bottle has a tag on it which reads 'Drink Me'\n" +
                            "How strange...");
                    }
                    else
                    {
                        Console.WriteLine("There was a bottle on table, now it is in your hand. Type 'i' to check your items.");
                    }
                    Console.WriteLine("");
                    Thread.Sleep(600);
                    SecondRoom(Items); // insert key item into items array then call the beginning of the room back
                    break;

                case "get cakes":
                case "pickup cakes":
                case "pick up cakes":
                case "cakes":
                case "cake":
                case "get cake":
                case "pickup cake":
                case "pick up cake":
                    if (Items[3].Name == null && Items[3].Desc == null)     // statement for removing item after player gets it
                    {
                        Items[3].Name = "Eat me cupcake";
                        Items[3].Desc = "It seems dosen't like normal cupcake.";
                        Console.WriteLine("You reach up your hand as high as you can, your fingers outstretched. You're just a little too short. With a jump you manage to grasp the box in your hand and bring it down with you as you fall back down.\n" +
                            "It's a pretty little treasure box, with decorated cakes inside. The icing reads 'Eat Me'\n" +
                            "Very odd...");
                    }
                    else
                    {
                        Console.WriteLine("There is no cakes on the table because you got the whole box of them. Type 'i' to check your items.");
                    }
                    Console.WriteLine("");
                    Thread.Sleep(600);
                    SecondRoom(Items); // insert key item into items array then call the beginning of the room back
                    break;

                case "use drink me":
                case "drink me":
                case "drink potion":
                case "drink bottle":
                case "use potion":
                case "use bottle":
                case "drink":
                    if (Items[2].Name == "Drink me bottle") //player must have item in inventory to use it
                    {
                        Items[2].Name = null;
                        Items[2].Desc = null;
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
                        Items[3].Name = null;
                        Items[3].Desc = null;
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
                    Console.WriteLine("You approach the small window");
                    if (small == true)
                    {
                        Console.WriteLine("You are small enough. You walk through the window.");
                        Console.WriteLine("");
                        Thread.Sleep(600);
                        ThirdRoomOpen(Items);
                    }
                    else
                    {
                        Console.WriteLine("The window is too small for you. You can only put your finger in.");
                        Console.WriteLine("");
                        Thread.Sleep(600);
                        SecondRoom(Items);
                    }
                    break;

                case "east":
                case "go east":
                case "walk east":
                    Console.WriteLine("There is a secret tiny door in this direction");
                    if (small == true)
                    {
                        Console.WriteLine("You're tiny enough to squeeze through the door");
                        Console.WriteLine("");
                        Thread.Sleep(600);
                        FifthRoomOpen(Items);
                    }

                    else
                    {
                        Console.WriteLine("You're too big to fit through here");
                        Console.WriteLine("");
                        Thread.Sleep(600);
                        SecondRoom(Items);
                    }
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
                case "back":
                case "turn around":
                case "turn back":
                case "go back":
                    Console.WriteLine("You turn around and go back"); //lets the user enter the previous room
                    Console.WriteLine("");
                    Thread.Sleep(600);
                    FirstRoom(Items);
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
            Console.WriteLine("You are in the third room. There are huge stairs in on the west side of the room! They are much too big to climb!");
            Console.WriteLine("");
            ThirdRoom(Items);
        }

        public static void ThirdRoom(Inventory[] Items)
        {
            Console.WriteLine("You are in the third room. What next? Use north south east and west to navigate!");
            Console.WriteLine("");
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
                        Console.WriteLine("You're too small!! How could you get bigger? Did you eat the cakes?");
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
                case "back":
                case "turn around":
                case "turn back":
                case "go back":
                    Console.WriteLine("You turn and go back");
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
            Console.WriteLine("Standing infront of the first door at the north end of the room are two very odd looking men");
            Console.WriteLine("There other 3 doors are grouped together along the east wall");
            Thread.Sleep(600);
            Console.WriteLine("Which way will you go?");
            Console.WriteLine("");
            string response = Console.ReadLine();
            response = response.ToLower();
            switch (response)
            {

                case "north":
                case "go north":
                case "walk north":
                case "door":
                    Console.WriteLine("");
                    Console.WriteLine("You approach the funny looking twins");
                    Riddle(Items);
                    break;
                case "west":
                case "go west":
                case "walk west":
                    Console.WriteLine("There is nowhere to go in that direction");
                    Console.WriteLine("");
                    break;
                case "east":
                case "go east":
                case "walk east":
                case "back":
                case "turn around":
                case "turn back":
                case "go back":
                    Console.WriteLine("You turn around and go back");
                    Console.WriteLine("");
                    ThirdRoomOpen(Items);
                    break;
                case "south":
                case "go south":
                case "walk south":
                    Console.WriteLine("");
                    Console.WriteLine("You approach the three doors.");
                    ThreeDoorOpen(Items);
                    break;
                case "i":
                case "inventory":
                case "items":
                    InventoryDisplay(Items);
                    FourthRoom(Items);
                    break;
                case "t":
                case "tips":
                case "help":
                    Tips(Items);
                    FourthRoom(Items);
                    break;
                case "look":
                    FourthRoom(Items); //lets user get a description of the room again
                    break;
                default:
                    AliceDonotUnderstand();
                    FourthRoom(Items);
                    break;
            }
        }

        public static void Riddle(Inventory[] Items)
        {
            Console.WriteLine("You walk north and find a door being guarded by Tweedledee and Tweedledum, they have a riddle for you...");
            Console.WriteLine("You must answer correctly in order to pass through the door.");
            Console.WriteLine("");
            Console.WriteLine("Here is the riddle...");
            Console.WriteLine("");
            Console.WriteLine("This thing all things devours:\n Birds, beasts, trees, flowers;\n Gnaws iron, bites steel;\n Grinds hard stones to meal;\n Slays King, ruins town,\n And beats high mountain down.");
            Console.WriteLine("");
            Thread.Sleep(600);

            string response;
            int count = 0;
            do
            {
                Console.WriteLine("Enter your answer: ");
                response = Console.ReadLine();
                response = response.ToLower();
                if (response != "time")
                {
                    Console.WriteLine("That is not the correct answer, try again");
                    Console.WriteLine("");
                    count++;
                }
            }
            while (response != "time" && count < 5);

            if (count >= 5)
            {
                Console.WriteLine("You took too many tries! You lose");
                GameOver(Items);
            }
            else
            {
                Console.WriteLine("Correct! You have successfully answered the riddle and may now pass through TweedleDee and TweedleDum's door");
                Console.WriteLine("");
                Console.ReadLine();
                WinningGame(Items);
            }
        }



        // This is the new method for winning the game //
        public static void WinningGame(Inventory[] Items)
        {
            Console.WriteLine("Congratulations! You have won the game and thus emerge through TweedleDee and TweedleDum's door victorious.");

            Console.WriteLine("Play again? Y/N");
            string response = Console.ReadLine();
            response = response.ToUpper();

            //if statement to check answer
            if (response == "Y")
            {
                Console.Clear();
                Start(Items);
                FirstRoom(Items);
            }

            else
            {
                Console.WriteLine("Thanks for playing!");
                Console.ReadLine();
                Environment.Exit(0);
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
                case "back":
                case "turn around":
                case "turn back":
                case "go back":
                    Console.WriteLine("You turn around and go back");
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
        public static void ThreeDoorOpen(Inventory[] Items)
        {
            Console.WriteLine("You face the three doors. Which door will you go in? Door 1, Door 2, or Door 3?");
            Console.WriteLine("");
            string response = Console.ReadLine();
            response = response.ToLower();
            switch (response)
            {
                case "door1":
                case "door 1":
                    Door1(Items);
                    break;
                case "door2":
                case "door 2":
                    Console.WriteLine("It is an empty broom closet");
                    Console.ReadLine();
                    ThreeDoorOpen(Items);
                    break;
                case "door3":
                case "door 3":
                    Console.WriteLine("");
                    Door3(Items);
                    break;
                case "south":
                case "back":
                case "turn around":
                case "turn back":
                case "go back":
                    Console.WriteLine("You turn around and go back");
                    Console.ReadLine();
                    FourthRoom(Items);
                    break;
                default:
                    AliceDonotUnderstand();
                    ThreeDoorOpen(Items);
                    break;
            }
        }


        public static void Door1(Inventory[] Items)
        {
            Console.WriteLine("The white rabbit is there. He tells you a tip for dealing with Tweedle Dee and Tweedle Dum");
            Console.WriteLine("He holds up his pocket watch and points at it. What could that mean?");
            Console.WriteLine("He looks panicked and quickly ushers you back out the door");
            Console.ReadLine();
            ThreeDoorOpen(Items);
        }
        public static void Door3(Inventory[] Items)
        {
            Console.WriteLine("You walk through the third door and see the Red Queen, she is furious!");
            GameOver(Items);
        }

        public static void GameOver(Inventory[] Items)
        {
            //This is the game over screen method
            Console.WriteLine("The Red Queen got you! Off with your head!");
            Console.WriteLine("Game Over");
            Console.WriteLine("");

            //ask to play again
            Console.WriteLine("Play again? Y/N");
            string response = Console.ReadLine();
            response = response.ToUpper();

            //if statement to check answer
            if (response == "Y")
            {
                Console.Clear();
                Start(Items);
                FirstRoom(Items);
            }

            else
            {
                Console.WriteLine("Thanks for playing!");
                Console.ReadLine();
                Environment.Exit(0);
            }
        }

        public static void Tips(Inventory[] Items)
        {
            // when user needs help with what they want to enter, use this method
            Console.WriteLine("Enter north(n), south(s), west(w), east(e) to get Alice to move about the area.");
            Console.WriteLine("You can turn back too if you want!");
            Console.WriteLine("Use 'i' to check your inventory!");
            Console.WriteLine("Try to use 'look' to get a feel for your surroundings again");
            Console.WriteLine("To get some items, type 'get' + the name of the item you want to get.");
            Console.WriteLine("Try using some of the items you have in your inventory!");
        }

        public static void AliceDonotUnderstand()
        {
            //when user typing anything which is not in switch cases, use this method
            Random rand = new Random();
            int temp = rand.Next(1, 5);
            switch (temp)
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
        }

        public static void ForestOneOpen(Inventory[] Items)
        {

        }
        public static void ForestOne(Inventory[] Items)
        {
            Console.WriteLine("You are at the beginning of the forest...");
            Console.WriteLine("Which path will you take?");
            Console.WriteLine("");
            string response = Console.ReadLine();
            response = response.ToLower();

            switch (response)
            {

                case "north": //correct direction
                case "go north":
                case "walk north":
                case "door":
                    Console.WriteLine("You take the northern path");
                    Console.WriteLine("The darkness surrounding you feels like it lifts as you get closer to the exit");
                    Console.WriteLine("");
                    ForestTwo(Items);
                    break;
                case "west":
                case "go west":
                case "walk west":
                    Console.WriteLine("You take the western path");
                    Console.WriteLine("The darkness of the forest fills your vision and you lose all sense of direction...");
                    Console.WriteLine("");
                    ForestOne(Items);
                    break;
                case "east":
                case "go east":
                case "walk east":
                    Console.WriteLine("You take the eastern path");
                    Console.WriteLine("The darkness of the forest fills your vision and you lose all sense of direction...");
                    Console.WriteLine("");
                    ForestOne(Items);
                    break;
                case "south":
                case "go south":
                case "walk south":
                    Console.WriteLine("You take the southern path");
                    Console.WriteLine("The darkness of the forest fills your vision and you lose all sense of direction...");
                    Console.WriteLine("");
                    ForestOne(Items);
                    break;
                case "i":
                case "inventory":
                case "items":
                    InventoryDisplay(Items);
                    ForestOne(Items);
                    break;
                case "t":
                case "tips":
                case "help":
                    Tips(Items);
                    ForestOne(Items);
                    break;
                case "look":
                    ForestOne(Items);
                    break;
                default:
                    AliceDonotUnderstand();
                    ForestOne(Items);
                    break;
            }

        }

        public static void ForestTwo(Inventory[] Items)
        {
            Console.WriteLine("You are in the second part of the forest...");
            Console.WriteLine("Which path will you take?");
            Console.WriteLine("");
            string response = Console.ReadLine();
            response = response.ToLower();

            switch (response)
            {

                case "north": 
                case "go north":
                case "walk north":
                case "door":
                    Console.WriteLine("You take the northern path");
                    Console.WriteLine("The darkness of the forest fills your vision and you lose all sense of direction...");
                    Console.WriteLine("");
                    ForestTwo(Items);
                    break;
                case "west":
                case "go west":
                case "walk west":
                    Console.WriteLine("You take the western path");
                    Console.WriteLine("The darkness of the forest fills your vision and you lose all sense of direction...");
                    Console.WriteLine("");
                    ForestTwo(Items);
                    break;
                case "east": //correct direction
                case "go east":
                case "walk east":
                    Console.WriteLine("You take the eastern path");
                    Console.WriteLine("The darkness surrounding you feels like it lifts as you get closer to the exit");
                    Console.WriteLine("");
                    //ForestThree?(Items);
                    break;
                case "south":
                case "go south":
                case "walk south":
                    Console.WriteLine("You take the southern path");
                    Console.WriteLine("The darkness of the forest fills your vision and you lose all sense of direction...");
                    Console.WriteLine("");
                    ForestTwo(Items);
                    break;
                case "i":
                case "inventory":
                case "items":
                    InventoryDisplay(Items);
                    ForestOne(Items);
                    break;
                case "t":
                case "tips":
                case "help":
                    Tips(Items);
                    ForestOne(Items);
                    break;
                case "look":
                    ForestOne(Items);
                    break;
                default:
                    AliceDonotUnderstand();
                    ForestOne(Items);
                    break;
            }
        }
        
    }
}
