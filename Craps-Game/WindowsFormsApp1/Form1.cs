using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1 {
    public partial class Form1 : Form {
        private Boolean player = true; //p1 = true, p2=false
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            Random random = new Random();
            label1.Text = random.Next(1, 7) + "";
            label3.Text = random.Next(1, 7) + "";
            this.player = !this.player;
            label2.Text = this.getPlayer();
        }

        private string getPlayer()
        {
            if(this.player)
            {
                return "Player 1";
            }
            return "Player 2";
        }
    }
}
