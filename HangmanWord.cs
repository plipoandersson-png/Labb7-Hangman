using System;
using System.Collections.Generic;
using System.Text;

namespace Labb7_Hangman
{
    enum GuessResult
    {
        Correct,
        Incorrect,
        AlreadyGuessed,
    }
    internal class HangmanWord
    {

        private string _secretWord;
        private List<char> _guessedLetters = new List<char>(); // a list to store all the letters the user has already guessed

        public HangmanWord(string word)
        {
            _secretWord = word.ToLower(); // just to make sure its always lowercase
        }
        public string GetHiddenWord()
        {
            string result = ""; // the word that shows up on the screen with blanks for none guessed letters
            for (int i = 0; i < _secretWord.Length; i++)
            {
                if (_guessedLetters.Contains(_secretWord[i]))
                {
                    result += _secretWord[i];
                }
                else
                {
                    result += "_"; 
                }
            }
            return result;
        }
        public GuessResult GuessLetter(char letter) // Checks if the word contains the users guessed letter or if its already been guessed and uses an enum with three outcomes. Correct, Incorrect and AlreadyGuessed.
        {                                          // at first i used a bool but this needed three outcomes so chatgpt suggested i make an enum and use that instead
            if (_guessedLetters.Contains(letter))
            {
                return GuessResult.AlreadyGuessed;
            }
            _guessedLetters.Add(letter);

            if (_secretWord.Contains(letter))
            {
                
                return GuessResult.Correct;
            }
            return GuessResult.Incorrect;
            
        }

    }
}
