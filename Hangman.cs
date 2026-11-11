using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Labb7_Hangman
{
    internal class Hangman
    {
        

        public void PlayHangman()
        {
            int lives = 6;
            bool gameRunning = true;
           
            WordGenerator generator = new WordGenerator();

            string selectedWord = generator.Randomizer();

            HangmanWord hangmanWord = new HangmanWord(selectedWord);

            while (gameRunning)
            {
                char guess = HangmanMenu();
                bool correctGuess = hangmanWord.GuessLetter(guess);
                if (correctGuess)
                {
                    // do something
                }
                else
                {
                    lives--;
                }
                if(lives == 0)
                {
                    gameRunning = false;
                }
            }
        }

        public char HangmanMenu()
        {
            while (true)
            {
                Console.WriteLine("Welcome to the hangman game!");
                Console.WriteLine("Try guessing a letter!");
                Console.Write("Your guess: ");
                string userGuess = Console.ReadLine();

                
                if (char.TryParse(userGuess, out char guess) && char.IsLetter(guess))
                {
                    return guess;
                }
                else
                {
                    Console.WriteLine("Please enter a single letter A-Z. No numbers or special characters");

                }
            }
        }
    }

    
}
