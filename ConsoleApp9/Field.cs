using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    public class GameField
    {
        public int Width;
        public int Height;
        public List<Character> Characters { get; private set; }

        public GameField(int width, int height)
        {
            Width = width;
            Height = height;
            Characters = new List<Character>();
        }

        public void AddCharacter(Character character)
        {
            if (Characters.Count < Width * Height)
            {
                Characters.Add(character);
                Console.WriteLine($"{character.Name} added to the field.");
            }
            else
            {
                Console.WriteLine("Field is full!");
            }
        }
        public char[,] initializfield() 
        {
            char[,] pole;
            pole = new char[Width, Height];
            for (int i = 0; i < Width; i++)
            {
                for(int j = 0; j < Height; j++)
                {
                    pole[i, j] = '.';
                }
            }
            
            return pole;
        }
        public void DisplayField(char[,] pole)
        {
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    Console.Write(pole[i, j]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
       
    }
}
