using SFML.Graphics;
using SFML.System;

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
        public Tile rightTile = null;

        public Tile UpTile
        {
            get
            {
                return upTile;
            }
            set
            {
                upTile = value;
                UpdateView();
            }
        }
        public Tile DownTile
        {
            get
            {
                return downTile;
            }
            set
            {
                downTile = value;
                UpdateView();
            }
        }
        public Tile LeftTile
        {
            get
            {
                return leftTile;
            }
            set
            {
                leftTile = value;
                UpdateView();
            }
        }
        public Tile RightTile
        {
            get
            {
                return rightTile;
            }
            set
            {
                rightTile = value;
                UpdateView();
            }
        }

        public Tile(TileType type, Tile upTile, Tile downTile, Tile leftTile, Tile rightTile)
        {
            this.type = type;

            if (upTile != null)
            {
               this.upTile = upTile;
               this.upTile.DownTile = this;
            }
            if (downTile != null)
            {
                this.downTile = downTile;
                this.downTile.UpTile = this;
            }
            if (leftTile != null)
            {
                this.leftTile = leftTile;
                this.leftTile.RightTile = this;
            }
            if (rightTile != null)
            {
                this.rightTile = rightTile;
                this.rightTile.LeftTile = this;
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
           // shape.TextureRect = GetTextureRect(1,1);

            UpdateView();
        }
        public void UpdateView()
        {
            if (upTile != null && downTile != null  && leftTile != null && rightTile != null)
            {
                int i = Program.Random.Next(0, 3);
                shape.TextureRect = GetTextureRect(1 + i, 1);
            }
            else if (upTile == null && downTile == null && rightTile == null && leftTile == null)
            {
                int i = Program.Random.Next(0, 3);
                shape.TextureRect = GetTextureRect(9 + i, 3);
            }

            //---------------------------------------------------------------------------------//

            else if (upTile == null && downTile != null && rightTile != null && leftTile != null)
            {
                int i = Program.Random.Next(0, 3);
                shape.TextureRect = GetTextureRect(1 + i, 0);
            }
            else if (upTile != null && downTile == null && rightTile != null && leftTile != null)
            {
                int i = Program.Random.Next(0, 3);
                shape.TextureRect = GetTextureRect(1 + i, 2);
            }
            else if (upTile != null && downTile != null && rightTile != null && leftTile == null)
            {
                int i = Program.Random.Next(0, 3);
                shape.TextureRect = GetTextureRect(0, i);
            }
            else if (upTile != null && downTile != null && rightTile == null && leftTile != null)
            {
                int i = Program.Random.Next(0, 3);
                shape.TextureRect = GetTextureRect(4, i);
            }

            //---------------------------------------------------------------------------------//

            else if (upTile == null && downTile != null && rightTile != null && leftTile == null)
            {
                int i = Program.Random.Next(0, 3);
                shape.TextureRect = GetTextureRect(i*2, 3);
            }
            else if (upTile == null && downTile != null && rightTile == null && leftTile != null)
            {
                int i = Program.Random.Next(0, 3);
                shape.TextureRect = GetTextureRect(1 + i*2, 3);
            }
            else if (upTile != null && downTile == null && rightTile != null && leftTile == null)
            {
                int i = Program.Random.Next(0, 3);
                shape.TextureRect = GetTextureRect(i * 2, 4);
            }
            else if (upTile != null && downTile == null && rightTile == null && leftTile != null)
            {
                int i = Program.Random.Next(0, 3);
                shape.TextureRect = GetTextureRect(1 + i * 2, 4);
            }
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
