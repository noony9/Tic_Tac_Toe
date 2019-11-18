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
        bool turn = true; // true equals Player 1 turn (X); false = Player 2 turn (O)
        int turnCount = 0; // to increment each turn (for Draw)
        int playerOneScore = 0;
        int playerTwoScore = 0;
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
            turn = true; // Starts with Player 1 (X)
            turnCount = 0; // turn counts
            // reset all buttons (game board)
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                } //end foreach
            }
            catch { }
        } //end NewGameToolSripMenuItem_Click()

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
            {
                b.Text = "X"; // place the marker using button's text property  
            }
            else
            {
                b.Text = "O";
            }
            turn = !turn;
            b.Enabled = false; // disable button to ensure that it cannot be modified by CHEATERS
            turnCount++;
            // test increment on turnCount
            // MessageBox.Show(Convert.ToString(turnCount));
            CheckWin();
           
            
        } //end button_click
        private void CheckWin()
        {
            bool win = false;
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text && !A3.Enabled)) // HORIZONTAL LINES
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
                disableButtons();
                string winner = "";
                if (turn) // figure out who the winner is
                {
                    winner = "Player 2";
                }
                else
                {
                    winner = "Player 1";
                }
                MessageBox.Show(winner + " Wins!");
            } //end if
            else
            {
                if (turnCount == 9)
                {
                    MessageBox.Show("We have a Draw!!");
                    MessageBox.Show("Please go to [File] and start a [New Game] to determine the Champion!");
                }
            } //end else
        } //end CheckWin()
        private void disableButtons()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                } //end foreach
            }
            catch { }
        } //end disableButtons()

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }
    }
}
