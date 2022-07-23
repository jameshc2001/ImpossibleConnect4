using System;
using System.Collections.Generic;
using System.Text;

namespace ImpossibleConnect4
{
    //mainly just handles user input and rendering of the board
    class Match
    {
        private bool CPU; //true if playing against computer
        private Board board;

        private InputHandler input;
        private ResourceManager rm;

        public Match(InputHandler input, ResourceManager rm)
        {
            this.input = input;
            this.rm = rm;
            board = new Board();
        }

        public void Setup(bool CPU)
        {
            this.CPU = CPU;

            board.resetBoard();

            //test code
            board.makeMove(2, 1);
            board.makeMove(2, 2);
            board.makeMove(2, 1);
            board.makeMove(2, 2);
            board.makeMove(3, 1);
            board.makeMove(3, 2);
            board.debugPrint();
        }

        public void Update()
        {

        }

        public void Draw()
        {

        }
    }
}
