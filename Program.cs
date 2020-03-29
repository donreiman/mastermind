using System;
using System.Collections.Generic;
using mastermind.libraries;

namespace mastermind
{
    class Program
    {
        static void Main(string[] args)
        {
            Numeral actual = new Numeral();
            var guessCount = 1;
            var correctGuess = false;

            while (guessCount <= 10 && !correctGuess)
            {
                Console.Write($"Guess #{guessCount}. Enter a 4 digit string and press enter: ");
                var guessString = Console.ReadLine();
                if (GuessIsValid(guessString))
                {
                    Numeral guess = new Numeral(guessString);
                    string numeralComparison = CompareGuessNumeralToActualNumeral(guess.FourDigitString, actual.FourDigitString);
                    if (numeralComparison == "++++")
                    {
                        correctGuess = true;
                    }
                    else
                    {
                        Console.WriteLine(numeralComparison);
                    }
                    guessCount++;
                }
                else
                {
                    Console.WriteLine($"Invalid guess - must be a 4 digit string with each digit between 1 and 6");
                }
            }
            Console.WriteLine("Actual number: " + actual.FourDigitString);
            if (correctGuess)
            {
                Console.WriteLine("You win!");
            }
            else
            {
                Console.WriteLine("Sorry, you lose!");
            }
        }

        static bool GuessIsValid(string guess)
        {
            if (guess == null || guess.Length != 4)
            {
                return false;
            }
            bool containsInvalidCharacter = false;
            foreach (char c in guess)
            {
                int digit;
                if (Int32.TryParse(c.ToString(), out digit))
                {
                    if (digit < 1 || digit > 6)
                    {
                        containsInvalidCharacter = true;
                    }
                }
                else
                {
                    containsInvalidCharacter = true;
                }
            }
            return !containsInvalidCharacter;
        }

        static string CompareGuessNumeralToActualNumeral(string guessString, string actualString)
        {
            string returnString = string.Empty;
            var guessIndexMatched = new bool[4];
            var actualIndexMatched = new bool[4];

            for (var i = 0; i < 4; i++)
            {
                if (guessString[i] == actualString[i] && !guessIndexMatched[i] && !actualIndexMatched[i])
                {
                    returnString += "+";
                    guessIndexMatched[i] = true;
                    actualIndexMatched[i] = true;
                }
            }

            for (var i = 0; i < 4; i++)
            {
                for (var j = 0; j < 4; j++)
                {
                    if (guessString[i] == actualString[j] && !guessIndexMatched[i] && !actualIndexMatched[j])
                    {
                        returnString += "-";
                        guessIndexMatched[i] = true;
                        actualIndexMatched[j] = true;
                    }
                }
            }

            return returnString;
        }
    }
}
