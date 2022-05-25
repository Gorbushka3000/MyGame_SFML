using SFML.Graphics;

namespace MyGame
{
    public class World : Transformable, Drawable
    {
        public const int WorldSize = 5;
        Chunk[][] chunks;
        public World()
        {
            chunks = new Chunk[WorldSize][];

            for (int i = 0; i < WorldSize; i++)
                chunks[i] = new Chunk[WorldSize];
            chunks[0][0] = new Chunk();
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            for (int x = 0;x < WorldSize;x++)
            {
                for (int y = 0;y < WorldSize;y++)
                {
                    if (chunks[x][y] == null) continue;
                    target.Draw(chunks[x][y]);
                }
            }
        }
    }
}
