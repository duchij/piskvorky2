using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace piskvorky2
{
    public partial class Form1 : Form
    {
        private static Form myForm;

        private TicTacToe field = null;

        public Form1()
        {
            InitializeComponent();

            myForm = this;

            this.newGame(10);

        }

        private void newGame(int c)
        {
            this.gv_gameField.CellClick += new DataGridViewCellEventHandler(cellClick);
            this.gv_gameField.ReadOnly = true;

            this.gv_gameField.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.gv_gameField.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.gv_gameField.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            
            this.gv_gameField.ColumnCount = c;
            this.gv_gameField.RowCount = c;

            Console.WriteLine(this.gv_gameField.Width);

            this.Size = new Size(this.gv_gameField.Width, this.gv_gameField.Height);

            this.field = new TicTacToe(c);
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void cellClick(object sender, DataGridViewCellEventArgs e)
        {
            Console.WriteLine(e.RowIndex);

            int pCol = e.RowIndex;
            int pRow = e.ColumnIndex;

            PlayerType pl;
            int direction = 0;
            bool win = false;
            if (this.field.makeMove(pCol, pRow, out pl))
            {
                string s = "";
               
                switch (pl)
                {
                    case PlayerType.Cross:
                        s = "x";
                        win = this.field.evaluateGame(pCol, pRow, PlayerType.Cross, out direction);
                        break;
                    case PlayerType.Circle:
                        s = "o";
                        win = this.field.evaluateGame(pCol, pRow, PlayerType.Circle, out direction);
                        break;

                }

                this.gv_gameField.CurrentCell.Value = s;

                
            }
            
            if (win)
            {
                

                MessageBox.Show("Vyhra");
            }

            
            
            

            //this.field.makeMove()
        }
    }
}
