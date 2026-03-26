// See https://aka.ms/new-console-template for more information
/*
 * 
 * You need to create a game that consists of asking the player what's the result of a math question (i.e. 9 x 9 = ?), collecting the input and adding a point in case of a correct answer.

A game needs to have at least 5 questions.

The divisions should result on INTEGERS ONLY and dividends should go from 0 to 100. Example: Your app shouldn't present the division 7/2 to the user, since it doesn't result in an integer.

Users should be presented with a menu to choose an operation

You should record previous games in a List and there should be an option in the menu for the user to visualize a history of previous games.

You don't need to record results on a database. Once the program is closed the results will be deleted.

*/


// Random that will be used troughout the game
Random rnd = new Random();

int userPoints = 0;
int roundCount = 0;
// History array
string[] historyList = new string[6];
string userChoise = "";
string userInput = "";
bool continueGame = true;

// Setup the user menu to repeat while no menu is selected
do
{
    Console.WriteLine("Hello and welcome to the math game ! Use the menu to make a choice : ");
    Console.WriteLine("1: Sums");
    Console.WriteLine("2: Minus");
    Console.WriteLine("3: Equations");
    Console.WriteLine("4: Multiplications");
    Console.WriteLine("5: Show me my history");
    Console.WriteLine("Type Exit to stop the game.");
   
    userChoise = Console.ReadLine();

   if (userChoise.ToLower() == "exit")
    {

        continueGame = false;
    }
    else if(userChoise != null)
    {
        MathgameStart(userChoise);

        if (roundCount == 5)
        {
            Console.WriteLine("This is the end of the game !");
            continueGame = false;

        }
        
    }
   
}
while (continueGame);


void MathgameStart(string gameChoise)
{
    int firstRandom = rnd.Next(0, 100);
    int secondRandom = rnd.Next(0, 100);
    int solution = 0;
    int userAnswer = 0;
   

    /*
     // Try to convert the user input to an int
    if (int.TryParse(userInput, out int value))
    {
        userAnswer = value;

    }
    */

    switch (gameChoise)
    {
        case "1":

            Console.WriteLine($"What is the sum of {firstRandom} + {secondRandom} ?");
            solution = firstRandom + secondRandom;
            int.TryParse(Console.ReadLine(), out userAnswer);
            if (userAnswer == solution)
            {
                Console.WriteLine("Congratulations you've given the right answer !");
                historyList[roundCount] = $"You won the {roundCount} round with {firstRandom} + {secondRandom} = {solution}";
                roundCount++;
                userPoints++;
                Console.WriteLine($"You now have {userPoints} points." + "\n");
            }
            else
            {
                Console.WriteLine("Sorry, that's not the right answer !");
            }

            break;



        case "2":

            bool notNegative = false;

            do
            {
                firstRandom = rnd.Next(0, 100);
                secondRandom = rnd.Next(0, 100);

                solution = firstRandom - secondRandom;
                if (solution > 0)
                {
                    Console.WriteLine($"What is the minus of {firstRandom} and {secondRandom} ?");
                    int.TryParse(Console.ReadLine(), out userAnswer);
                    notNegative = true;
                }
                else
                {
                    notNegative = false;
                }

                if (userAnswer == solution && notNegative)
                {
                    Console.WriteLine("Congratulations ! that's the right answer !");

                    historyList[roundCount] = $"You won the {roundCount} round with {firstRandom} + {secondRandom} = {solution}";
                    roundCount++;
                    userPoints++;
                    Console.WriteLine($"You've got {userPoints} points." + "\n");
                }
                else if (userAnswer != solution && notNegative)
                {

                    Console.WriteLine("Sorry that's not the right answer");
                    break;
                }

            }
            while (notNegative == false);

            break;

        case "3":

            int firstDivide = rnd.Next(1, 101);
            int secondDivider = 0;
            int[] dividers = new int[firstDivide + 1];
            int countDividers = 0;


            if (firstDivide % 2 != 0)
            {
                firstDivide += 1;

            }

            for (int i = 1; i <= firstDivide; i++)
            {
                if (firstDivide % i == 0)
                {
                    dividers[countDividers] = i;
                    countDividers++;

                }
            }
            secondDivider = dividers[rnd.Next(1, countDividers)];
            solution = firstDivide / secondDivider;

            Console.WriteLine($"What is the solution to: {firstDivide} / {secondDivider} ? " + "\n");
            int.TryParse(Console.ReadLine(), out userAnswer);

            if (userAnswer == solution)
            {

                Console.WriteLine("Congratulations ! that's the right answer !");

                historyList[roundCount] = $"You won the {roundCount} round with {firstDivide} / {secondDivider} = {solution}";

                roundCount++;
                userPoints++;
                Console.WriteLine($"You've got {userPoints} points." + "\n");

            }
            else
            {
                Console.WriteLine("Sorry that's not the right answer");
            }

            break;

        case "4":
            {
                firstRandom = rnd.Next(1, 101);
                secondRandom = rnd.Next(1, 101);
                solution = firstRandom * secondRandom;

                Console.WriteLine($"What is the solution to: {firstRandom} X {secondRandom}" + "\n");
                int.TryParse(Console.ReadLine(), out userAnswer);

                if (userAnswer == solution)
                {
                    Console.WriteLine("Congratulations ! that's the right answer !");

                    historyList[roundCount] = $"You won the {roundCount} round with {firstRandom} / {secondRandom} = {solution}";

                    roundCount++;
                    userPoints++;
                    Console.WriteLine($"You've got {userPoints} points." + "\n");

                }
                else
                {
                    Console.WriteLine("Sorry that's not the correct answer.");
                }
                break;
            }

        case "5":
            {
                Console.WriteLine("This is your winning history: \n");

                for (int i = 0; i < historyList.Length; i++)
                {
                    {

                        Console.WriteLine(historyList[i]);
                    }
                    
                }
                break;

            }
    }

}



