using System;
using System.Collections.Generic;
using System.Text;

namespace Labb7_Hangman
{
    internal class HangmanWord
    {

        private string _secretWord;

        public HangmanWord(string word)
        {
            _secretWord = word;
        }
        public bool GuessLetter(char letter)
        {
            if(_secretWord.Contains(letter))
            {
                
                return true;
            }
            return false;
            
        }

    }
}
