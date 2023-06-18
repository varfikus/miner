using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.Text;
using System.Windows.Forms;
using CommonTypes;

namespace WindowsApp
{
    public partial class miner_app : Form
    {
        private Board _gameBoard;
        public miner_app()
        {
            InitializeComponent();
        }

        private void admitButton_Click(object sender, EventArgs e)
        {
            int numberOfMinesInput;
            int boardSizeInput;
            if (!int.TryParse(this.boardSizeInput.Text, out boardSizeInput))
            {
                MessageBox.Show("Недопустимое значение", "Ошибка", MessageBoxButtons.OK);
                return;
            }
            else if (int.Parse(this.boardSizeInput.Text) > 15)
            {
                MessageBox.Show("Недопустимое значение", "Ошибка", MessageBoxButtons.OK);
                return;
            }
            if (!int.TryParse(NumberOfMinesInput.Text, out numberOfMinesInput))
            {
                MessageBox.Show("Недопустимое значение", "Ошибка", MessageBoxButtons.OK);
                return;
            }
            else if (int.Parse(NumberOfMinesInput.Text) >= boardSizeInput * boardSizeInput)
            {
                MessageBox.Show("Недопустимое значение", "Ошибка", MessageBoxButtons.OK);
                return;
            }

            Size = new Size(558, 620);
            CenterToScreen();

            _gameBoard = new Board(boardSizeInput, numberOfMinesInput);
            label1.Visible = false;
            label2.Visible = false;
            NumberOfMinesInput.Visible = false;
            this.boardSizeInput.Visible = false;
            admitButton.Visible = false;
            exitButton.Visible = false;

            int dynamicSize = 550 / boardSizeInput;

            for (int i = 0; i < boardSizeInput; i++)
            {
                for (int j = 0; j < boardSizeInput; j++)
                {
                    Button buttonDynamic = new Button
                    {
                        Text = ".",
                        Visible = true,
                        Size = new Size(dynamicSize, dynamicSize),
                        Name = $"{j}_{i}",
                        BackgroundImage = Properties.Resources.closeCell,
                        BackgroundImageLayout = ImageLayout.Stretch,
                        Padding = new Padding(0),
                        Margin = new Padding(0),
                        FlatStyle = FlatStyle.Flat,
                        FlatAppearance = { BorderSize = 1, BorderColor = Color.GreenYellow}
                    };
                    buttonDynamic.MouseDown += ButtonDynamic_Click;
                    buttonDynamic.Location = new Point( 1 + dynamicSize * j, 40 + dynamicSize * i);

                    this.Controls.Add(buttonDynamic);
                }
            }
        }

        private void ButtonDynamic_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            string[] subs = btn.Name.Split('_');
            var row = subs[0];
            var col = subs[1];
            var cell = _gameBoard.GetCell(int.Parse(row), int.Parse(col));
            if (((MouseEventArgs)e).Button == MouseButtons.Left)
            {
                if (cell.IsOpen) return;
                _gameBoard.OpenCell(int.Parse(row), int.Parse(col));

                btn.BackgroundImage = Properties.Resources.openCell;

                if (cell.Type == CellType.Bomb)
                {
                    btn.Text = "*";
                    btn.BackgroundImage = Properties.Resources.closeCell;
                    btn.Image = Properties.Resources.mine40;
                    var result = MessageBox.Show("Вы проиграли!", "Игра окончена", MessageBoxButtons.OK);

                    if (result == DialogResult.OK)
                    {
                        Close();
                    }
                }
                else
                {
                    if (cell.NearBombCount > 0)
                    {
                        btn.Text = $"{cell.NearBombCount}";
                        btn.ForeColor = Color.White;
                        btn.Font = new Font("Times New Roman", 16, FontStyle.Bold);
                    }
                    if (_gameBoard.RemainingCells == 0)
                    {
                        var result = MessageBox.Show("Поздравляю, вы выиграли!", "Игра окончена", MessageBoxButtons.OK);
                        if (result == DialogResult.OK)
                        {
                            Close();
                        }
                    }
                    label4.Visible = true;
                    label3.Text = $"{_gameBoard.RemainingCells}";
                }
            }
            else if (((MouseEventArgs)e).Button == MouseButtons.Right)
            {
                if (cell.IsOpen) return;
                _gameBoard.flaged(int.Parse(row), int.Parse(col));
                btn.BackgroundImage = cell.IsFlag == true
                    ? Properties.Resources.redFlag 
                    : Properties.Resources.closeCell;
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
