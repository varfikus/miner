using System;
using System.Data;

namespace CommonTypes
{
    public class Board
    {
        private readonly BoardCell[,] _gameBoard;
        private int _remainingCells;

        public int BoardSize => _gameBoard.GetLength(0);
        public int RemainingCells => _remainingCells;

        public Board(int size, int numberOfMines)
        {
            _gameBoard = CreateGameBoard(size, numberOfMines);
            _remainingCells = size * 2 - numberOfMines;
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

        public BoardCell OpenCell(int row, int col)
        {
            _gameBoard[row, col].NearBombCount = CountAdjacentMines(row, col);
            _gameBoard[row, col].IsOpen = true;
            if (_gameBoard[row, col].Type != CellType.Bomb)
            {
                _remainingCells--;
            }

            return _gameBoard[row, col];
        }

        private int CountAdjacentMines(int row, int col)
        {
            var size = _gameBoard.GetLength(0);
            var count = 0;

            for (var i = row - 1; i <= row + 1; i++)
            {
                for (var j = col - 1; j <= col + 1; j++)
                {
                    if (i >= 0 && i < size && j >= 0 && j < size && _gameBoard[i, j].Type == CellType.Bomb)
                    {
                        count++;
                    }
                }
            }

            return count;
        }
    }
}
