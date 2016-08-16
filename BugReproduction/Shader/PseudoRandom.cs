#region License

// Copyright (c) 2016, Vira
// All rights reserved.
// Solution: BugReproduction
// Project: BugReproduction
// Filename: PseudoRandom.cs
// Date - created:2016.08.16 - 18:06
// Date - current: 2016.08.16 - 18:52

#endregion

#region Usings

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

#endregion

namespace BugReproduction.Shader
{
    public static class PseudoRandom
    {
        private static Effect effect;

        public static RenderTarget2D Generated;

        public static void Initialize(GraphicsDevice graphics, Effect rEffect, int width, int height)
        {
            Generated = new RenderTarget2D(graphics, width, height);
            effect = rEffect;
        }

        public static void Draw(GraphicsDevice graphics, SpriteBatch sp)
        {
            graphics.SetRenderTarget(Generated);
            graphics.Clear(Color.Black);

            sp.Begin(SpriteSortMode.Deferred, null, null, null, null, effect);
            {
                effect.CurrentTechnique.Passes[0].Apply();
                sp.Draw(Game1.CoolPixle2016, new Rectangle(0, 0, (int) Game1.Display_Dims.X, (int) Game1.Display_Dims.Y),
                    Color.White);
            }
            sp.End();

            graphics.SetRenderTarget(null);
        }
    }
}