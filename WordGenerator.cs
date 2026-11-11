using System;
using System.Collections.Generic;
using System.Text;

namespace Labb7_Hangman
{
    internal class WordGenerator
    {
        private List<string> _words = new List<string>
        {
            "apple",
            "banana",
            "bicycle",
            "guitar",
            "homework",
            "subway",
            "trainstation",
        
        };

        public string Randomizer()
        {
            Random random = new Random();
            int index = random.Next(_words.Count);
            return _words[index];
        }
        
    }
}
