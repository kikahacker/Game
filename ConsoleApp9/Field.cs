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
        public char[,] initializfield(Character character1, Character character2) 
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
            
            checkValid(character1);
            checkValid(character2);
            pole[character1.PosY, character1.PosX] = '1';
            pole[character2.PosY, character2.PosX] = '2';
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
        public void checkValid(Character character1)
        {
            if (character1.PosX < 0)
            {
                character1.PosX = 0;
            }
            if (character1.PosX > Width-1)
            {
                character1.PosX = Width-1;
            }
            if (character1.PosY < 0)
            {
                character1.PosY = 0;
            }
            if (character1.PosY > Height-1)
            {
                character1.PosY = Height-1;
            }
        }
    }
}
