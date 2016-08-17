#region License

// Copyright (c) 2016, Vira
// All rights reserved.
// Solution: BugReproduction
// Project: BugReproduction
// Filename: Game1.cs
// Date - created:2016.08.16 - 18:03
// Date - current: 2016.08.17 - 15:53

#endregion

#region Usings

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
        // Set this variable to true, to get the "not drawnig" airplane (which is unintended)
        private const bool BUGGED_OUT = false;
        private static Texture2D SomeKindOfWaleAirplane;
        public static Texture2D CoolPixle2016;
        private static Effect WhiteScreenShader;
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
            // Setup my "one-pixel" white texture
            CoolPixle2016 = new Texture2D(GraphicsDevice, 1, 1);
            CoolPixle2016.SetData(new[] {Color.White});

            WhiteScreenShader = Content.Load<Effect>("Shader/P2");

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

            // Load my airplane like image... :P
            SomeKindOfWaleAirplane = Content.Load<Texture2D>("Texture/Airplane");
        }

        /// <summary>
        ///     UnloadContent will be called once per game and is the place to unload
        ///     game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
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
            // Default clearing the screen:
            GraphicsDevice.Clear(Color.Black);

            // Drawing my background by using my shader (which should change all texture color to white):
            spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, BUGGED_OUT ? WhiteScreenShader : null);
            {
                // THIS LINE IS THE PROBLEM!!!!!!!!!!!
                // ----------------------------------------------------------------------------------------------------
                spriteBatch.Draw(CoolPixle2016,
                    new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight),
                    Color.Teal);
                // ----------------------------------------------------------------------------------------------------
            }
            spriteBatch.End(); // End the drawing call (+ should end my shader call)

            // Beginn a new call, to draw my airplane without the WhiteScreen shader:
            spriteBatch.Begin();
            {
                spriteBatch.Draw(SomeKindOfWaleAirplane,
                    new Rectangle(50, 50, SomeKindOfWaleAirplane.Width, SomeKindOfWaleAirplane.Height), Color.Blue);
                    // It's set to blue, so it'll be easier to see, when it works
            }
            spriteBatch.End(); // End it here

            // Question: Why doesn't my airplane show up?

            base.Draw(gameTime);
        }
    }
}