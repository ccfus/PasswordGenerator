using System;
using System.Collections.Generic;
using System.Linq;

namespace PasswordGenerator
{
    class Program
    {
        private static readonly char[] LowerCharPool = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        private static readonly char[] UpperCharPool = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        private static readonly char[] NumberPool = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        private static readonly Dictionary<int, char[]> CharPool = new Dictionary<int, char[]> { {0, LowerCharPool}, {1, UpperCharPool}, {2, NumberPool} };
        
        static void Main(string[] args)
        {
            string pass = GeneratePassword(8);
            Console.Write(pass);
            Console.Read();
        }

        private static string GeneratePassword(int length)
        {
            var password = new char[8];
            int index = 0, lowerCharCount = 0, upperCharCount = 0, numCount = 0;
            var random = new Random();
            while (index < length)
            {                
                var selectedPool = random.Next(0, CharPool.Count);
                switch (selectedPool)
                {
                    case 0:
                        password[index] = CharPool[0][random.Next(0, CharPool[0].Count())];
                        lowerCharCount++;
                        break;
                    case 1:
                        password[index] = CharPool[1][random.Next(0, CharPool[1].Count())];
                        upperCharCount++;
                        break;
                    case 2:
                        password[index] = CharPool[2][random.Next(0, CharPool[2].Count())];
                        numCount++;
                        break;
                }
                index++;
            }
            if (lowerCharCount >= 1 && upperCharCount >= 1 && numCount >= 1)
            {
                return new string(password);
            }
            return GeneratePassword(length);
        }
    }
}
