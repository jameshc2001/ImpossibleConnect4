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

        public ResourceManager() { }

        public void LoadContent(ContentManager cm)
        {
            arial = cm.Load<SpriteFont>("arial");
        }

        public SpriteFont getArial() { return arial; }
    }
}
