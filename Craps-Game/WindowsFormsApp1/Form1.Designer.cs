namespace WindowsFormsApp1
{
    partial class Form1
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
            this.rollButton = new System.Windows.Forms.Button();
            this.diceOnelabel = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.diceTwoLabel = new System.Windows.Forms.Label();
            this.currentPointLabel = new System.Windows.Forms.Label();
            this.playerNameBox = new System.Windows.Forms.TextBox();
            this.CreateButton = new System.Windows.Forms.Button();
            this.playerNameLabel = new System.Windows.Forms.Label();
            this.pointGrid = new System.Windows.Forms.DataGridView();
            this.playersGrid = new System.Windows.Forms.DataGridView();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.clearHistoryButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pointGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playersGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // rollButton
            // 
            this.rollButton.Location = new System.Drawing.Point(125, 230);
            this.rollButton.Name = "rollButton";
            this.rollButton.Size = new System.Drawing.Size(75, 23);
            this.rollButton.TabIndex = 0;
            this.rollButton.Text = "Roll";
            this.rollButton.UseVisualStyleBackColor = true;
            this.rollButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // diceOnelabel
            // 
            this.diceOnelabel.AutoSize = true;
            this.diceOnelabel.Location = new System.Drawing.Point(237, 233);
            this.diceOnelabel.Name = "diceOnelabel";
            this.diceOnelabel.Size = new System.Drawing.Size(56, 17);
            this.diceOnelabel.TabIndex = 1;
            this.diceOnelabel.Text = "Dice #1";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(29, 233);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(47, 17);
            this.statusLabel.TabIndex = 2;
            this.statusLabel.Text = "TURN";
            // 
            // diceTwoLabel
            // 
            this.diceTwoLabel.AutoSize = true;
            this.diceTwoLabel.Location = new System.Drawing.Point(331, 233);
            this.diceTwoLabel.Name = "diceTwoLabel";
            this.diceTwoLabel.Size = new System.Drawing.Size(56, 17);
            this.diceTwoLabel.TabIndex = 3;
            this.diceTwoLabel.Text = "Dice #2";
            // 
            // currentPointLabel
            // 
            this.currentPointLabel.AutoSize = true;
            this.currentPointLabel.Location = new System.Drawing.Point(417, 233);
            this.currentPointLabel.Name = "currentPointLabel";
            this.currentPointLabel.Size = new System.Drawing.Size(56, 17);
            this.currentPointLabel.TabIndex = 4;
            this.currentPointLabel.Text = "Point: #";
            // 
            // playerNameBox
            // 
            this.playerNameBox.Location = new System.Drawing.Point(29, 39);
            this.playerNameBox.Name = "playerNameBox";
            this.playerNameBox.Size = new System.Drawing.Size(441, 22);
            this.playerNameBox.TabIndex = 5;
            // 
            // CreateButton
            // 
            this.CreateButton.Location = new System.Drawing.Point(491, 37);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(75, 23);
            this.CreateButton.TabIndex = 6;
            this.CreateButton.Text = "Create New";
            this.CreateButton.UseVisualStyleBackColor = true;
            this.CreateButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // playerNameLabel
            // 
            this.playerNameLabel.AutoSize = true;
            this.playerNameLabel.Location = new System.Drawing.Point(29, 13);
            this.playerNameLabel.Name = "playerNameLabel";
            this.playerNameLabel.Size = new System.Drawing.Size(89, 17);
            this.playerNameLabel.TabIndex = 7;
            this.playerNameLabel.Text = "Player Name";
            // 
            // pointGrid
            // 
            this.pointGrid.AllowUserToAddRows = false;
            this.pointGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pointGrid.Location = new System.Drawing.Point(29, 278);
            this.pointGrid.Name = "pointGrid";
            this.pointGrid.ReadOnly = true;
            this.pointGrid.RowTemplate.Height = 24;
            this.pointGrid.Size = new System.Drawing.Size(687, 150);
            this.pointGrid.TabIndex = 8;
            // 
            // playersGrid
            // 
            this.playersGrid.AllowUserToAddRows = false;
            this.playersGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.playersGrid.Location = new System.Drawing.Point(29, 85);
            this.playersGrid.Name = "playersGrid";
            this.playersGrid.RowTemplate.Height = 24;
            this.playersGrid.Size = new System.Drawing.Size(687, 129);
            this.playersGrid.TabIndex = 9;
            this.playersGrid.DoubleClick += new System.EventHandler(this.dataGridView2_DoubleClick);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(587, 37);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteButton.TabIndex = 11;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.button4_Click);
            // 
            // clearHistoryButton
            // 
            this.clearHistoryButton.Location = new System.Drawing.Point(603, 233);
            this.clearHistoryButton.Name = "clearHistoryButton";
            this.clearHistoryButton.Size = new System.Drawing.Size(113, 23);
            this.clearHistoryButton.TabIndex = 12;
            this.clearHistoryButton.Text = "Clear History";
            this.clearHistoryButton.UseVisualStyleBackColor = true;
            this.clearHistoryButton.Click += new System.EventHandler(this.button5_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.clearHistoryButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.playersGrid);
            this.Controls.Add(this.pointGrid);
            this.Controls.Add(this.playerNameLabel);
            this.Controls.Add(this.CreateButton);
            this.Controls.Add(this.playerNameBox);
            this.Controls.Add(this.currentPointLabel);
            this.Controls.Add(this.diceTwoLabel);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.diceOnelabel);
            this.Controls.Add(this.rollButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pointGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playersGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button rollButton;
        private System.Windows.Forms.Label diceOnelabel;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label diceTwoLabel;
        private System.Windows.Forms.Label currentPointLabel;
        private System.Windows.Forms.TextBox playerNameBox;
        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.Label playerNameLabel;
        private System.Windows.Forms.DataGridView pointGrid;
        private System.Windows.Forms.DataGridView playersGrid;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button clearHistoryButton;
    }
}

