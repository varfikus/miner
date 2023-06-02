using System;

namespace CommonTypes
{
    public class Board
    {
        private static BoardCell[,] InitBoard(int size)
        {
            var board = new BoardCell[size, size];

            for (var row = 0; row < size; row++)
            {
                for (var col = 0; col < size; col++)
                {
                    board[row, col] = new BoardCell
                    {
                        Type = CellType.Void
                    };
                }
            }

            return board;
        }

        public static BoardCell[,] CreateGameBoard(int size, int numberOfMines)
        {
            var board = InitBoard(size);
            var mineBoard = (BoardCell[,])board.Clone();
            var random = new Random();

            var minesPlaced = 0;
            while (minesPlaced < numberOfMines)
            {
                var row = random.Next(size);
                var col = random.Next(size);

                if (mineBoard[row, col].Type != CellType.Bomb)
                {
                    mineBoard[row, col].Type = CellType.Bomb;
                    minesPlaced++;
                }
            }

            return mineBoard;
        }

        public static int CountAdjacentMines(BoardCell[,] mineBoard, int row, int col)
        {
            var size = mineBoard.GetLength(0);
            var count = 0;

            for (var i = row - 1; i <= row + 1; i++)
            {
                for (var j = col - 1; j <= col + 1; j++)
                {
                    if (i >= 0 && i < size && j >= 0 && j < size && mineBoard[i, j].Type == CellType.Bomb)
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        public static BoardCell[,] CreateVisibleBoard(int size)
        {
            var board = new BoardCell[size, size];

            for (var row = 0; row < size; row++)
            {
                for (var col = 0; col < size; col++)
                {
                    board[row, col] = new BoardCell();
                }
            }

            return board;
        }
    }
}
