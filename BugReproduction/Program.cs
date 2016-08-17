#region License

// Copyright (c) 2016, Vira
// All rights reserved.
// Solution: BugReproduction
// Project: BugReproduction
// Filename: Program.cs
// Date - created:2016.08.16 - 18:03
// Date - current: 2016.08.17 - 15:53

#endregion

#region Usings

using System;

#endregion

namespace BugReproduction
{
    /// <summary>
    ///     The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            using (var game = new Game1())
                game.Run();
        }
    }
}