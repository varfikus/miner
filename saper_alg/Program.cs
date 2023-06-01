using System;
using System.Collections.Generic;
using System.Text;


namespace saper_alg
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowHeight = 18;
            Console.WindowWidth = 30;
            Console.SetWindowSize(30, 18);
            Console.SetBufferSize(30, 18);
            int numberOfMines = 1;
            for (int i = 0; i < 1; i++)
            {
                m1: Console.Write("Введите количество мин: ");
                numberOfMines = int.Parse(Console.ReadLine());
                if (numberOfMines < 1 || numberOfMines > 100)
                {
                    Console.WriteLine("Неверное количество мин, введите снова...");
                    goto m1;
                }
            }
            const int boardSize = 10;
            

            char[,] gameBoard = CreateGameBoard(boardSize);
            char[,] mineBoard = PlaceMines(gameBoard, numberOfMines);
            char[,] visibleBoard = CreateVisibleBoard(boardSize);

            bool gameOver = false;
            int remainingCells = boardSize * boardSize - numberOfMines;

            while (!gameOver)
            {
                DrawBoard(visibleBoard);

                Console.Write("Введите координаты ячейки: ");
                string input = Console.ReadLine().ToUpper();

                int row = input[0] - 'A';
                int col = int.Parse(input.Substring(1)) - 1;

                if (mineBoard[row, col] == '*')
                {
                    Console.WriteLine("Вы проиграли!");
                    gameOver = true;
                    Console.Clear();
                }
                else
                {
                    visibleBoard[row, col] = CountAdjacentMines(mineBoard, row, col);
                    remainingCells--;
                    Console.Clear();
                    if (remainingCells == 0)
                    {
                        Console.WriteLine("Поздравляю, вы выиграли!");
                        gameOver = true;
                    }
                }
            }

            DrawBoard(mineBoard);
            Console.WriteLine("Игра окончена. Нажмите любую клавишу для выхода.");
            Console.ReadKey();
        }

        static char[,] CreateGameBoard(int size)
        {
            char[,] board = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    board[row, col] = '.';
                }
            }

            return board;
        }

        static char[,] CreateVisibleBoard(int size)
        {
            char[,] board = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    board[row, col] = '-';
                }
            }

            return board;
        }

        static char[,] PlaceMines(char[,] board, int numberOfMines)
        {
            int size = board.GetLength(0);
            char[,] mineBoard = (char[,])board.Clone();
            Random random = new Random();

            int minesPlaced = 0;
            while (minesPlaced < numberOfMines)
            {
                int row = random.Next(size);
                int col = random.Next(size);

                if (mineBoard[row, col] != '*')
                {
                    mineBoard[row, col] = '*';
                    minesPlaced++;
                }
            }

            return mineBoard;
        }

        static char CountAdjacentMines(char[,] mineBoard, int row, int col)
        {
            int size = mineBoard.GetLength(0);
            int count = 0;

            for (int i = row - 1; i <= row + 1; i++)
            {
                for (int j = col - 1; j <= col + 1; j++)
                {
                    if (i >= 0 && i < size && j >= 0 && j < size && mineBoard[i, j] == '*')
                    {
                        count++;
                    }
                }
            }

            return count.ToString()[0];
        }

        static void DrawBoard(char[,] board)
        {
            int size = board.GetLength(0);

            Console.WriteLine("  " + string.Join(" ", new string[size]));
            Console.Write("  ");
            for (int col = 0; col < size; col++)
            {
                Console.Write($"{col + 1} ");
            }
            Console.WriteLine("\n" + "  " + new string('_', size * 2));

            for (int row = 0; row < size; row++)
            {
                Console.Write((char)('A' + row) + "|");

                for (int col = 0; col < size; col++)
                {
                    Console.Write(board[row, col] + " ");
                }

                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
