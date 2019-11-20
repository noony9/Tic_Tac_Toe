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
         
                foreach (var c in this.Controls)
                {
                    if (c.GetType().Equals(typeof(Button)))
                    {
                        Button b = c as Button;
                        b.Text = string.Empty;
                        b.Enabled = true;
                    }
                } //end foreach
         
        } //end NewGameToolSripMenuItem_Click()

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button_click(object sender, EventArgs e)
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
                DisableButtons();
                string winner = "";
                if (turn) // figure out who the winner is
                {
                    winner = "Player 2";
                    player2Score.Text = (Int32.Parse(player2Score.Text) + 1).ToString();
                }
                else
                {
                    winner = "Player 1";
                    player1Score.Text = (Int32.Parse(player1Score.Text) + 1).ToString();
                }
                MessageBox.Show(winner + " Wins!");
            } //end if
            else
            {
                if (turnCount == 9)
                {
                    MessageBox.Show("We have a Draw!!");
                    drawScore.Text = (Int32.Parse(drawScore.Text) + 1).ToString();
                }
            } //end else
        } //end CheckWin()
        private void DisableButtons()
        {
            foreach (var c in this.Controls)
            {
                if (c.GetType().Equals(typeof(Button)))
                {
                    Button b = c as Button;
                    b.Enabled = false;
                }
            } //end foreach    
        } //end disableButtons()

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
