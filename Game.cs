using SFML.System;

namespace MyGame
{
    public class Game
    {
        World world;
        Player player;
        public Game()
        {
            world = new World();
            world.GeneratWorld();

            player = new Player(world);
            player.StartPosition = new Vector2f(300, 150);
            player.Spawn();

            DebugRender.Enabled = true;
        }
        public void Update()
        {
            player.Update();
        }
        public void Draw()
        {
            Program.Window.Draw(world);
            Program.Window.Draw(player);
            DebugRender.Draw(Program.Window);
        }
    }
}
