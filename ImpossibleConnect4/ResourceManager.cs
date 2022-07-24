using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace ImpossibleConnect4
{
    class ResourceManager
    {
        private SpriteFont arial;

        private Texture2D piece;
        private Texture2D field;
        private Texture2D background;

        public ResourceManager() { }

        public void LoadContent(ContentManager cm)
        {
            arial = cm.Load<SpriteFont>("arial");

            piece = cm.Load<Texture2D>("pieceWhite");
            field = cm.Load<Texture2D>("field");
            background = cm.Load<Texture2D>("background");
        }

        public SpriteFont getArial() { return arial; }

        public Texture2D getPiece() { return piece; }
        public Texture2D getField() { return field; }
        public Texture2D getBackground() { return background; }
    }
}
