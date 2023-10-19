using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToeProj
{
    public partial class Form1 : Form
    {
        int[][] board = new int[3][];
        int turn = 1; //1 is X and -1 is O
        bool isGame = true;
        Image imageX = Image.FromFile(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Images\\x_icon_proj.png"));
        Image imageO = Image.FromFile(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Images\\o_icon_proj.png"));       

        public Form1()
        {
            InitializeComponent();
            for(int i = 0; i < board.Length; i++)
                board[i] = new int[]{0,0,0};
           
        }

        private void placeSymbol(int x, int y, PictureBox pictureBox)
        {
            if (board[x][y] != 0)
                return;
          
            board[x][y] = turn;
            if (turn == 1)
                pictureBox.Image = imageX;
            else
                pictureBox.Image = imageO;

            turn *= -1; //Swaps between X or O bc 1 * -1 = -1 and -1 * -1 = 1

            //X Wins
            if (board[x][0] == 1 && board[x][1] == 1 && board[x][2] == 1) //Verticals
            {
                Score.Text = "X Wins!"; Score.Visible = !Score.Visible;
                isGame = false;
            } 
            else if (board[0][y] == 1 && board[1][y] == 1 && board[2][y] == 1) //Horizontals
            {
                Score.Text = "X Wins!"; Score.Visible = !Score.Visible;
                isGame = false;
            } 
            else if ((board[0][0] == 1 && board[1][1] == 1 && board[2][2] == 1) || (board[0][2] == 1 && board[1][1] == 1 && board[2][0] == 1)) //Diagonals
            {
                Score.Text = "X Wins!"; Score.Visible = !Score.Visible;
                isGame = false;
            }

            //Y Wins
            if (board[x][0] == -1 && board[x][1] == -1 && board[x][2] == -1) //Verticals
            {
                Score.Text = "O Wins!"; Score.Visible = !Score.Visible;
                isGame = false;
            }
            else if (board[0][y] == -1 && board[1][y] == -1 && board[2][y] == -1) //Horizontals
            {
                Score.Text = "O Wins!"; Score.Visible = !Score.Visible;
                isGame = false;
            }
            else if ((board[0][0] == -1 && board[1][1] == -1 && board[2][2] == -1) || (board[0][2] == -1 && board[1][1] == -1 && board[2][0] == -1)) //Diagonals
            {
                Score.Text = "O Wins!"; Score.Visible = !Score.Visible;
                isGame = false;
            }

            int total = 0;

            for(int i = 0; i < board.Length; i++)
            {
                for(int j = 0; j < board[i].Length; j++)
                {
                    total += Math.Abs(board[i][j]);
                }
            }

            if(total == 9 && isGame)
            {
                isGame = false;
                Score.Text = "TIE!";
                Score.Visible = !Score.Visible;
            }

            if (!isGame)
            {
                playAgainButton.Visible = true;
                pictureBox1.Enabled = false; pictureBox2.Enabled = false; pictureBox3.Enabled = false; pictureBox4.Enabled = false; pictureBox5.Enabled = false;
                pictureBox6.Enabled = false; pictureBox7.Enabled = false; pictureBox8.Enabled = false; pictureBox9.Enabled = false;
                
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            placeSymbol(0, 0, pictureBox1);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            placeSymbol(1, 0, pictureBox2);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            placeSymbol(2, 0, pictureBox3);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            placeSymbol(0, 1, pictureBox4);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            placeSymbol(1, 1, pictureBox5);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            placeSymbol(2, 1, pictureBox6);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            placeSymbol(0, 2, pictureBox7);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            placeSymbol(1, 2, pictureBox8);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            placeSymbol(2, 2, pictureBox9);
        }

        private void playAgainButton_Click(object sender, EventArgs e)
        {
            playAgainButton.Visible = false;
            Score.Visible = false;
            pictureBox1.Enabled = true; pictureBox2.Enabled = true; pictureBox3.Enabled = true; pictureBox4.Enabled = true; pictureBox5.Enabled = true;
            pictureBox6.Enabled = true; pictureBox7.Enabled = true; pictureBox8.Enabled = true; pictureBox9.Enabled = true;
            for (int i = 0; i < board.Length; i++)
                board[i] = new int[] { 0, 0, 0 };
            pictureBox1.Image = null;
            pictureBox2.Image = null;
            pictureBox3.Image = null;
            pictureBox4.Image = null;
            pictureBox5.Image = null;
            pictureBox6.Image = null;
            pictureBox7.Image = null;
            pictureBox8.Image = null;
            pictureBox9.Image = null;
            isGame = true;
            turn = 1;
        }
    }
}
