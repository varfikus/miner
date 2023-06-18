namespace WindowsApp
{
    partial class miner_app
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(miner_app));
            this.NumberOfMinesInput = new System.Windows.Forms.TextBox();
            this.boardSizeInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Button();
            this.admitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NumberOfMinesInput
            // 
            this.NumberOfMinesInput.Location = new System.Drawing.Point(480, 15);
            this.NumberOfMinesInput.MaxLength = 3;
            this.NumberOfMinesInput.Name = "NumberOfMinesInput";
            this.NumberOfMinesInput.Size = new System.Drawing.Size(60, 20);
            this.NumberOfMinesInput.TabIndex = 1;
            // 
            // boardSizeInput
            // 
            this.boardSizeInput.Location = new System.Drawing.Point(178, 15);
            this.boardSizeInput.MaxLength = 3;
            this.boardSizeInput.Name = "boardSizeInput";
            this.boardSizeInput.Size = new System.Drawing.Size(60, 20);
            this.boardSizeInput.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(8, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Введите размер поля:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(294, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "Введите количество мин:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(316, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 21);
            this.label3.TabIndex = 5;
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(100, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(216, 21);
            this.label4.TabIndex = 6;
            this.label4.Text = "Осталось пустых клеток: ";
            this.label4.Visible = false;
            // 
            // exitButton
            // 
            this.exitButton.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exitButton.Location = new System.Drawing.Point(12, 50);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(128, 49);
            this.exitButton.TabIndex = 3;
            this.exitButton.Text = "ВЫХОД";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // admitButton
            // 
            this.admitButton.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.admitButton.Image = global::WindowsApp.Properties.Resources.mine40;
            this.admitButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.admitButton.Location = new System.Drawing.Point(364, 50);
            this.admitButton.Name = "admitButton";
            this.admitButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.admitButton.Size = new System.Drawing.Size(176, 49);
            this.admitButton.TabIndex = 2;
            this.admitButton.Text = "НАЧАТЬ";
            this.admitButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.admitButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.admitButton.UseVisualStyleBackColor = true;
            this.admitButton.Click += new System.EventHandler(this.admitButton_Click);
            // 
            // miner_app
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 111);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.boardSizeInput);
            this.Controls.Add(this.admitButton);
            this.Controls.Add(this.NumberOfMinesInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "miner_app";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Miner";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox NumberOfMinesInput;
        private System.Windows.Forms.Button admitButton;
        public System.Windows.Forms.TextBox boardSizeInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button exitButton;
    }
}

