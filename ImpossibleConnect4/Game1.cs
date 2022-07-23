using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Diagnostics;

namespace ImpossibleConnect4
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private InputHandler inputHandler;
        private ResourceManager resourceManager;

        private string title = "Impossible Connect 4";
        private List<Text> texts; //buttons

        private bool inMatch = false;
        private Match match;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            graphics.ApplyChanges();

            inputHandler = new InputHandler();
            resourceManager = new ResourceManager();

            match = new Match(inputHandler, resourceManager);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            resourceManager.LoadContent(this.Content);

            //setup text / buttons
            texts = new List<Text>();
            texts.Add(new Text(inputHandler, resourceManager.getArial(), title, new Vector2(220, 100), Color.White, 1.0f));
            texts.Add(new Text(inputHandler, resourceManager.getArial(), "CPU", new Vector2(220, 300), Color.White, 1.0f));
            texts.Add(new Text(inputHandler, resourceManager.getArial(), "2 Player", new Vector2(220, 400), Color.White, 1.0f));
            texts.Add(new Text(inputHandler, resourceManager.getArial(), "Exit", new Vector2(220, 500), Color.White, 1.0f));
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            inputHandler.Update();

            //we are either in the main menu or currently in a match
            if (inMatch)
            {

            }
            else
            {
                //update buttons and check if they were clicked
                for (int i = 1; i < texts.Count; i++)
                {
                    texts[i].UpdateColor();
                    if (texts[i].wasClicked())
                    {
                        switch (i)
                        {
                            case 1:
                                //CPU
                                break;

                            case 2:
                                //2 Player
                                match.Setup(false);
                                break;

                            case 3:
                                //Exit
                                Exit();
                                break;

                            default:
                                break;
                        }
                    }
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            //we are either in the main menu or currently in a match
            if (inMatch)
            {

            }
            else
            {
                //render text
                foreach (Text t in texts) t.Draw(spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
