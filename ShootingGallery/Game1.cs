﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ShootingGallery
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D sprite_Target;
        Texture2D sprite_Crosshair;
        Texture2D sprite_Background;

        SpriteFont gameFont;

        MouseState mState;
        bool mReleased = true;

        int score = 0;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            IsMouseVisible = true;
        }

        // ran when game first loads
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        // sprites, sounds, etc
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            sprite_Target = Content.Load<Texture2D>("target");
            sprite_Crosshair = Content.Load<Texture2D>("crosshairs");
            sprite_Background = Content.Load<Texture2D>("sky");

            gameFont = Content.Load<SpriteFont>("galleryFont");
        }

        // free up memory
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        // game loop, default 60 fps
        // method is ran every frame
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            mState = Mouse.GetState();
            if (mState.LeftButton == ButtonState.Pressed && mReleased)
            {
                score++;
                mReleased = false;
            }

            if (mState.LeftButton == ButtonState.Released)
                mReleased = true;

            base.Update(gameTime);
        }

        // render
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // tell the library that it's time to draw
            spriteBatch.Begin();

            spriteBatch.Draw(sprite_Background, new Vector2(0,0), Color.White);

            spriteBatch.DrawString(gameFont, score.ToString(), new Vector2(100, 100), Color.White);
            spriteBatch.Draw(sprite_Target, new Vector2(0,0), Color.White);

            // always have an end
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
