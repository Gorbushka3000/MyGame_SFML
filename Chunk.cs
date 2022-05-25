using SFML.Graphics;
using SFML.System;
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
        Vector2i chunkPos;
        public Chunk(Vector2i chunkPos)
        {
            this.chunkPos = chunkPos;
            Position = new Vector2f(chunkPos.X * ChunkSize * Tile.TileSize, chunkPos.Y * ChunkSize * Tile.TileSize);
            tiles = new Tile[ChunkSize][];

            for (int i = 0; i < ChunkSize; i++)
                tiles[i] = new Tile[ChunkSize];
        }

        public void SetTile(TileType type, int x, int y)
        {
            tiles[x][y] = new Tile(type);
            tiles[x][y].Position = new Vector2f (x * Tile.TileSize, y * Tile.TileSize);
        }
        public void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform *= Transform;

            for (int x = 0; x < ChunkSize; x++)
            {
                for (int y = 0; y < ChunkSize; y++)
                {
                    if (tiles[x][y] == null) continue;
                    target.Draw(tiles[x][y], states);
                }
            }
        }
    }
}
