using SFML.Graphics;
using SFML.System;

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
        }
        public void GeneratWorld()
        {
            for(int x = 5; x < 7; x++)
                for(int y = 5; y < 7; y++)
                    SetTile(TileType.GROUND, x, y);
        }
        public void SetTile(TileType type, int x, int y)
        {
            var chunk = GetChunk(x, y);
            var tilePosition = GetTilePosFromChunk(x, y);

            Tile upTile = GetTile(x, y - 1);
            Tile downTile = GetTile(x, y + 1);
            Tile leftTile = GetTile(x - 1, y);
            Tile rightTile = GetTile(x + 1, y);

            chunk.SetTile(type, tilePosition.X, tilePosition.Y, upTile, downTile, leftTile, rightTile);
        }
        public Tile GetTile(int x, int y)
        {
            var chunk = GetChunk(x, y);
            if (chunk == null)
                return null;
            var tilePosition = GetTilePosFromChunk(x, y);

            return chunk.GetTile(tilePosition.X, tilePosition.Y);
        }
        public Chunk GetChunk(int x, int y)
        {
            int X = x / Chunk.ChunkSize;
            int Y = y / Chunk.ChunkSize;

            if(chunks[X][Y] == null)
            {
                chunks[X][Y] = new Chunk(new Vector2i(X,Y));
            }
            return chunks[X][Y];
        }
        public Vector2i GetTilePosFromChunk(int x, int y)
        {
            int X = x / Chunk.ChunkSize;
            var Y = y / Chunk.ChunkSize;

            return new Vector2i(x-X*Chunk.ChunkSize, y-Y*Chunk.ChunkSize);
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
