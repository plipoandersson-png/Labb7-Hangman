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
               
                GuessResult result = hangmanWord.GuessLetter(guess);
                
                switch(result)
                {
                    case GuessResult.Correct:
                        // do nothing i guess..
                        break;
                    case GuessResult.Incorrect:
                        lives--;
                        Draw.DrawHangman(lives);
                        break;
                    case GuessResult.AlreadyGuessed:
                        Console.WriteLine("You have already guessed that letter!");
                        break;
                }

                if(lives == 0)
                {
                    Console.WriteLine("Sorry you ran out of lives and died :(");
                    gameRunning = false;
                }
                string hiddenWord = hangmanWord.GetHiddenWord();
                Console.WriteLine($"Word: {hiddenWord}");

                if (gameRunning && !hiddenWord.Contains("_"))
                {
                    Console.WriteLine("Congratulations you won!!!");
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
                    return char.ToLower(guess); // ToLower to make sure its all lowercase since the random words are put to always be lowercase
                }
                else
                {
                    Console.WriteLine("Please enter a single letter A-Z. No numbers or special characters");

                }
            }
        }
    }

    
}
