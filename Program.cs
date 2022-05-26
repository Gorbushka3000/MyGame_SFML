using SFML;
using SFML.Graphics;
using SFML.Window;
using System;

namespace MyGame
{
    class Program
    {
        static RenderWindow win;
        public static RenderWindow Window { get { return win; } }
        public static Game Game { get; private set; }
        public static Random Random { get; private set; }
        static void Main(string[] args)
        {
            win = new RenderWindow(new SFML.Window.VideoMode(800, 600), "MyGame");
            win.SetVerticalSyncEnabled(true);

            win.Closed += Win_Closed;
            win.Resized += Win_Resized;

            Content.Load();

            Random = new Random();
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

        private static void Win_Resized(object? sender, SizeEventArgs e)
        {
            win.SetView(new View(new FloatRect(0,0, e.Width,e.Height)));
        }

        private static void Win_Closed(object? sender, EventArgs e)
        {
            win.Close();
        }
    }
}