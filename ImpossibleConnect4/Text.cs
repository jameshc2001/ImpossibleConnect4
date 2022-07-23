using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ImpossibleConnect4
{

    //Used for managing individual pieces of text. Doubles up as a button class.
    class Text
    {
        private InputHandler input;

        private SpriteFont font;
        private string text;
        private Vector2 position;
        private Vector2 size;
        private Color renderColor;
        private Color color;
        private Color hoverColor;
        private float scale;

        public Text(InputHandler input, SpriteFont font, string text, Vector2 position, Color color, float scale)
        {
            this.input = input;
            this.font = font;
            this.text = text;
            this.position = position;
            renderColor = color;
            this.color = color;
            hoverColor = color * 0.6f;
            this.scale = scale;
            size = font.MeasureString(text);
        }

        public void UpdateColor()
        {
            Vector2 mp = input.getMousePosition();
            if (mp.X > position.X && mp.X < position.X + size.X &&
                mp.Y > position.Y && mp.Y < position.Y + size.Y)
            {
                renderColor = hoverColor;
            }
            else
            {
                renderColor = color;
            }
        }

        public bool wasClicked()
        {
            //is mouse in text? is mouse button just down?
            Vector2 mp = input.getMousePosition();
            if (mp.X > position.X && mp.X < position.X + size.X &&
                mp.Y > position.Y && mp.Y < position.Y + size.Y)
            {
                return input.getMouseJustDown();
            }

            return false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, text, position, renderColor, 0, new Vector2(0,0), scale, SpriteEffects.None, 0.5f);
        }
    }
}
