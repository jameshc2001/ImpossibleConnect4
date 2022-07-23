using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ImpossibleConnect4
{
    class Board
    {
        int[,] data = new int[6, 7];

        int prevX, prevY; //location of previously played counter

        public Board() { }

        public void resetBoard()
        {
            data = new int[6, 7];
        }

        //returns true if move made successfully
        public bool makeMove(int column, int player)
        {
            for (int i = 5; i >= 0; i--)
            {
                if (data[i, column] == 0)
                {
                    data[i, column] = player;
                    prevY = i;
                    prevX = column;
                    return true;
                }
            }

            return false;
        }

        public void debugPrint()
        {
            Debug.WriteLine("");
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Debug.Write(data[i, j] + " ");
                }
                Debug.WriteLine("");
            }
            Debug.WriteLine("");
        }
    }
}
