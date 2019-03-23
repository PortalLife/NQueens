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
        const int N = 12;

        // Represent chessboard as a 2D array

        int[,] ChessBoard;

        // Constructs the board and sets all values to 0.

        public Board(int n)
        {
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
            return true;
        }

        public bool Helper(Board board, int col)
        {
            // If all queens are placed, return true
            if (col >= N)
            {
                return true;
            }

            for (int i = 0; i < N; i++)
            {

                if (isValid(board, i, col))
                {
                    board.ChessBoard[i, col] = 1;

                    if (Helper(board, col + 1) == true)
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
            Board GameBoard = new Board(12);

            GameBoard.Helper(GameBoard, 0);
            GameBoard.printBoard(GameBoard);
        }
    }
}
