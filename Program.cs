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

            for (int i = 0; i < chosenWord.Length; i++)
            {
                hiddenWord[i] = '_';
            }
            Console.WriteLine(hiddenWord);
            while (lives > 0 && new string(hiddenWord) != chosenWord) // Chatgpt also helped with this while loop
            {
                Console.WriteLine("\nWord: " + new string(hiddenWord));
                Console.WriteLine($"Lives: {lives}");

                List<char> userGuesses = new List<char>();
                Console.WriteLine("Guess a letter of the word!");
                Console.Write("Your guess: ");
                string userGuess = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(userGuess)) // Used Chatgpt to find out how this works
                {
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
                    DrawHangman(lives);
                }
                if (new string(hiddenWord) == chosenWord)
                {
                    Console.WriteLine($"You win! The word was {chosenWord}.");
                }
                else
                {
                    Console.WriteLine($"You lose! The word was {chosenWord}.");
                }
                for (int i = 0; i < chosenWord.Length; i++)
                {
                    if (chosenWord[i] == guess)
                    {
                        hiddenWord[i] = guess;
                    }
                }
            }
        }
        static string CreateWord()
        {
            var words = new[] { "banana", "train", "airport", "subway", "chocolate", "airport", "apple" };
            var chosenWord = new Random().Next(words.Length); // I used chatgpt to find out how to get a random word
            return words[chosenWord];
        }
        static void DrawHangman(int lives) // I used chatgpt to write this method for drawing the hangman
        {
            Console.WriteLine("  +---+");
            Console.WriteLine("  |   |");

            // Head
            Console.WriteLine(lives <= 5 ? "  |   O" : "  |");

            // Torso and arms
            if (lives <= 4)
            {
                string leftArm = lives <= 3 ? "/" : " ";
                string rightArm = lives <= 2 ? "\\" : " ";

                Console.WriteLine($"  |  {leftArm}|{rightArm}");
            }
            else
            {
                Console.WriteLine("  |");
            }

            // Legs
            if (lives <= 1)
            {
                string leftLeg = lives <= 1 ? "/" : " ";
                string rightLeg = lives <= 0 ? "\\" : " ";

                Console.WriteLine($"  |  {leftLeg} {rightLeg}");
            }
            else
            {
                Console.WriteLine("  |");
            }

            Console.WriteLine("  |");
            Console.WriteLine("=========");
        }
    }
}




