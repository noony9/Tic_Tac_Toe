using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public partial class Form1 : Form
    {
        // deterimine who's turn it is
        bool turn = true; // true equals X turn; false = O turn
        int turnCount = 0; // to increment each turn
        public Form1()
        {
            InitializeComponent();
        }

        private void FileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("By Daniel Jacobs", "About Tic_Tac_Toe");
        }

        private void NewGameToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (turn)
            {
                button.Text = "X"; // place the marker using button's text property
            }
            else
            {
                button.Text = "O";
            }
            turn = !turn;
            button.Enabled = false; // disable button to ensure that it cannot be modified by CHEATERS

        }
        private void CheckWin()
        {
            bool win = false;
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text)) // HORIZONTAL LINES
            {
                win = true;
            }
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && !B3.Enabled)
            {
                win= true;
            }
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && !C3.Enabled)
            {
                win = true;
            }
            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && !C1.Enabled) // VERTICAL LINES
            {
                win = true;
            }
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && !C2.Enabled)
            {
                win = true;
            }
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && !C3.Enabled)
            {
                win = true;
            }
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && !C3.Enabled) // DIAGONAL LINES
            {
                win = true;
            }
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && !C1.Enabled)
            {
                win = true;
            }

            if (win)
            {
                string winner = "";
                if (turn)
                {
                    winner = "X";
                }
                else
                {
                    winner = "O";
                }
                MessageBox.Show(winner + "Wins!");
            }
        }
    }
}
