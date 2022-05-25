using SFML;
using SFML.Graphics;
using System;

namespace MyGame
{
    class Program
    {
        static RenderWindow win;
        public static RenderWindow Window { get { return win; } }
        public static Game Game { get; private set; }
        static void Main(string[] args)
        {
            win = new RenderWindow(new SFML.Window.VideoMode(800, 600), "MyGame");
            win.SetVerticalSyncEnabled(true);
            win.Closed += Win_Closed;
            Content.Load();
            Game = new Game();
            while (win.IsOpen)
            {
                win.DispatchEvents();
                Game.Update();
                win.Clear(Color.Black);
                Game.Draw();
                win.Display();
            }
        }

        private static void Win_Closed(object? sender, EventArgs e)
        {
            win.Close();
        }
    }
}