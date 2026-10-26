using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;

namespace Labb7_Hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PlayHangman();
        }
        
        
        
        static void PlayHangman()
        {
            int lives = 6;
            string chosenWord = CreateWord();
            char[] hiddenWord = new char[chosenWord.Length];
            List<char> userGuesses = new List<char>();

            for (int i = 0; i < chosenWord.Length; i++) // Took a while to figure out how to make it write the blank letters so i eventually asked chatgpt for some clues
            {
                hiddenWord[i] = '_';
            }
            Console.WriteLine(hiddenWord);
            while (lives > 0 && new string(hiddenWord) != chosenWord) // Chatgpt also helped with this while loop
            {
                Console.WriteLine("\nWord: " + new string(hiddenWord));
                Console.WriteLine($"Lives: {lives}");

                
                Console.WriteLine("Guess a letter of the word!");
                Console.Write("Your guess: ");
                string userGuess = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(userGuess) || !char.IsLetter(userGuess[0])) // Used Chatgpt to find out how this works
                {
                    Console.WriteLine("ERROR Write a valid letter");
                    continue;
                }
                char guess = char.ToLower(userGuess[0]);

                if (userGuesses.Contains(guess))
                {
                    Console.WriteLine("You already guessed that letter!");
                    continue;
                }
                userGuesses.Add(guess);
                if (chosenWord.Contains(guess))
                {
                    Console.WriteLine($"The letter {guess} is correct!");

                    for (int i = 0; i < chosenWord.Length; i++)
                    {
                        if (chosenWord[i] == guess)
                        {
                            hiddenWord[i] = guess;
                        }
                    }
                }
                if (!chosenWord.Contains(userGuess[0]))
                {
                    Console.WriteLine("Wrong guess");
                    lives--;
                    Draw.DrawHangman(lives);
                }
               
            }
            if (new string(hiddenWord) == chosenWord)
            {
                Console.WriteLine($"You win! The word was {chosenWord}.");
            }
            else
            {
                Console.WriteLine($"You lose! The word was {chosenWord}.");
            }
            
        }
        static string CreateWord()
        {
            var words = new[] { "banana", "train", "airport", "subway", "chocolate", "airport", "apple" };
            var chosenWord = new Random().Next(words.Length); // I used chatgpt to find out how to get a random word
            return words[chosenWord];
        }

    }
}




