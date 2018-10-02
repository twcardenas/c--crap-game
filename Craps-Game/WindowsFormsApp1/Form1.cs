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
        private int point = 0;
        private int turn = 0;
        private Boolean gameOver = false;

        private string connectionString = @"Server=localhost;Database=CrapsDB;Uid=root;Pwd=pwd;";
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            Random random = new Random();

            //Roll two dices
            int r1 = random.Next(1, 7);
            int r2 = random.Next(1, 7);

            //Sum
            int sum = r1 + r2;

            //Show Rolls
            label1.Text = "Dice #1: " + r1;
            label3.Text = "Dice #2: " + r2;

            if (this.turn == 0) { 
                this.comeOutRoll(sum);
            } else  {
                this.evaluateRoll(sum);
            }
            
            if(this.gameOver == false) {
                turn++;
                this.label2.Text = "Turn: " + turn;
            } else {
                this.gameOver = false;
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
                MessageBox.Show("You Win! New Game!");
                this.resetGame();
            }
        }

        private void resetGame() {
            this.changeGameStatus("New Game");
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
            label4.Text = "Point: " + this.point;
        }

        private void changeGameStatus(string value) {
            label2.Text = value;
        }

        private void label5_Click(object sender, EventArgs e) {

        }

        //Add User to the DB and start the game
        private void button2_Click(object sender, EventArgs e) {
            //Add the user to the DB
            using (MySqlConnection mysqlCon = new MySqlConnection(this.connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mySqlCmd = new MySqlCommand("PlayerAddOrEdit", mysqlCon);
                mySqlCmd.CommandType = CommandType.StoredProcedure;
                mySqlCmd.Parameters.AddWithValue("Name", textBox1.Text.Trim());
                mySqlCmd.ExecuteNonQuery();
                MessageBox.Show("Person Added");
                this.PlayerGridFill();
            }
        }

        //Fill all players
        void PlayerGridFill()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(this.connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("PlayersViewAll", mysqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dtblPlayers = new DataTable();
                sqlDa.Fill(dtblPlayers);
                dataGridView2.DataSource = dtblPlayers;
            }
        }

        //The result of each round including the sum of each of their rolls, point
        //(if set), and the win/lose/null result.
        private void addTurnResults(int playerID, int sum, int point, string gameStatus) {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.PlayerGridFill();
        }
    }
}
