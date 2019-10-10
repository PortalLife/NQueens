using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queen
{
    public class Board
    {
        // Global N, can be changed to solve any n x n

        public static int N = 0;

        // Represent chessboard as a 2D array

        int[,] ChessBoard;

        // Constructs the board and sets all values to 0.

        public Board(int n)
        {

            if  (n == 3 || n == 2)
            {
                Console.WriteLine("Invalid board!");
                return;
            }

            ChessBoard = new int[n, n];

            for (int i = 0; i < N; i++)
            {
                ChessBoard[i, i] = 0;
            }
        }

        // Utlity to print the board

        public void printBoard(Board board)
        {
            for (int i = 0; i < N; i++)
            {
                for (int x = 0; x < N; x++)
                {
                    Console.Write(" " + board.ChessBoard[i, x] + " ");
                }
                Console.WriteLine();
            }
        }

        // Checks if a spot is valid. We only need to check the left-hand side.

        public bool isValid(Board board, int row, int col)
        {
            int x, y;

            // Checks for queens to the left

            for (x = 0; x < col; x++)
            {
                if (board.ChessBoard[row, x] == 1)
                {
                    return false;
                }
            }
               // Checks diagonals

                for (x = row, y = col; x >= 0 && y >= 0; x--, y--)
                {
                    if (board.ChessBoard[x, y] == 1)
                    {
                        return false;
                    }
                }

                for (x = row, y = col; y >= 0 && x < N; x++, y--)
                {
                    if (board.ChessBoard[x, y] == 1)
                    {
                        return false;
                    }
                }
          
            // Check knight postioning to the left, prevent index out of bounds

            if (row >= 2 && col >= 2 && row <= N - 3)
            {

                if (board.ChessBoard[row - 2, col - 1] == 1)
                {
                    return false;
                }

                else if (board.ChessBoard[row + 2, col - 1] == 1)
                {
                    return false;
                }
                else if (board.ChessBoard[row - 1, col - 2] == 1)
                {
                    return false;
                }

                else if (board.ChessBoard[row + 1, col - 2] == 1)
                {
                    return false;
                }
            }
            return true;
        } 

        public bool Helper(Board board, int col)
        {
            // If all queens are placed, return true
            if (col >= N)
            {
                return true;
            }

            // Recursively place queens
      
            for (int i = 0; i < N; i++)
            {
                if (isValid(board, i, col))
                {
                    board.ChessBoard[i, col] = 1;

                    if (Helper(board, col + 1))
                    {
                        return true;
                    }
                    // Backtrack if helper can't find a solution

                    board.ChessBoard[i, col] = 0;
                }
            }
            return false;
        }
    }
    class SuperQueen
    {
        static void Main(string[] args)
        {
            // Create the game board and solve it, print the solution.

            int input = 0;

            Console.WriteLine("Enter a chessboard size to solve. Note that 2x2 and 3v3 cannot be solved.");
            input = Convert.ToInt32(Console.ReadLine());

            Board.N = input;
            Board GameBoard = new Board(input);
            GameBoard.Helper(GameBoard, 0);
            GameBoard.printBoard(GameBoard);
        }
    }
}
