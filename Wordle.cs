using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

namespace Pet_Game
{
    internal class Primary
    {
        public static void forec(string colour)
        {
            Enum.TryParse<ConsoleColor>(colour, true, out ConsoleColor parsedColor);
            Console.ForegroundColor = parsedColor;
        }// changes text foreground colour to passed parameter.

        public static string chooseWord(string sourceb)
        {
            string filepath = sourceb;
            string[] words = System.IO.File.ReadAllText(filepath).Split();
            Random random = new Random();
            int wordIndex = random.Next(0, words.Length);
            string chosenWord = words[wordIndex];
            return chosenWord;
        }

        public static string[] colours = new string[30];

        public static char[] wordleChars =
        {
            ' ', ' ', ' ', ' ', ' ',
            ' ', ' ', ' ', ' ', ' ',
            ' ', ' ', ' ', ' ', ' ',
            ' ', ' ', ' ', ' ', ' ',
            ' ', ' ', ' ', ' ', ' ',
            ' ', ' ', ' ', ' ', ' ',
        };

        public static void cw(char a, string c)
        {
            forec(c);
            Console.Write(a); Console.ResetColor(); Console.Write(" ║ ");
        }

        public static void wordleTable(char[] table, string[] colour)
        {
            int index = 0;
            Console.WriteLine("╔═══╦═══╦═══╦═══╦═══╗");

            for (int row = 0; row < 6; row++)
            {
                Console.Write("║ ");
                for (int col = 0; col < 5; col++)
                {
                    cw(table[index], colour[index]);
                    index++;
                }
                if (row < 5)
                {
                    Console.WriteLine("\n╠═══╬═══╬═══╬═══╬═══╣");
                }
                else
                {
                    Console.WriteLine("\n╚═══╩═══╩═══╩═══╩═══╝");
                }
            }
        }

        public static void wordle(string sourcea)
        {
            string wordGuess = "";
            string randomWord = chooseWord(sourcea);
            Console.WriteLine(randomWord);
            Console.ReadLine();
            bool wordGuessCorrect = false;
            while (wordGuessCorrect == false)
            {
                for (int row = 0; row < 30; row += 5)
                {
                    wordleTable(wordleChars, colours);
                    Console.Write("\nEnter guess: ");
                    wordGuess = Console.ReadLine().ToLower();
                    Console.Clear();
                    if (wordGuess.Length == 5)
                    {
                        if (wordGuess == randomWord)
                        {
                            for (int i = 0; i < 5; i++)
                            {
                                wordleChars[i + row] = randomWord[i];
                                colours[i + row] = "green";
                            }
                            wordleTable(wordleChars, colours);
                            Console.WriteLine("You guessed correctly. Well Done.");
                            Console.ReadLine();
                            row = 40;
                            wordGuessCorrect = true;
                            Console.Clear();
                        }
                        else
                        {
                            for (int i = 0; i < randomWord.Length; i++)
                            {
                                if (randomWord[i] == wordGuess[i])
                                {
                                    wordleChars[i + row] = wordGuess[i];
                                    colours[i + row] = "green";
                                }
                                else if (wordGuess[i] == randomWord[0] || wordGuess[i] == randomWord[1] || wordGuess[i] == randomWord[2] || wordGuess[i] == randomWord[3] || wordGuess[i] == randomWord[4])
                                {
                                    wordleChars[i + row] = wordGuess[i];
                                    colours[i + row] = "yellow";
                                }
                                else
                                {
                                    wordleChars[i + row] = wordGuess[i];
                                    colours[i + row] = "red";
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Input has to be 5 letters long.");
                        row -= 5;
                    }
                }
                if (wordGuessCorrect == false && wordGuess != randomWord)
                {
                    Console.WriteLine($"Game Over. The word was: {randomWord}");
                }
            }
        }

        static void Main(string[] args)
        {
            while (true)
            {
                wordle("FILE PATH GOES HERE"); // <--------------  CHANGE FILE PATH HERE ---------------
            }

        }
    }
}
