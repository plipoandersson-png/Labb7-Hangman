using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;

namespace Labb7_Hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WordGenerator generator = new WordGenerator();

            string selectedWord = generator.Randomizer();

            HangmanWord hangmanWord = new HangmanWord(selectedWord);

            Console.WriteLine(selectedWord);
        }
        
    }
}




