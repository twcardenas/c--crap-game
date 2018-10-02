using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1 {
    public partial class Form1 : Form {
        private int point = 0; //Players current point
        private int turn = 0; //Round of rolling dice
        private Boolean gameOver = false; //Is the game over
        private int playerID = 0; //ID of the Player Playing


        private string connectionString = @"Server=localhost;Database=CrapsDB;Uid=root;Pwd=pwd;";

        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            //Can Only Play if player is selected
            if (this.playerID != 0) {
                Random random = new Random();

                //Roll two dices
                int r1 = random.Next(1, 7);
                int r2 = random.Next(1, 7);

                //Sum
                int sum = r1 + r2;

                //Show Rolls
                diceOnelabel.Text = "Dice #1: " + r1;
                diceTwoLabel.Text = "Dice #2: " + r2;

                if (this.turn == 0) {
                    this.comeOutRoll(sum);
                } else {

                    this.changeGameStatus("New Game");
                    this.evaluateRoll(sum);
                }

                if (this.gameOver == false) {
                    turn++;
                    this.statusLabel.Text = "Turn: " + turn;
                    this.addTurnResults(sum, this.statusLabel.Text);
                } else {
                    this.addTurnResults(sum, this.statusLabel.Text);
                    this.gameOver = false;

                }

            
            }
        }

        private void evaluateRoll(int sum) {
            //Post Turn One, if sum = 7, loses, if point == point, win and point is reset
            //When point is rest, game starts over
            if (sum == 7) {
                this.changeGameStatus("You Lose");
                this.resetGame();
            }

            if (sum == this.point) {
                this.changeGameStatus("You Win! New Game!");

                this.resetGame();
            }
        }

        private void resetGame() {
            this.turn = 0;
            this.point = 0;
            this.gameOver = true;
        }

        private void comeOutRoll(int sum) {
            if (sum == 7 || sum == 11) { //Call a natural and you get to roll again
                this.changeGameStatus("You Win!");
                this.resetGame();
            } else if(sum == 2 || sum == 3 || sum == 12) { //Lose Called a craps, and get to roll again
                this.changeGameStatus("You Lose");
                this.resetGame();
            }

            // ELSE then that sum becomes the player’s “point”
            //Object of the game is to roll this number again before you roll a seven
            this.point = sum;
            currentPointLabel.Text = "Point: " + this.point;
        }

        private void changeGameStatus(string value) {
            statusLabel.Text = value;
        }

        //Add User to the DB and start the game
        private void button2_Click(object sender, EventArgs e) {
            //Add the user to the DB
            using (MySqlConnection mysqlCon = new MySqlConnection(this.connectionString))
            {
                string text = playerNameBox.Text.Trim();
                if (text.Length > 0)
                {
                    mysqlCon.Open();
                    MySqlCommand cmd = new MySqlCommand();

                    cmd.CommandType = System.Data.CommandType.Text;

                    if (this.playerID == 0) {
                        cmd.CommandText = "INSERT Players (PlayerName) VALUES (@name)";
                        cmd.Parameters.AddWithValue("@name", text);
                        this.RollGridFill();
                    }  else {
                        cmd.CommandText = "UPDATE Players SET PlayerName = @name WHERE ID = @id";
                        cmd.Parameters.AddWithValue("@name", text);
                        cmd.Parameters.AddWithValue("@id", this.playerID);

                    }
                    cmd.Connection = mysqlCon;
                    cmd.ExecuteNonQuery();
                    mysqlCon.Close();
                    this.PlayerGridFill();
                }
            }
        }

        //Fill all players
        void PlayerGridFill()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(this.connectionString))
            {
                mysqlCon.Open();

                var select = "SELECT * FROM Players";
                MySqlDataAdapter sqlDa = new MySqlDataAdapter(select, mysqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.Text;

                DataTable dtblPlayers = new DataTable();
                sqlDa.Fill(dtblPlayers);
                playersGrid.DataSource = dtblPlayers;
                playersGrid.Columns[0].Visible = false;
                mysqlCon.Close();
            }
        }

        void RollGridFill()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(this.connectionString)) {
                mysqlCon.Open();

                var select = "SELECT * FROM Rolls WHERE playerID = @id";
                MySqlDataAdapter sqlDa = new MySqlDataAdapter(select, mysqlCon);

                sqlDa.SelectCommand.Parameters.AddWithValue("@id", this.playerID);
                sqlDa.SelectCommand.CommandType = CommandType.Text;

                DataTable dtblPlayers = new DataTable();
                sqlDa.Fill(dtblPlayers);
                pointGrid.DataSource = dtblPlayers;
                pointGrid.Columns[0].Visible = false;
                pointGrid.Columns[1].Visible = false;
                mysqlCon.Close();
            }

            if (pointGrid.RowCount > 0)
            {
                this.gameOver = (Boolean)pointGrid.Rows[pointGrid.RowCount - 1].Cells[6].Value;

                if (!this.gameOver)
                {
                    this.turn = (int)pointGrid.Rows[pointGrid.RowCount - 1].Cells[5].Value;
                    this.point = (int)pointGrid.Rows[pointGrid.RowCount - 1].Cells[3].Value;

                }
            }
        }

        //The result of each round including the sum of each of their rolls, point
        //(if set), and the win/lose/null result.
        private void addTurnResults(int sum, string gameStatus) {
            using (MySqlConnection mysqlCon = new MySqlConnection(this.connectionString))
            {
                mysqlCon.Open();
                MySqlCommand cmd = new MySqlCommand();

                cmd.CommandType = System.Data.CommandType.Text;

                    
                cmd.CommandText = "INSERT Rolls (playerID, sum, point, status, turn, gameOver) VALUES (@id, @sum,@point,@status,@turn,@over)";
                cmd.Parameters.AddWithValue("@id", this.playerID);
                cmd.Parameters.AddWithValue("@sum", sum);
                cmd.Parameters.AddWithValue("@point", this.point);
                cmd.Parameters.AddWithValue("@status", gameStatus);
                cmd.Parameters.AddWithValue("@turn", this.turn);
                cmd.Parameters.AddWithValue("@over", this.gameOver);

                cmd.Connection = mysqlCon;
                cmd.ExecuteNonQuery();
                mysqlCon.Close();
                this.RollGridFill();
                
            }
        }

        private void Form1_Load(object sender, EventArgs e) {
            this.PlayerGridFill();
        }

        private void clear()
        {
            this.playerID = 0;
            playerNameBox.Text = "";
            CreateButton.Text = "Create";
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e){
            if(playersGrid.CurrentRow.Index != -1 ) {
                playerNameBox.Text = playersGrid.CurrentRow.Cells[1].Value.ToString();
                this.playerID = Convert.ToInt32(playersGrid.CurrentRow.Cells[0].Value.ToString());
                CreateButton.Text = "Update";
                this.RollGridFill();
            }
        }

        //Delete Player Profile
        private void button4_Click(object sender, EventArgs e)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(this.connectionString)) {

                mysqlCon.Open();
                MySqlCommand cmd = new MySqlCommand();

                cmd.CommandType = System.Data.CommandType.Text;

               cmd.CommandText = "DELETE FROM Players WHERE ID = @id";
               cmd.Parameters.AddWithValue("@id", this.playerID);
                
                cmd.Connection = mysqlCon;
                cmd.ExecuteNonQuery();
                mysqlCon.Close();
                this.clear();
                this.PlayerGridFill();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(this.connectionString))
            {

                mysqlCon.Open();
                MySqlCommand cmd = new MySqlCommand();

                cmd.CommandType = System.Data.CommandType.Text;

                cmd.CommandText = "DELETE FROM Rolls WHERE playerID = @id";
                cmd.Parameters.AddWithValue("@id", this.playerID);

                cmd.Connection = mysqlCon;
                cmd.ExecuteNonQuery();
                mysqlCon.Close();
                this.clear();
                this.PlayerGridFill();
            }
        }
    }
}
