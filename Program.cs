using SFML;
using SFML.Graphics;
using System;

namespace MyGame
{
    class Program
    {
        static RenderWindow win;
        static void Main(string[] args)
        {
            win = new RenderWindow(new SFML.Window.VideoMode(800, 600), "MyGame");
            win.SetVerticalSyncEnabled(true);
            win.Closed += Win_Closed;
            while (win.IsOpen)
            {
                win.DispatchEvents();
                win.Clear(Color.Black);
                win.Display();
            }
        }

        private static void Win_Closed(object? sender, EventArgs e)
        {
            win.Close();
        }
    }
}