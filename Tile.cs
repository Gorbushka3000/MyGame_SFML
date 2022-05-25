using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public enum TileType
    {
        NONE,
        GROUND,
        GRASS
    }
    public class Tile : Transformable, Drawable
    {
        public const int TileSize = 16;
        TileType type = TileType.GROUND;
        RectangleShape shape;
        Tile upTile = null;
        Tile downTile = null;
        Tile leftTile = null;
        Tile rightTile = null;
        public Tile(TileType type, Tile upTile, Tile downTile, Tile leftTile, Tile rightTile)
        {
            this.type = type;

            if (upTile == null)
            {
                this.upTile = upTile;
                this.upTile.downTile = this;
            }
            if (downTile == null)
            {
                this.downTile = downTile;
                this.downTile.upTile = this;
            }
            if (leftTile == null)
            {
                this.leftTile = leftTile;
                this.leftTile.rightTile = this;
            }
            if (rightTile == null)
            {
                this.rightTile = rightTile;
                this.rightTile.leftTile = this;
            }
            shape = new RectangleShape(new Vector2f(TileSize,TileSize));

            switch(type)
            {
                case TileType.GROUND:
                    shape.Texture = Content.texTile0;   
                    break;
                case TileType.GRASS:
                    shape.Texture = Content.texTile1;
                    break;
            }
            shape.TextureRect = GetTextureRect(1,1);
            UpdateView();
        }
        public void UpdateView()
        {

        }
        public IntRect GetTextureRect(int i, int j)
        {
            int x = i * TileSize + i * 2;
            int y = j * TileSize + j * 2;

            return new IntRect(x, y, TileSize, TileSize);
        }
        public void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform *= Transform;
            target.Draw(shape, states);
        }
    }
}
