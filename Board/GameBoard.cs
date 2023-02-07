using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Board
{
    public class GameBoard
    {
        // Dimension of the board is 8X8
        public int Dimension { get; set; }
        

        // 2D graph style board
        public Square[,] theGraph { get; set; }

        public GameBoard(int d) {

            Dimension = d;

            //creates a new grid
            theGraph = new Square[Dimension,Dimension];

            
            for (int i = 0; i < Dimension; i++)
            {
                for (int j = 0; j < Dimension; j++)
                {
                    theGraph[i,j] = new Square (i,j);
                }

            }

        }
        public bool isValid(int x, int y)
        {
            if (x < 0 || x >= Dimension || y < 0 || y >= Dimension)
            {
                return false;
            }
            else 
            { 
                return true; 
            }
        }


        public void ShowValidMove(Square currentSquare, string chessmen)
        {
            //Remove all valid moves previously identified
            for (int i = 0; i < Dimension; i++)
            {
                for (int j = 0; j < Dimension; j++)
                {
                    theGraph[i, j].ValidMove = false;
                    theGraph[i, j].Occupied  = false;

                }
            }

            // Identify all valid moves as "Valid"
            switch (chessmen)
            {
                case "Knight":
                    if (isValid(currentSquare.Horizontal +2, currentSquare.Vertical +1))
                    theGraph[currentSquare.Horizontal +2, currentSquare.Vertical +1 ].ValidMove= true;

                    if (isValid(currentSquare.Horizontal + 2, currentSquare.Vertical - 1))
                        theGraph[currentSquare.Horizontal + 2, currentSquare.Vertical -1].ValidMove = true;

                    if (isValid(currentSquare.Horizontal + 1, currentSquare.Vertical + 2))
                        theGraph[currentSquare.Horizontal + 1, currentSquare.Vertical +2].ValidMove = true;

                    if (isValid(currentSquare.Horizontal + 1, currentSquare.Vertical -2))
                        theGraph[currentSquare.Horizontal + 1, currentSquare.Vertical -2].ValidMove = true;

                    if (isValid(currentSquare.Horizontal - 2, currentSquare.Vertical + 1))
                        theGraph[currentSquare.Horizontal - 2, currentSquare.Vertical +1].ValidMove = true;

                    if (isValid(currentSquare.Horizontal -2 , currentSquare.Vertical -1))
                        theGraph[currentSquare.Horizontal - 2, currentSquare.Vertical -1].ValidMove = true;

                    if (isValid(currentSquare.Horizontal -1, currentSquare.Vertical + 2))
                        theGraph[currentSquare.Horizontal - 1, currentSquare.Vertical +2].ValidMove = true;

                    if (isValid(currentSquare.Horizontal -1, currentSquare.Vertical -2))
                        theGraph[currentSquare.Horizontal - 1, currentSquare.Vertical -2].ValidMove = true;

                    break;


                case "King":
                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            if (isValid(currentSquare.Horizontal +i, currentSquare.Vertical+ j))
                            {
                                theGraph[currentSquare.Horizontal + i, currentSquare.Vertical + j].ValidMove = true;
                            }
                        }
                    }
                    theGraph[currentSquare.Horizontal, currentSquare.Vertical].ValidMove = false;
                 
                    break;

                case "Queen":
                    for (int i = -8; i < 8; i++)
                    {
                        if (isValid(currentSquare.Horizontal + i, currentSquare.Vertical - i))
                        {
                            theGraph[currentSquare.Horizontal + i,  currentSquare.Vertical - i].ValidMove = true;    
                        }
                        if (isValid(currentSquare.Horizontal + i, currentSquare.Vertical + i))
                        {
                            theGraph[currentSquare.Horizontal + i, currentSquare.Vertical + i].ValidMove= true;
                        }
                    }

                    for (int i = -8; i < 8; i++)
                    {
                        if (isValid(currentSquare.Horizontal + i, currentSquare.Vertical ))
                        {
                            theGraph[currentSquare.Horizontal + i, currentSquare.Vertical].ValidMove= true;
                        }
                    }
                    for (int i =-8; i < 8; i++)
                    {
                        if (isValid(currentSquare.Horizontal, currentSquare.Vertical + i))
                        {
                            theGraph[currentSquare.Horizontal, currentSquare.Vertical + i].ValidMove = true;    
                        }
                    }
                    theGraph[currentSquare.Horizontal, currentSquare.Vertical].ValidMove= false;
                    break;

                case "Bishop":
                    for (int i = -8;  i < 8; i++)
                    {
                        if (isValid(currentSquare.Horizontal + i, currentSquare.Vertical - i))
                        {
                            theGraph[currentSquare.Horizontal + i, currentSquare.Vertical-i].ValidMove = true;
                        }
                        if (isValid(currentSquare.Horizontal + i, currentSquare.Vertical + i))
                        {
                            theGraph[currentSquare.Horizontal + i, currentSquare.Vertical +i].ValidMove= true;
                        }
                    }
                    break;

                case "Rook":

                    for (int i = -8; i < 8; i++) 
                    { 
                        if (isValid(currentSquare.Horizontal + i, currentSquare.Vertical ))
                        {
                            theGraph[currentSquare.Horizontal+i, currentSquare.Vertical].ValidMove = true;
                        }
                    }
                    
                    
                    
                        for (int i = -8; i < 8; i++)
                        {
                            if (isValid(currentSquare.Horizontal, currentSquare.Vertical +i))
                            {
                                theGraph[currentSquare.Horizontal, currentSquare.Vertical + i].ValidMove= true;
                            }
                        }
                    theGraph[ currentSquare.Horizontal, currentSquare.Vertical].ValidMove= false;
                    
                    break;

               
                default: 
                    break;
            }
            theGraph[currentSquare.Horizontal, currentSquare.Vertical].Occupied = true;
        }
    }
}
