//main
using System.ComponentModel;
using System.Net;
using System.Security.Principal;

if (!Console.IsOutputRedirected)
    Console.Clear();
var mMenu = 0;
var coins = 5;
var points = 0;
bool itr = true;
while (mMenu != 4 || itr)
{
    if (coins > 0 || points >= 15)
    {
        System.Console.WriteLine("=============================="); // Prettier menu system for the game
        System.Console.WriteLine("||1.Visit the Magical Lake  ||"); //Fishing occurs at the lake
        System.Console.WriteLine("||2.Visit the Old Man       ||"); // Play war at the old man's cabin
        System.Console.WriteLine("||3.Bank                    ||"); // Bank to view points and coins
        System.Console.WriteLine("||4.Exit                    ||");
        System.Console.WriteLine("==============================");
        mMenu = GetInt();
        switch (mMenu)
        {
            case (1):
                MagicLake(ref coins, ref points);
                break;
            case (2):
                OldMan(ref coins);
                break;
            case (3):
                Bank(coins, points);
                break;
            case (4):
                itr = false;
                break;
        }
    }
    else if (points >= 15)
    {
        Win();
        itr = false;
    }
    else
    {
        Broke();
        itr = false;
    }

}
//End main

//Start of Magic Lake menu 
static void MagicLake(ref int coins, ref int points)
{                           //Picture generated from ASCII art, looks prettier for the game, Main menu for the Magic lake
    if (!Console.IsOutputRedirected)
        Console.Clear();
    bool whileitr = true;
    while (whileitr)
    {
        System.Console.WriteLine(@"  
        /\        /\        /\        /\                 /\        /\        /\        /\                  
       /**\      /**\      /**\      /**\               /**\      /**\      /**\      /**\         
      /****\    /****\    /****\    /****\             /****\    /****\    /****\    /****\  
     /******\  /******\  /******\  /******\           /******\  /******\  /******\  /******\  
    /********\/********\/********\/********\         /********\/********\/********\/********\  
   /**********\********\********/**********\        /**********\********\********/**********\  
  ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
  ~~~~~~~~  ~~~~~~~~~~              ~~~~~~~~     ~~~~~~~~    ~~~~~~~~~~~~~~~~~       ~~~~~~~~~
 ~~~~~~ ~~~~~~~~~        ~~~~~~~~~~~~~~~~~~~        ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
~~~~~~~ ~~~~~~~~~~~~~      ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~           ~~~~~~~~~~~~~~~~~~
~~~~~~~~~~~~~~  ~~~~~~~~~~~~~~  ~~~~~~~~~~~~~~~~~~  ~~~~~~~~~~~~~~~~~~~~    ~~~~~~~~~~~~~~~~~~~");


        System.Console.WriteLine("========================================================================================================");
        System.Console.WriteLine("||Welcome to the magical lake! While here you can go fishing with bait you can purchase from the shop!||");
        System.Console.WriteLine("||Be carefull though i've heard some of the fish may try and fight back this time of year.            ||");
        System.Console.WriteLine("||What would you like to do at the lake:  1. Buy bait and Fish      2. Exit                           ||");
        System.Console.WriteLine("========================================================================================================");
        int fMenu = GetInt();

        switch (fMenu)
        {
            case (1):
                if (coins > 0)
                {
                    Fishing(ref coins, ref points);
                }
                else
                {
                    Broke();
                    whileitr = false;
                    break;
                }
                break;
            case (2):
                whileitr = false;
                break;
            case (3):
                break;
            default:
                System.Console.WriteLine("Invalid menu choice Exiting to main menu ...");
                break;
        }
    }
}
// Fishing Mini game 
static void Fishing(ref int coins, ref int points)
{
    bool itr = true;
    while (itr)
    {

        System.Console.WriteLine("=========================================");
        System.Console.WriteLine("||What kind of bait would you like to  ||");
        System.Console.WriteLine("||use.                                 ||");
        System.Console.WriteLine("||1. Normal Bait                       ||");
        System.Console.WriteLine("||2. Special Bait                      ||");
        System.Console.WriteLine("||3. Super Bait                        ||");
        System.Console.WriteLine("||4. Exit                               ||");
        System.Console.WriteLine("=========================================");
        int fGame = GetInt();

        //Check to see if user has enough coins to purchase bait
        if (fGame == 1 && coins <= 3)
        {
            System.Console.WriteLine("You can't afford to purchase this bait.");
            itr = false;
        }
        if (fGame == 2 && coins <= 6)
        {
            System.Console.WriteLine("You can't afford to purchase this bait.");
            itr = false;

        }
        if (fGame == 3 && coins <= 7)
        {
            System.Console.WriteLine("You can't afford to purchase this bait.");
            MagicLake(ref coins, ref points);
            itr = false;


        }
        Random rnd = new Random();
        int fishPercent = rnd.Next(10);
        if (fishPercent < 5)
        {
            if (fGame == 1)
            {
                System.Console.WriteLine("Congratulations you have caught a bass");
                System.Console.WriteLine(@"        ><(((('>    ");
                coins = coins - 3;
                points = points + 4;
            }
            else
            {
                System.Console.WriteLine("The bass Swam away");
                coins = coins - 3;

            }
        }
        else if (fishPercent >= 5 && fishPercent <= 7)
        {

            if (fGame == 2)
            {
                System.Console.WriteLine("Congratulations you have caught a shark");
                System.Console.WriteLine(@"
             \.          |\
              \`.___---~~  ~~~--_
                 //~~----___  (_o_-~
                '           |/' ");
                coins = coins - 5;
                points = points + 6;
            }
            else
            {
                System.Console.WriteLine("The Shark Swam away");
                coins = coins - 5;


            }
        }
        else if (fishPercent >= 8)
        {
            if (fGame == 3)
            {
                System.Console.WriteLine("Congratulations you have caught a whale");
                System.Console.WriteLine(@"                         
                      . .
                    '.-:-.`
                    '  :  `
                 .-----:
               .'       `.
         ,    /       (o) \
         \`._/          ,__)
     ~~~~~~~~~~~~~~~~~~~~~~~~~~~~
   ");
                coins = coins - 7;
                points = points + 10;
            }
            else
            {
                System.Console.WriteLine("The whale Swam away");
                coins = coins - 7;
            }
        }
        if (fGame == 4)
        {
            System.Console.WriteLine("Going back to the Magical lake....");
            itr = false;


        }
    }
}

//End of Magic Lake methods & Combat
//Start of Old Man releated Methods
static void OldMan(ref int coins)
{
    if (!Console.IsOutputRedirected)
        Console.Clear();
    bool itr = true;
    while (itr)
        if (coins > 0)
        {
            System.Console.WriteLine(@"        
              ,-----.
            W/,-. ,-.\W
            ()>a   a<()
            (.--(_)--.)
          ,'/.-'\_/`-.\`.
        ,' /    `-'    \ `.
       /   \           /   \
      /     `.       ,'     \
     /    /   `-._.-'   \    \
   ,-`-._/|     |=|o    |\_.-<
  <,--.)  |_____| |o____|  )_ \
   `-)|    |//   _   \\|     )/
     ||    |'    |    `|
     ||    |     |     |
     ||    (    )|(    )
     ||    |     |     |
     ||    |     |     |
     ||    |_.--.|.--._|
     ||     /'""| |""`\
     []     `===' `===' ");
            System.Console.WriteLine("===============================================");
            System.Console.WriteLine("||Well howdy there partner,                  ||");
            System.Console.WriteLine("||would you like to play some cards          ||");
            System.Console.WriteLine("===============================================");
            System.Console.WriteLine("||1.Play War against the Old Man             ||");
            System.Console.WriteLine("||2.Play Blackjack against the Old Man       ||");
            System.Console.WriteLine("||3.Leave                                    ||");
            System.Console.WriteLine("===============================================");
            int oldManMenu = GetInt();


            switch (oldManMenu)
            {
                case (1):
                    OldMansWar(ref coins);
                    break;
                case (2):
                    Blackjack(ref coins);
                    break;
                case (3):
                    itr = false;
                    break;
                default:
                    break;
            }

        }
        else
        {
            Broke();
            itr = false;
            break;
        }
}

static void OldMansWar(ref int coins)
{
    bool itr = true;
    while (itr)
    {
        System.Console.WriteLine("===============================================================");
        System.Console.WriteLine("||In this game you play the card game war against the olf man||");
        System.Console.WriteLine("||If you win the card you double the amount of your wager.   ||");
        System.Console.WriteLine("||If you loose you loose your wager.                         ||");
        System.Console.WriteLine("|| Who ever draws a higher card off the top of the deck wins ||");
        System.Console.WriteLine("|| but at the start of each round a random suit is selected  ||");
        System.Console.WriteLine("||as the trump suit. Any card in the trump suit beats any    ||");
        System.Console.WriteLine("|| other card.                                               ||");
        System.Console.WriteLine("===============================================================");
        System.Console.WriteLine("|| How many coins would you like too wager?  -1 to exit      ||");
        System.Console.WriteLine("===============================================================");
        int wager = GetWager(coins);
        if (wager == -1)
        {
            itr = false;

        }
        else
        {


            Random RND = new Random();
            int trumpSuit = RND.Next(4); // Random Numbers to for each play card & suit.. and for old man card & suit & Trump suit
            int userCard = RND.Next(13);
            int userSuit = RND.Next(4);
            int oldManCard = RND.Next(13);
            int oldManSuit = RND.Next(4);
            int[] cards = new int[13]; //Card array
            cards[0] = 2;
            cards[1] = 3;
            cards[2] = 4;
            cards[3] = 5;
            cards[4] = 6;
            cards[5] = 7;
            cards[6] = 8;
            cards[7] = 9;
            cards[8] = 10;
            cards[9] = 11; // jack
            cards[10] = 12; //Queen
            cards[11] = 13; //King
            cards[12] = 14; //Ace


            string[] suit = new string[4]; //Suit array
            suit[0] = "♠";
            suit[1] = "♥";
            suit[2] = "♣";
            suit[3] = "♦";

            //Actual card val & suit being used
            int userPlayCard = cards[userCard];
            int oldManPlayCard = cards[oldManCard];
            string userPlaySuit = suit[userSuit];
            string oldManPlaySuit = suit[oldManSuit];
            string trumpSuitPlay = suit[trumpSuit];
            int winCon;    //Win con used in the display

            //Check to see if computer and user have the came card
            while (userPlayCard == oldManPlayCard && userPlaySuit == oldManPlaySuit)
            {
                // If the have they same card cards are re generated until card values no longer match.
                // Random Numbers to for each play card & suit.. and for old man card & suit & Trump suit
                userCard = RND.Next(13);
                userSuit = RND.Next(4);
                oldManCard = RND.Next(13);
                oldManSuit = RND.Next(4);
                userPlayCard = cards[userCard];
                oldManPlayCard = cards[oldManCard];
                userPlaySuit = suit[userSuit];
                oldManPlaySuit = suit[oldManSuit];
            }

            //War game logic
            if (trumpSuitPlay != userPlaySuit && trumpSuitPlay == oldManPlaySuit)
            {
                winCon = -1;
                coins = coins - wager;    //updates coins
                DisplayWar(wager, userPlayCard, oldManPlayCard, trumpSuitPlay, userPlaySuit, oldManPlaySuit, winCon);
            }
            else if (trumpSuitPlay == userPlaySuit && trumpSuitPlay != oldManPlaySuit)
            {
                winCon = 1;
                coins = coins + wager * 2;
                DisplayWar(wager, userPlayCard, oldManPlayCard, trumpSuitPlay, userPlaySuit, oldManPlaySuit, winCon);
            }
            else if (trumpSuitPlay == userPlaySuit && trumpSuitPlay == oldManPlaySuit)
            {
                if (userPlayCard == oldManPlayCard)
                {
                    winCon = 0;
                    DisplayWar(wager, userPlayCard, oldManPlayCard, trumpSuitPlay, userPlaySuit, oldManPlaySuit, winCon);
                }
                else if (userPlayCard > oldManPlayCard)
                {
                    winCon = 1;
                    coins = coins + wager * 2;
                    DisplayWar(wager, userPlayCard, oldManPlayCard, trumpSuitPlay, userPlaySuit, oldManPlaySuit, winCon);
                }
                else if (userPlayCard < oldManPlayCard)
                {
                    winCon = -1;
                    coins = coins - wager;
                    DisplayWar(wager, userPlayCard, oldManPlayCard, trumpSuitPlay, userPlaySuit, oldManPlaySuit, winCon);
                }
            }
            else
            {
                if (userPlayCard == oldManPlayCard)
                {
                    winCon = 0;
                    DisplayWar(wager, userPlayCard, oldManPlayCard, trumpSuitPlay, userPlaySuit, oldManPlaySuit, winCon);
                }
                else if (userPlayCard > oldManPlayCard)
                {
                    winCon = 1;
                    coins = coins + wager * 2;
                    DisplayWar(wager, userPlayCard, oldManPlayCard, trumpSuitPlay, userPlaySuit, oldManPlaySuit, winCon);
                }
                else if (userPlayCard < oldManPlayCard)
                {
                    winCon = -1;
                    coins = coins - wager;
                    DisplayWar(wager, userPlayCard, oldManPlayCard, trumpSuitPlay, userPlaySuit, oldManPlaySuit, winCon);
                }
            }
        }
    }
}

static void DisplayWar(int wager, int userPlayCard, int oldManPlayCard, string trumpSuitPlay, string userPlaySuit, string oldManPlaySuit, int winCon)
{
    System.Console.WriteLine("==========================================================================================================");
    System.Console.WriteLine($"||Your Card:                     Trump Suit:{trumpSuitPlay}                                                                           Old Man card:||");
    System.Console.WriteLine("||  -----------------                                                               -----------------   ||");
    System.Console.WriteLine($"|| | {userPlayCard,-2}                |                                                            | {oldManPlayCard,-2}                |  ||");
    System.Console.WriteLine("|| |                   |                                                            |                   |  ||");
    System.Console.WriteLine("|| |                   |                                                            |                   |  ||");
    System.Console.WriteLine("|| |                   |                                                            |                   |  ||");
    System.Console.WriteLine($"|| |                {userPlaySuit,2} |                                                            |                {oldManPlaySuit,2} |  ||");
    System.Console.WriteLine("||  -----------------                                                               -----------------   ||");
    System.Console.WriteLine("==========================================================================================================");

    // Display win/loss message
    if (winCon == -1)
    {
        System.Console.WriteLine($"|| You wagered: {wager} and lost. You now have {wager} fewer coins.                                                              ||");
    }
    else if (winCon == 1)
    {
        System.Console.WriteLine($"|| You wagered: {wager} and won! You now have {wager} more coins.                                                               ||");
    }
    else
    {
        System.Console.WriteLine($"|| You wagered: {wager} and it's a tie! Your bet is a push                                                           ||");
    }

    System.Console.WriteLine("==========================================================================================================");
}
//how the user can view points and coins
static void Bank(int coins, int points)
{
    bool itr = true;
    System.Console.WriteLine(@"      
        _________________
       |                 |
       |       BANK       |
       |  ______________  |
       | |              | |
  ____ | |   ████████   | | ____
 |____|| |   █      █   | ||____|
 |____|| |   █      █   | ||____|
 |____|| |   ████████   | ||____|
 |____|| |______________| ||____|
 |__________________________|
      /_/              \_\");
    while (itr)
    {


        System.Console.WriteLine("===============================================");
        System.Console.WriteLine("||Welcome to the Bank here you can view your ||");
        System.Console.WriteLine("||coins and points                           ||");
        System.Console.WriteLine("===============================================");
        System.Console.WriteLine("||1. View Coins                              ||");
        System.Console.WriteLine("||2. View Points                             ||");
        System.Console.WriteLine("||3. Exit                                    ||");
        System.Console.WriteLine("===============================================");
        int userchoice = GetInt();

        if (userchoice == 1)
        {
            System.Console.WriteLine("========================");
            System.Console.WriteLine($"||You have {coins} coins||");
            System.Console.WriteLine("========================");
        }
        else if (userchoice == 2)
        {
            System.Console.WriteLine("========================");
            System.Console.WriteLine($"||You have {points} points||");
            System.Console.WriteLine("========================");
        }
        else if (userchoice == 3)
        {
            itr = false;
        }
    }
}

static void Blackjack(ref int coins)
{
    bool itr = true;
    while (itr)
    {
        System.Console.WriteLine("============================================================");
        System.Console.WriteLine("||Welcome to BlackJack in this game you can Hit stand or   ||");
        System.Console.WriteLine("||double down. Aces count as a 1 or an 11 depending on how ||");
        System.Console.WriteLine("||how many cards you have. All face cards count as 10.     ||");
        System.Console.WriteLine("============================================================");
        System.Console.WriteLine("||How much would you like to wager?    -1 To exit          ||");
        System.Console.WriteLine("=============================================================");
        int wager = GetWager(coins);
        if (wager == -1)
        {
            itr = false;
        }
        else
        {

            Random RND = new Random();

            string[] usersuits = new string[10];//Storing users suits in an array
            usersuits[0] = HitMe2();
            usersuits[1] = HitMe2();
            int[] userCards = new int[10];//Storing the users card values in an array
            userCards[0] = HitMe();
            userCards[1] = HitMe();

            //Same thing for the computer
            int[] oldManCards = new int[10];
            oldManCards[0] = HitMe();
            oldManCards[1] = HitMe();
            string[] oldManSuits = new string[10];
            oldManSuits[0] = HitMe2();
            oldManSuits[1] = HitMe2();
            bool userTurnOver = false;

            int winCon = 5;
            int totaluser = CalculateTotal(userCards);
            int totalComputer = CalculateTotal(oldManCards);


            //BJ logic for the user side
            int p = 2;//Starts with 2 cards alread delt
            while (totaluser <= 21 && !userTurnOver)
            {

                BlackjackDisplay(usersuits, oldManSuits, userCards, oldManCards, winCon, userTurnOver);
                int userchoice = GetInt();

                if (userchoice == 1)//hit
                {
                    userCards[p] = HitMe();
                    usersuits[p] = HitMe2();
                    totaluser = CalculateTotal(userCards);
                    p++; //Move to next card slot
                }
                else if (userchoice == 2)//Stand
                {
                    userTurnOver = true;
                }
                else if (userchoice == 3)//Double
                {
                    userCards[p] = HitMe();
                    usersuits[p] = HitMe2();
                    totaluser = CalculateTotal(userCards);
                    winCon = 3;
                    userTurnOver = true;

                    break;
                }


            }
            //BJ logic for the computer side hits till 17
            while (totalComputer < 17)// Check if total is less than 17
            {
                for (int i = 2; i < oldManCards.Length; i++)// finding the next empty cell
                {
                    if (oldManCards[i] == 0) //if total less than 15 and cell still aviable hit
                    {
                        oldManCards[i] = HitMe();
                        oldManSuits[i] = HitMe2();
                        totalComputer = CalculateTotal(oldManCards);
                        break; //Exit for loop computer hits or stands
                    }
                }
            }
            totaluser = CalculateTotal(userCards);
            totalComputer = CalculateTotal(oldManCards);

            //Win Loss logic
            if (winCon == 3)//Double down
            {
                if (totaluser > totalComputer && totaluser <= 21)
                {
                    coins = coins + wager * 2 * 2; //Double down
                    winCon = 1;
                    BlackjackDisplay(usersuits, oldManSuits, userCards, oldManCards, winCon, userTurnOver);
                    itr = false;


                }
                else if (totaluser < totalComputer || totaluser > 21)
                {
                    coins = coins - wager * 2 * 2;
                    winCon = -1;
                    BlackjackDisplay(usersuits, oldManSuits, userCards, oldManCards, winCon, userTurnOver);
                    itr = false;

                }
            }
            else
            {
                if (totaluser > 21)
                {
                    coins = coins - wager;
                    winCon = -1;
                    BlackjackDisplay(usersuits, oldManSuits, userCards, oldManCards, winCon, userTurnOver);
                    itr = false;

                }
                else if (totalComputer > 21)
                {
                    coins = coins + wager * 2;
                    winCon = 1;
                    BlackjackDisplay(usersuits, oldManSuits, userCards, oldManCards, winCon, userTurnOver);
                    itr = false;


                }
                else if (totaluser > totalComputer)
                {
                    coins = coins + wager * 2;
                    winCon = 1;
                    BlackjackDisplay(usersuits, oldManSuits, userCards, oldManCards, winCon, userTurnOver);
                    itr = false;


                }
                else if (totaluser < totalComputer)
                {
                    coins = coins - wager;
                    winCon = -1;
                    BlackjackDisplay(usersuits, oldManSuits, userCards, oldManCards, winCon, userTurnOver);
                    itr = false;

                }
            }
        }
    }
}
static int CalculateTotal(int[] cards) //method for calculating total
{
    int total = 0;
    int aceCount = 0;

    // Calculate total and ace count
    for (int i = 0; i < cards.Length; i++)
    {
        if (cards[i] == 11) // Ace
        {
            aceCount++;
        }
        total += cards[i];
    }

    // Adjust for Aces if total exceeds 21
    while (total > 21 && aceCount > 0)
    {
        total -= 10; // Ace counts as a 1 instead of an 11 now
        aceCount--;
    }

    return total;
}

static int HitMe() //returns a rnd card from the array
{
    Random RND = new Random();
    int rndcard = RND.Next(13);

    int[] cards = new int[13]; //Card array
    cards[0] = 2;
    cards[1] = 3;
    cards[2] = 4;
    cards[3] = 5;
    cards[4] = 6;
    cards[5] = 7;
    cards[6] = 8;
    cards[7] = 9;
    cards[8] = 10;
    cards[9] = 10; // jack
    cards[10] = 10; //Queen
    cards[11] = 10; //King
    cards[12] = 11; //Ace special uses with an ace 

    //Although they all have the same value in a game of black jack
    return cards[rndcard];

}

static string HitMe2()
{
    Random RND = new Random();
    int rndsuit = RND.Next(4);
    string[] suit = new string[4]; //Suit array
    suit[0] = "♠";
    suit[1] = "♥";
    suit[2] = "♣";
    suit[3] = "♦";
    return suit[rndsuit];
}
static void BlackjackDisplay(string[] userSuits, string[] oldManSuits, int[] userCards, int[] oldManCards, int winCon, bool userTurnOver)
{
    int totaluser = CalculateTotal(userCards);
    int totalComputer = CalculateTotal(oldManCards);
    // Display user's cards

    Console.WriteLine("Your Cards:          Dealer cards:");
    Console.Write("");
    for (int i = 0; i < userCards.Length; i++)
    {
        if (userCards[i] != 0)
        {
            Console.Write($"{userCards[i]}{userSuits[i]} ");
        }
    }

    Console.Write("\t\t\t");
    // Display dealer's cards
    Console.Write($"{oldManCards[0]}{oldManSuits[0]} "); // Always show the dealer's first card other cards not shown till game ends
    if (userTurnOver)
    {
        // Show the dealer's second card and any other cards the dealer hits on
        for (int i = 1; i < oldManCards.Length; i++)
        {
            if (oldManCards[i] != 0)
            {
                Console.Write($"{oldManCards[i]}{oldManSuits[i]} ");
            }
        }
    }
    else
    {
        Console.Write("??"); // Hide the dealer's other cards
    }
    System.Console.WriteLine("");
    System.Console.WriteLine("1.Hit");
    System.Console.WriteLine("2.Stand");
    System.Console.WriteLine("3.Double Down"); s
    // Display totals

    Console.WriteLine($"Your Total: {totaluser}");
    if (userTurnOver)
    {
        System.Console.WriteLine($"Dealer total: {totalComputer}");
    }

    // Determine win/loss/tie condition using winCon
    if (winCon == -1)
    {
        Console.WriteLine("You lose.");
    }
    else if (winCon == 1)
    {
        Console.WriteLine("You win!");
    }
    else if (winCon == 0)
    {
        Console.WriteLine("It's a tie! Your bet has been returned.");
    }
    if (userTurnOver)// allow user to see display after game ends
    {
        System.Console.WriteLine("Enter a key to continue");
        Console.ReadKey();
    }
}

static void Broke()//Display lost and exit game
{
    System.Console.WriteLine("===========================================");
    System.Console.WriteLine("||Game over kid your broke.....          ||");
    System.Console.WriteLine("===========================================");
    Environment.Exit(1);


}

static void Win()//Display win and exit game
{
    System.Console.WriteLine("===========================================");
    System.Console.WriteLine("||    Congratulations you've won!        ||");
    System.Console.WriteLine("===========================================");
    Environment.Exit(1);
}

static int GetInt() //Error handiling with user entry 
{
    int entry = 0;
    bool itr = true;
    while (itr)
    {
        try
        {
            entry = int.Parse(Console.ReadLine());

            if (entry < 0)//Only allowed to enter positive numbers
            {
                itr = true;
                System.Console.WriteLine("Invalid entry try again");
            }
            else if (entry != 0)
            {
                itr = false;
            }

        }
        catch
        {
            System.Console.WriteLine("Invalid entry try again");
        }
    }
    return entry;
}

//Seperate return for wager, handling with betting more coins than you have or betting a negitive / string
static int GetWager(int coins)
{
    {
        int entry = 0;
        bool itr = true;
        while (itr)
        {
            try
            {
                entry = int.Parse(Console.ReadLine());
                if (entry == -1)
                {
                    itr = false;
                }
                else if (entry < 0 || entry > coins)//Only allowed to enter positive numbers cant bet more money than you have
                {
                    itr = true;
                    System.Console.WriteLine("Can't wager a negative number, or wager more coins than you have");
                }
                else if (entry != 0)
                {
                    itr = false;
                }

            }
            catch
            {
                System.Console.WriteLine("Invalid wager try again");
            }
        }
        return entry;
    }
}


