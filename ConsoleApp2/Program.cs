using System;
using System.Data;
using System.Numerics;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static Random rnd = new Random();
        static string[,] TTTBoard = initializeBoard();
        static List<string> Pool = new List<string>();
        static List<string> moves = new List<string>();
        static string Player = "Human";
        static void Main(string[] args)
        {

            string Player = firstMove();
            display(TTTBoard);
            while (true)
            {
                List<string> playermoves = playerMove(Player, TTTBoard);
                changeBoard(TTTBoard, playermoves[0], playermoves[1], Player);
                display(TTTBoard);
                Player = changePlayerTurn(Player);
            }
        }

        static bool gameLoop()
        {
            return false;
        }

        static string firstMove()
        {
            if (rnd.Next(1, 100) % 2 == 0)
                Player = "Human" ;
            else
                Player = "Computer";

            return Player;
        }

        static List<string> playerMove (string Player, string[,] board)
        {
            string xcoor = "";
            string ycoor = "";

            Pool.Clear();
            moves.Clear();

            if ( Player == "Human" ) 
            {
                Console.WriteLine("Enter X coordinate of your move");
                xcoor = Console.ReadLine();
                Console.WriteLine("Enter Y coordinate of your move");
                ycoor = Console.ReadLine();
            }

            if ( Player == "Computer")
            {
                // lists all coordinates and puts it in a pool
                for (int row = 0; row < board.GetLength(0); row++)
                    for (int column = 0; column < board.GetLength(1); column++)
                        if (board[row, column] == null)
                        {
                            Pool.Add(row.ToString() + column.ToString());
                            //Console.WriteLine(row.ToString() + column.ToString());
                        }

                // gets random coordinate from pool
                int computerMove = rnd.Next(0,Pool.Count);
                xcoor = Pool[computerMove][0].ToString();
                ycoor = Pool[computerMove][1].ToString();

                //Console.WriteLine("xcoor" + Pool[computerMove][0]);
                //Console.WriteLine("ycoor" + Pool[computerMove][1]);


            }

            return new List<string> { xcoor, ycoor };
        }

        static string[,] initializeBoard()
        { 
            string[,] Board = new string[3, 3];
            return Board;
        }

        static string[,] clearBoard(string[,] Board)
        {
            return new string[3, 3];
        }


        static string changePlayerTurn(string Player)
        {
            if (Player == "Computer")
                return "Human";
            else
                return "Computer";
        }

        static void ValidateMove()
        {

        }

        static string[,] changeBoard(string[,] Board, string xcoor, string ycoor, string player)
        {
            bool valid = false;
            while (!valid)
            {
                if (Board[int.Parse(xcoor), int.Parse(ycoor)] != null)
                    valid = false;
                else
                {
                    if (player == "Human")
                        Board[int.Parse(xcoor), int.Parse(ycoor)] = "X";
                    else
                        Board[int.Parse(xcoor), int.Parse(ycoor)] = "O";
                    valid = true;
                }

                Console.Write("Invalid move");
            }
            return Board;
        }

        static void display(string[,] board)
        {
            //Console.Clear();
            for (int row = 0; row < board.GetLength(0); row++)
            {
                Console.WriteLine("\n -------------------------------------------------");
                for (int column = 0; column < board.GetLength(1); column++)
                {
                    Console.Write("| \t" + board[column, row] +  "\t |");
                }
                Console.WriteLine("\n -------------------------------------------------");
            }

        }
    }
}