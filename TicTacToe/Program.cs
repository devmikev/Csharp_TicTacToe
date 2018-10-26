using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Game();
        }

        public static void DisplayBoard(string[] updatedValues)
        {
            Console.WriteLine("        |   |   ");
            Console.WriteLine("      {0} | {1} | {2}", updatedValues[0], updatedValues[1], updatedValues[2]);
            Console.WriteLine("     ___|___|___");
            Console.WriteLine("        |   |   ");
            Console.WriteLine("      {0} | {1} | {2}", updatedValues[3], updatedValues[4], updatedValues[5]);
            Console.WriteLine("     ___|___|___");
            Console.WriteLine("        |   |   ");
            Console.WriteLine("      {0} | {1} | {2}", updatedValues[6], updatedValues[7], updatedValues[8]);
            Console.WriteLine("        |   |   ");
        }

        public static string[] GetField(string[] fields, bool player)
        {
            bool finished = true;
            do
            {
                string playerTurn;
                playerTurn = player ? "1" : "2";
                Console.Write("Player {0}, Choose a field 1 - 9: ", playerTurn);
                var input = Console.ReadLine();
                string[] checkInput = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
                if (checkInput.Contains(input) && fields.Contains(input))
                {
                    var index = Array.IndexOf(fields, input);
                    string turn;
                    turn = player ? "X" : "O";
                    fields[index] = turn;
                    finished = !finished;
                }

            } while (finished);
            return fields;
        }

        public static void Game()
        {
            string[] board = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            DisplayBoard(board);
            bool player = true;

            for (var i = 0; i < 9; i++)
            {
                var newBoard = GetField(board, player);
                Console.Clear();
                DisplayBoard(newBoard);
                var gameFinished = CheckResults(newBoard, player);
                if (gameFinished)
                    break;
                player = !player;
            }
        }

        public static bool CheckResults(string[] result, bool player)
        {
            string currentPlayer;
            currentPlayer = player ? "X" : "O";

            int x = 0;
            int y = 1;
            int z = 2;
            for (var i = 0; i < 3; i++)
            {
                if (result[x] == currentPlayer && result[y] == currentPlayer && result[z] == currentPlayer)
                {
                    Console.WriteLine("Player {0} is the winner!", currentPlayer);
                    return true;
                }

                x += 3;
                y += 3;
                z += 3;

            }

            x = 0;
            y = 3;
            z = 6;
            for (var i = 0; i < 3; i++)
            {
                if (result[x] == currentPlayer && result[y] == currentPlayer && result[z] == currentPlayer)
                {
                    Console.WriteLine("Player {0} is the winner!", currentPlayer);
                    return true;
                }

                x += 1;
                y += 1;
                z += 1;

            }

            x = 0;
            y = 4;
            z = 8;
            for (var i = 0; i < 2; i++)
            {
                if (result[x] == currentPlayer && result[y] == currentPlayer && result[z] == currentPlayer)
                {
                    Console.WriteLine("Player {0} is the winner!", currentPlayer);
                    return true;
                }

                x += 2;
                y -= 2;
                z -= 2;

            }
            return false;
        }
    }
}
