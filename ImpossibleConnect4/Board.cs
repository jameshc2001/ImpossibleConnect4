using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ImpossibleConnect4
{
    class Board
    {
        int[,] data = new int[6, 7];

        int px, py; //location of previously played counter

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
                    py = i;
                    px = column;
                    return true;
                }
            }

            return false;
        }

        //wanted to word this a lot better but couldnt
        //returns true if the previous move was a winning move
        //I may add a general win checker later
        public bool checkWinWithPrevMove(int p) //p is player
        {
            //check straight down
            if (py <= 2) //if it is further down then not possible to win like this
            {
                if (data[py, px] == p && data[py + 1, px] == p &&
                    data[py + 2, px] == p && data[py + 3, px] == p) return true;
            }

            //check sideways
            for (int i = 0; i < 4; i++)
            {
                if (data[py, i] == p && data[py, i + 1] == p &&
                    data[py, i + 2] == p && data[py, i + 3] == p) return true;
            }

            //top left to bottom right
            int temp = Math.Min(px, py);
            int sx = px - temp; //start x
            int sy = py - temp; //start y
            while (sx + 3 < 7 && sy + 3 < 6) //while in bounds
            {
                if (data[sy, sx] == p && data[sy + 1, sx + 1] == p &&
                    data[sy + 2, sx + 2] == p && data[sy + 3, sx + 3] == p) return true;
                sx++;
                sy++;
            }

            //bottom left to top right
            temp = Math.Min(px, 5 - py);
            sx = px - temp; //start x
            sy = py + temp; //start y
            while (sx + 3 < 7 && sy - 3 >= 0)
            {
                if (data[sy, sx] == p && data[sy - 1, sx + 1] == p &&
                    data[sy - 2, sx + 2] == p && data[sy - 3, sx + 3] == p) return true;
                sx++;
                sy--;
            }

            //no win found
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

        public int getTile(int i, int j) { return data[i, j]; }
    }
}
