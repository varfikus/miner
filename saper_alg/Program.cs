using CommonTypes;
using System;


namespace saper_alg
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WindowHeight = 18;
            Console.WindowWidth = 30;
            Console.SetWindowSize(30, 18);
            Console.SetBufferSize(30, 18);
            var numberOfMines = 1;

            for (var i = 0; i < 1; i++)
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

            var gameBoard = new Board(boardSize, numberOfMines);

            var gameOver = false;

            while (!gameOver)
            {
                DrawBoard(gameBoard, false);

                Console.Write("Введите координаты ячейки: ");
                var input = Console.ReadLine().ToUpper();

                var row = input[0] - 'A';
                var col = int.Parse(input.Substring(1)) - 1;

                var cell = gameBoard.OpenCell(row, col);

                if (cell.Type == CellType.Bomb)
                {
                    Console.WriteLine("Вы проиграли!");
                    gameOver = true;
                    Console.Clear();
                }
                else
                {
                    Console.Clear();
                    if (gameBoard.RemainingCells == 0)
                    {
                        Console.WriteLine("Поздравляю, вы выиграли!");
                        gameOver = true;
                    }
                }
            }

            DrawBoard(gameBoard, true);
            Console.WriteLine("Игра окончена. Нажмите любую клавишу для выхода.");
            Console.ReadKey();
        }

        private static void DrawBoard(Board board, bool showAllBoard)
        {
            var size = board.BoardSize;

            Console.WriteLine("  " + string.Join(" ", new string[size]));
            Console.Write("  ");
            for (var col = 0; col < size; col++)
            {
                Console.Write($"{col + 1} ");
            }
            Console.WriteLine("\n" + "  " + new string('_', size * 2));

            for (var row = 0; row < size; row++)
            {
                Console.Write((char)('A' + row) + "|");

                for (var col = 0; col < size; col++)
                {
                    var cell = board.OpenCell(row, col);

                    var textForCell = "-";

                    if (showAllBoard) textForCell = cell.Type == CellType.Bomb ? "*" : ".";
                    else if (cell.IsOpen) textForCell = cell.NearBombCount?.ToString() ?? "0";

                    Console.Write($"{textForCell} ");
                }

                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
