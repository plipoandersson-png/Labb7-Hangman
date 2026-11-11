using System;
using System.Collections.Generic;
using System.Text;

namespace Labb7_Hangman
{
    internal class HangmanWord
    {

        private string _secretWord;
        private List<char> _guessedLetters = new List<char>();

        public HangmanWord(string word)
        {
            _secretWord = word;
        }
        public void GetHiddenWord()
        {

        }
        public bool GuessLetter(char letter) // Checks if the word contains the users guessed letter and if it does it adds it to the guessedletters list, if it doesnt it returns false
        {
            if (_guessedLetters.Contains(letter))
            {
                return false;
            }
          
            if (_secretWord.Contains(letter))
            {
                _guessedLetters.Add(letter);
                return true;
            }
            return false;
            
        }

    }
}
