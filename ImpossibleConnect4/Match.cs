using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ImpossibleConnect4
{
    //mainly just handles user input and rendering of the board
    class Match
    {
        public bool inMatch = false;
        private bool won = false;

        private bool CPU; //true if playing against computer
        private Board board;

        private InputHandler input;
        private ResourceManager rm;

        private Color red = new Color(255, 50, 50);
        private Color yellow = new Color(255, 255, 50);

        private Vector2 boardOrigin = new Vector2(178, 140); //top left of board
        private Vector2 pieceOffset = new Vector2(6, 6);

        private int activePlayer;

        private bool drawActiveCounter = false;
        private Vector2 activeCounterPosition;
        private int activeColumn;

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

            //randomly decide who gets to start
            Random rand = new Random();
            double val = rand.NextDouble();
            if (val < 0.5) activePlayer = 1; //yellow
            else activePlayer = 2; //red

            won = false;
            inMatch = true;
        }

        public void Update()
        {
            //check for exit
            if (input.getEscJustDown())
            {
                inMatch = false;
                return;
            }

            if (won)
            {
                //display win message
            }
            else
            {
                //should we draw the active counter (indicates where counter will go to user)
                Vector2 mousePos = input.getMousePosition();
                if (mousePos.X > boardOrigin.X && mousePos.X < boardOrigin.X + 7 * 128)
                {
                    drawActiveCounter = true;
                    activeColumn = (int)Math.Floor((mousePos.X - boardOrigin.X) / 128.0f);
                    activeCounterPosition = new Vector2(activeColumn * 128, -128) + boardOrigin + pieceOffset;
                }
                else
                {
                    drawActiveCounter = false;
                }

                //check if move made!
                if (drawActiveCounter && input.getMouseJustDown())
                {
                    if (board.makeMove(activeColumn, activePlayer))
                    {
                        //check if they won TODO
                        if (board.checkWinWithPrevMove(activePlayer))
                        {
                            Debug.WriteLine(activePlayer + " has won!");

                            //display some kind of win message and exit button?
                            won = true;
                        }
                        else
                        {
                            if (activePlayer == 1) activePlayer = 2; //from yellow to red
                            else activePlayer = 1; //from red to yellow
                        }
                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //draw active counter if necessary
            if (drawActiveCounter && !won)
            {
                Color color = Color.White;
                if (activePlayer == 1) color = yellow;
                else color = red;

                spriteBatch.Draw(rm.getPiece(), activeCounterPosition, null,
                    color, 0, new Vector2(0, 0), new Vector2(1.7f, 1.7f), SpriteEffects.None, 1);
            }

            //draw board
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Vector2 tilePos = boardOrigin + new Vector2(j * 128, i * 128);

                    //tile background
                    spriteBatch.Draw(rm.getBackground(), tilePos, null,
                        Color.White, 0, new Vector2(0, 0), new Vector2(4f, 4f), SpriteEffects.None, 0.5f);

                    //piece, if necessary
                    Color pieceColour = Color.White;
                    int tile = board.getTile(i, j);
                    if (tile != 0)
                    {
                        if (tile == 1) pieceColour = yellow;
                        else pieceColour = red;

                        spriteBatch.Draw(rm.getPiece(), tilePos + pieceOffset, null,
                            pieceColour, 0, new Vector2(0, 0), new Vector2(1.7f, 1.7f), SpriteEffects.None, 1);
                    }

                    //tile border
                    spriteBatch.Draw(rm.getField(), tilePos, null,
                        new Color(1, 125, 233) * 1.1f, 0, new Vector2(0, 0), new Vector2(0.5f, 0.5f), SpriteEffects.None, 1);
                }
            }
        }
    }
}
