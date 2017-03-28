using System;
using static System.Console;

namespace RockPaperScissors
{
    class RockPaperScissors
    {
        private Random rng;
        private int wins;
        private int losses;
        private int ties;

        public RockPaperScissors()
        {
            rng = new Random();
        }

        public void Play()
        {
            string userChoice = PromptUser();     

            while (userChoice != "Q")
            {
                string computerChoice = GetComputerChoice();
                DetermineWinner(userChoice, computerChoice);
                PrintScore();
                Clear();
                userChoice = PromptUser();
            }
        }

        private void PrintScore()
        {
            WriteLine();
            WriteLine("Wins: {0}", wins);
            WriteLine("Losses: {0}", losses);
            WriteLine("Ties: {0}", ties);
            WriteLine();
            WriteLine("Press enter to continue...");
            ReadLine();
        }

        private void DetermineWinner(string userChoice, string computerChoice)
        {
            if (userChoice == computerChoice)
            {
                ties++;
                WriteLine("You both picked {0}, you tied!", ConvertChoiceToWord(userChoice));
            } 
            else if ((userChoice == "R" && computerChoice == "S") || (userChoice == "S" && computerChoice == "P") || (userChoice == "P" && computerChoice == "R"))
            {
                wins++;
                WriteLine("You picked {0} and the computer picked {1}, you win!", ConvertChoiceToWord(userChoice), ConvertChoiceToWord(computerChoice));
            }
            else
            {
                losses++;
                WriteLine("You picked {0} and the computer picked {1}, you lose!", ConvertChoiceToWord(userChoice), ConvertChoiceToWord(computerChoice));
            }
        }

        private string ConvertChoiceToWord(string choice)
        {
            if (choice == "R")
                return "Rock";
            else if (choice == "P")
                return "Paper";
            else
                return "Scissors";
        }

        private string GetComputerChoice()
        {
            int choice = rng.Next(1, 4);

            if (choice == 1)
                return "R";
            if (choice == 2)
                return "P";
            else
                return "S";
        }

        private string PromptUser()
        {
            while (true)        //makes it loop until it gets a valid response-shortcut/trick bc it is always true.
            {
                Write("Enter your choice (R)ock, (P)aper, (S)cissors, or (Q)uit: ");
                string choice = ReadLine().ToUpper();

                if (choice == "R" || choice == "P" || choice == "S" || choice == "Q")
                    return choice;
                //this will escape from the forever while true loop once a valid choice has been entered
                else
                    WriteLine("That was not a valid choice!");
            }
        }

    }

}
