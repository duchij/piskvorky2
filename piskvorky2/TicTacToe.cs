using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace piskvorky2
{

    public enum PlayerType { None = 0, Cross = 1, Circle =2 }

    class TicTacToe
    {
        private int cols;
        private int rCols;
        //private int rows;

        private PlayerType[,]   matrix = null;
        private PlayerType nextPlayer;


        public TicTacToe(int c)
        {

            this.cols = c;
            this.rCols = c - 1;
            //this.rows = r;

            this.matrix = new PlayerType[c, c];

            
        }

        private PlayerType getActualPlayer()
        {
            return this.nextPlayer;
        }

        public bool makeMove(int pX, int pY, out PlayerType player)
        {
            player = this.nextPlayer;

            if (this.matrix[pX,pY] != PlayerType.None)
            {
                
                return false;
               // player = PlayerType.n
            }

            this.nextPlayer = this.nextPlayer == PlayerType.Cross ? PlayerType.Circle : PlayerType.Cross;
            this.matrix[pX, pY] = this.nextPlayer;

            player = this.nextPlayer;

            //return true;

            return true;

        }

        public bool evaluateGame(int pX, int pY, PlayerType pl, out int oDirect)
        {
            //this.directions.Clear();
            oDirect = 0;
            //this.directions.Add(DirectionType.Diagonal);
            bool win = false;
            //provokacia len jeden cyklus :) a rekurzia...
            for (var direct = 0; direct < 4; direct++)
            {

                //0 smer horizontal
                //1 smer verikal
                //2 smer zlava do sprava sikmo
                //3 smer sprava do lava sikmo

                //sice je to trochu dlhsie ale nealokujeme ziaden objekt, mame len ten co mame a 
                //pracujeme len s generickymi typmi :) int a bool...

                int res = this.evaluateDirection(direct, pX, pY, 0, 0, false, pl, 0);

                //int t = res;
                if (res == 5)
                {

                    oDirect = direct;
                    win = true;
                    break;
                }
            }


            return win;
        }

        private int evaluateDirection(int direct,int pRow, int pCol, int vRow, int vCol, bool inv, PlayerType pl, int count)
        {
            //ak uz napocital tak prec
            if (count == 5)
            {
                return count;
            }

            //ak vstupine do fnc prvykat nastavujeme si vCol a vRow, s tymito ratame;
            if (count == 0)
            {
                vCol = pCol;
                vRow = pRow;
            }
           
            switch (direct)
            {
                case 0: //horizontal sme x+1,y,  ak inv true x-1,y zlava do prava

                    //ak sa na nule ideme uz len doprava
                    if (count == 0 && pCol == 0)
                    {
                        inv = true;
                    }
                    //rovanju sa
                    if (this.matrix[pRow, vCol] == pl)
                    {
                        count++; //pridame bod


                        //zistujeme mozeme ist o jedno dozadu ak ano --
                        if (inv == false && vCol - 1 >= 0)
                        {
                            vCol--;
                        }
                        else if (inv == false && vCol - 1 < 0) // sme na kraji otocime smer..
                        {
                            inv = true;
                            vCol = pCol + 1;
                            this.evaluateDirection(direct, pRow, pCol, vRow, vCol, inv, pl, count);

                        }
                        else if (inv == true && vCol + 1 <= this.rCols) // ideme do prava sme na kraji
                        {
                            vCol++;
                        }
                        else if (inv == true && vCol + 1 > this.rCols) //ideme do prave sme na kraji nepocitame dalej ideme prec
                        {
                            return count;
                        }

                        //ak nenastalo ani jedno tak volame samoseba a ficime
                        this.evaluateDirection(direct, pRow, pCol, vRow, vCol, inv, pl, count);

                    }
                    else
                    {

                        if (inv == false) // zmena smeru?
                        {
                            if (pCol == 9) //sme nakraji naco pocitat ideme prec
                            {
                                return count;
                            }

                            if (vCol + 1 <= this.rCols) // nie sme na kraji ma to zmysel, meni smer a ideme do prava
                            {
                                vCol = pCol + 1;
                                inv = true;
                                this.evaluateDirection(direct, pRow, pCol, vRow, vCol, inv, pl, count);
                            }
                            else
                            {
                                return count; //inak prec
                            }

                        }
                        else
                        {
                            return count; //inak prec
                        }

                    }
                    break;//koniec horizontalnej kontroly

                case 1: //smer vertikal x, y=-1; a x a y=+1

                    //ak sa na nule ideme uz len doprava
                    if (count == 0 && pRow == 0)
                    {
                        inv = true;
                    }
                    //rovanju sa
                    if (this.matrix[vRow, pCol] == pl)
                    {
                        count++; //pridame bod


                        //zistujeme mozeme ist o jedno dozadu ak ano --
                        if (inv == false && vRow - 1 >= 0)
                        {
                            vRow--;
                        }
                        else if (inv == false && vRow-1 < 0) // sme na kraji otocime smer..
                        {
                            inv = true;
                            vRow = pRow + 1;
                            this.evaluateDirection(direct, pRow, pCol, vRow, vCol, inv, pl, count);

                        }
                        else if (inv == true && vRow + 1 <= this.rCols) // ideme do prava sme na kraji
                        {
                            vRow++;
                        }
                        else if (inv == true && vRow+1 > this.rCols) //ideme do prave sme na kraji nepocitame dalej ideme prec
                        {
                            return count;
                        }
                       
                        //ak nenastalo ani jedno tak volame samoseba a ficime
                        this.evaluateDirection(direct, pRow, pCol, vRow, vCol, inv, pl, count);

                    }
                    else
                    {
                        if (inv == false) // zmena smeru?
                        {
                            if (pRow == this.rCols) //sme nakraji naco pocitat ideme prec
                            {
                                return count;
                            }

                            if (vRow+1 <= this.rCols) // nie sme na kraji ma to zmysel, meni smer a ideme do prava
                            {
                                vRow = pRow + 1;
                                inv = true;
                                this.evaluateDirection(direct, pRow, pCol, vRow, vCol, inv, pl, count);
                            }
                            else
                            {
                                return count; //inak prec
                            }
                        }
                        else
                        {
                            return count; //inak prec
                        }
                    }
                    break; //koniec vertkilnej kontroly

                case 2://zaciatok sikmej z lava do prava

                    //kontrola ci nie sme v slepom rohu
                    if (count == 0 && pRow == 0 && pCol == this.rCols)
                    {
                        return count;
                    }

                    if (count == 0 && pRow == this.rCols && pCol == 0)
                    {
                        return count;
                    }

                    if (count == 0 && pRow == 0)
                    {
                        inv = true;
                    }
                    //rovanju sa
                    if (this.matrix[vRow, vCol] == pl)
                    {
                        count++; //pridame bod


                        //zistujeme mozeme ist o jedno dozadu ak ano --
                        if (inv == false && vRow - 1 >= 0)
                        {
                            vRow--;
                            vCol = vRow;
                            //vCol--;
                        }
                        else if (inv == false && vRow - 1 < 0) // sme na kraji otocime smer..
                        {
                            inv = true;
                            vRow = pRow + 1;
                            vCol = vRow;
                            this.evaluateDirection(direct, pRow, pCol, vRow, vCol, inv, pl, count);

                        }
                        else if (inv == true && vRow + 1 <= this.rCols) // ideme do prava sme na kraji
                        {
                            vRow++;
                            vCol = vRow;
                        }
                        else if (inv == true && vRow + 1 > this.rCols) //ideme do prave sme na kraji nepocitame dalej ideme prec
                        {
                            return count;
                        }

                        //ak nenastalo ani jedno tak volame samoseba a ficime
                        this.evaluateDirection(direct, pRow, pCol, vRow, vCol, inv, pl, count);

                    }
                    else
                    {
                        if (inv == false) // zmena smeru?
                        {
                            if (pRow == this.rCols) //sme nakraji naco pocitat ideme prec
                            {
                                return count;
                            }

                            if (vRow + 1 <= this.rCols) // nie sme na kraji ma to zmysel, meni smer a ideme do prava
                            {
                                vRow = pRow + 1;
                                vCol = vRow;
                                inv = true;
                                this.evaluateDirection(direct, pRow, pCol, vRow, vCol, inv, pl, count);
                            }
                            else
                            {
                                return count; //inak prec
                            }
                        }
                        else
                        {
                            return count; //inak prec
                        }
                    }

                    break;
                case 3:
                    //ci nie sme v slepych rohov / horny lavy
                    if (count == 0 && pRow == 0 && pCol == 0)
                    {
                        return count;
                    }
                    //ci nie sme v slepych rohov / pravy dolny
                    if (count == 0 && pRow == this.rCols && pCol == this.rCols)
                    {
                        return count;
                    }

                    if (count ==0 && pRow == 0)
                    {
                        inv = true;
                    }

                    if (count==0 && pCol == this.rCols)
                    {
                        inv = true;
                    }
                    

                    //rovanju sa
                    if (this.matrix[vRow, vCol] == pl)
                    {
                        count++; //pridame bod


                        //zistujeme mozeme ist o jedno dozadu ak ano --
                        if ((!inv && vRow - 1 >= 0) && (!inv && vCol + 1 <= this.rCols))
                        {
                            vRow--;
                            vCol++;
                        }
                        else if((!inv && vRow - 1 < 0) &&(!inv && vCol+1 > this.rCols)) // sme na kraji otocime smer..
                        {
                            inv = true;
                            vRow = pRow + 1;
                            vCol = pCol - 1;
                            this.evaluateDirection(direct, pRow, pCol, vRow, vCol, inv, pl, count);

                        }
                        else if ((inv && vRow + 1 <= this.rCols) && (inv && vCol-1 >=0 ))// ideme do prava sme na kraji
                        {
                            vRow++;
                            vCol--;
                           // vCol = vRow;
                        }
                        else if ((inv && vRow + 1 > this.rCols) && (inv && vCol-1  <0))//ideme do prave sme na kraji nepocitame dalej ideme prec
                        {
                            return count;
                        }

                        //ak nenastalo ani jedno tak volame samoseba a ficime
                        this.evaluateDirection(direct, pRow, pCol, vRow, vCol, inv, pl, count);

                    }
                    else
                    {
                        if (inv == false) // zmena smeru?
                        {
                            if (pRow == this.rCols) //sme nakraji naco pocitat ideme prec
                            {
                                return count;
                            }
                            if (pCol == 0)
                            {
                                return count;
                            }

                            if (vRow + 1 <= this.rCols) // nie sme na kraji ma to zmysel, meni smer a ideme do prava
                            {
                                vRow = pRow + 1;
                                vCol = pCol - 1;
                                inv = true;
                                this.evaluateDirection(direct, pRow, pCol, vRow, vCol, inv, pl, count);
                            }
                            else
                            {
                                return count; //inak prec
                            }
                        }
                        else
                        {
                            return count; //inak prec
                        }
                    }
                    break;
            }
           return  this.evaluateDirection(direct, pRow, pCol, vRow, vCol, inv, pl, count);
        }

        public PlayerType[,] getPlayField()
        {
           // this.matrix.

            return this.matrix;
        }
    }
}
