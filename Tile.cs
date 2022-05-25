using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    enum TileType
    {
        NONE,
        GROUND
    }
    public class Tile : Transformable, Drawable
    {
        public const int TileSize = 16;
        TileType type = TileType.GROUND;
        RectangleShape shape;
        public Tile()
        {
            shape = new RectangleShape(new Vector2f(TileSize,TileSize));

            switch(type)
            {
                case TileType.GROUND:
                    shape.Texture = Content.texTile0;
                    shape.TextureRect = new IntRect(0,0,TileSize,TileSize);
                    break;
            }
        }
        public void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform *= Transform;
            target.Draw(shape, states);
        }
    }
}
