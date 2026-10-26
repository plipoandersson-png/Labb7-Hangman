using System;
using System.Collections.Generic;
using System.Text;

namespace Labb7_Hangman
{
    internal class Draw
    {
        public static void DrawHangman(int lives) // I used chatgpt to write this method for drawing the hangman
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
