using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class Chunk : Transformable, Drawable
    {
        public const int ChunkSize = 25;
        Tile[][] tiles;
        public Chunk()
        {
            tiles = new Tile[ChunkSize][];

            for (int i = 0; i < ChunkSize; i++)
                tiles[i] = new Tile[ChunkSize];

            tiles[0][0] = new Tile();
        }
        public void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform *= Transform;

            for (int x = 0; x < ChunkSize; x++)
            {
                for (int y = 0; y < ChunkSize; y++)
                {
                    if (tiles[x][y] == null) continue;
                    target.Draw(tiles[x][y]);
                }
            }
        }
    }
}
