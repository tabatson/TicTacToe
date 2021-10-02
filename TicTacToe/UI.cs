﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class UI
    {
        public static void Welcome()
        {
            Console.Clear();
            Console.WriteLine("\nWelcome to Tic-Tac-Toe!");
            Console.WriteLine("\nHere are the rules:");
            Console.WriteLine("Player 1 is X, Player 2 is O.");
            Console.WriteLine("Players will alternate choosing a cell from 1 through 9, displayed on the grid.");
            Console.WriteLine("The chosen cell will be filled with X or O, depending on the player.");
            Console.WriteLine("When a player gets 3 in a row vertically, horizontally, or diagonally, the game is won!");
            Console.WriteLine("If the board is filled before any player wins, the game is a draw.");
            Console.WriteLine("\nPress any key to begin.");
            Console.ReadLine();
        }

        public static int MoveChoice(int player)
        {
            player %= 2; // If this is 0, it's player 1's turn, else player 2.

            Console.Write($"\nPlayer {player + 1}, choose an available cell (1 - 9): ");
            var chosenCell = Console.ReadLine();
            return Convert.ToInt32(chosenCell.Trim()); // Just in case we end up with spaces, remove them before sendinginput as an int.
        }

        public static void NotifyWin(Player p)
        {
            Console.WriteLine($"\n{p.Name} wins!");
        }

        public static void NotifyDraw()
        {
            Console.WriteLine("\nAll cells are filled with no winner. The game is a draw.");
        }

        public static bool PlayAgain()
        {
            char answer = ' ';
            char c = ' ';

            do
            {
                Console.Write("\nWould you like to play again? (Y or N): ");
                while (answer == ' ')
                {
                    try
                    {
                        answer = Convert.ToChar(Console.ReadLine().ToUpper()); // Takes the string input, makes it an uppercase char.
                        c = Check.ValidYesOrNo(answer);
                    }
                    catch (FormatException e)
                    {
                        Console.Write("\n" + e.Message + " Play again (Y or N): ");
                    }
                }
            } while (c != 'Y' && c != 'N');


            if (c == 'Y') // Repeat the game
            {
                return true;
            }
            else // c == 'N' so don't repeat the game.
            {
                Console.WriteLine("\nThanks for playing!");
                return false;
            }  
        }

        public static char GetShape(Player p)
        {
            Console.Clear();
            Console.WriteLine($"\n{p.Name}, choose your symbol:\n");
            foreach(var shape in p.PossibleShapes)
            {
                Console.Write($"{shape} ");
            }
            Console.WriteLine();

            var c = Convert.ToChar(Console.ReadLine());
            return c;
        }

        public static void PrintScore(Player p, Player q)
        {
            var scorecard = $"\nPlayer 1: {p.Score}  |  Player 2: {q.Score}\n";

            foreach (var c in scorecard)
            {
                Console.Write("-");
            }
            
            Console.WriteLine($"\nPlayer 1: {p.Score}  |  Player 2: {q.Score}");
        }
    }
}
