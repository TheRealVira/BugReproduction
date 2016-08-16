#region License

// Copyright (c) 2016, Vira
// All rights reserved.
// Solution: BugReproduction
// Project: BugReproduction
// Filename: Game1.cs
// Date - created:2016.08.16 - 18:03
// Date - current: 2016.08.16 - 18:52

#endregion

#region Usings

using BugReproduction.Shader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

#endregion

namespace BugReproduction
{
    /// <summary>
    ///     This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        private static Texture2D SomeKindOfWaleAirplane;
        public static Texture2D CoolPixle2016;
        public static Vector2 Display_Dims;
        private readonly GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        ///     Allows the game to perform any initialization it needs to before starting to run.
        ///     This is where it can query for any required services and load any non-graphic
        ///     related content.  Calling base.Initialize will enumerate through any components
        ///     and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            CoolPixle2016 = new Texture2D(GraphicsDevice, 1, 1);
            CoolPixle2016.SetData(new[] {Color.White});
            Display_Dims = new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);

            // Initialize all shaders
            PseudoRandom.Initialize(graphics.GraphicsDevice, Content.Load<Effect>("Shader/P2"),
                graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);

            base.Initialize();
        }

        /// <summary>
        ///     LoadContent will be called once per game and is the place to load
        ///     all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // NOTE: THIS line here is no good:
            PseudoRandom.Draw(graphics.GraphicsDevice, spriteBatch);
                // This just draws white pixels into a rendertarget...

            SomeKindOfWaleAirplane = Content.Load<Texture2D>("Texture/Airplane");
        }

        /// <summary>
        ///     UnloadContent will be called once per game and is the place to unload
        ///     game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            //SomeKindOfWaleAirplane.Dispose(); // Clear exit
        }

        /// <summary>
        ///     Allows the game to run logic such as updating the world,
        ///     checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }

        /// <summary>
        ///     This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            spriteBatch.Draw(SomeKindOfWaleAirplane,
                new Rectangle(50, 50, SomeKindOfWaleAirplane.Width, SomeKindOfWaleAirplane.Height), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}