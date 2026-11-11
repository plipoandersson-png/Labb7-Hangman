using System;
using System.Collections.Generic;
using System.Text;

namespace Labb7_Hangman
{
    internal class WordGenerator // this class generates the words for the game
    {
        private List<string> _words = new List<string> // list of the words available in the game
        {
            "apple",
            "banana",
            "bicycle",
            "guitar",
            "homework",
            "subway",
            "trainstation",
        
        };

        public string Randomizer() // this method randomly picks one of the words in the _words list
        {
            Random random = new Random();
            int index = random.Next(_words.Count);
            return _words[index];
        }
        
    }
}
