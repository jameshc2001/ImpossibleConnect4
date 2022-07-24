using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ImpossibleConnect4
{
    class InputHandler
    {
        private bool prevMouseDown;
        private bool mouseDown;
        private bool mouseJustDown;
        private Vector2 mousePos;

        private bool prevEscDown;
        private bool escDown;
        private bool escJustDown;


        public InputHandler() {
            //do nothing?
        }

        public void Update()
        {
            //check for exit
            escDown = Keyboard.GetState().IsKeyDown(Keys.Escape);

            //get esc just down
            escJustDown = (escDown && (escDown != prevEscDown));

            //set prev
            prevEscDown = escDown;

            //get mouse state
            MouseState ms = Mouse.GetState();

            //get position
            mousePos = new Vector2(ms.X, ms.Y); //might need to do scaling later?

            //get mouse down
            mouseDown = ms.LeftButton == ButtonState.Pressed;

            //set just down
            mouseJustDown = (mouseDown && (mouseDown != prevMouseDown));

            //set prev
            prevMouseDown = mouseDown;
        }

        public Vector2 getMousePosition() { return mousePos; }
        public bool getMouseJustDown() { return mouseJustDown; }

        public bool getEscJustDown() { return escJustDown; }
    }
}
