using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Monogame1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D dinoTexture;
        Texture2D meteorTexture;
        Texture2D birdTexture;
        Texture2D landTexture;
        Texture2D backgrondTexture;
        Random generator = new Random();
        int birdY;
        int birdX;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferHeight = 750;
            _graphics.PreferredBackBufferWidth = 1200;
            _graphics.ApplyChanges();
            this.Window.Title = "First Mono Game";
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            birdY = generator.Next(300);
            birdX = generator.Next(500);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            int background = generator.Next(3);
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            if (background == 0) { backgrondTexture = Content.Load<Texture2D>("background1"); }
            else if (background == 1) { backgrondTexture = Content.Load<Texture2D>("background2"); }
            else if(background == 2) { backgrondTexture = Content.Load<Texture2D>("background3"); }

            dinoTexture = Content.Load<Texture2D> ("dino");
            meteorTexture = Content.Load<Texture2D>("meteor");
            landTexture = Content.Load<Texture2D>("land");
            birdTexture = Content.Load<Texture2D>("bird");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightBlue);
            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(backgrondTexture, new Vector2(0,0), Color.White);
            for (int i = 0; i < 10; i++)
            {
                _spriteBatch.Draw(dinoTexture, new Vector2(i*100, 450), Color.White);
            }
            _spriteBatch.Draw(landTexture, new Vector2(-250, -100), Color.White);
            _spriteBatch.Draw(birdTexture, new Vector2(birdX, birdY), Color.White);
            _spriteBatch.Draw(meteorTexture, new Vector2(650, -350), Color.Yellow);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}