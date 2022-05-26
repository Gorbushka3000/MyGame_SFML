using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace MyGame
{
    public class Player : Transformable, Drawable
    {
        public const float PlayerMoveSpeed = 4f;
        public const float PlayerMoveSpeedAcceleration = 0.2f;
        public Vector2f StartPosition;
        RectangleShape rect;
        RectangleShape rectDirection;
        Vector2f velocity;
        Vector2f move;
        World world;

        public int Direction
        {
            get
            {
                int dir = Scale.X >= 0 ? 1 : -1;
                return dir;
            }
            set
            {
                int dir = value >= 0 ? 1 : -1;
                Scale = new Vector2f (dir, 1);
            }
        }
        public Player(World world)
        {
            rect = new RectangleShape(new Vector2f(Tile.TileSize * 1.5f, Tile.TileSize * 2.8f));
            rect.Origin = new Vector2f(rect.Size.X / 2, 0);

            rectDirection = new RectangleShape(new Vector2f(50, 3));
            rectDirection.FillColor = Color.Red;
            rectDirection.Position = new Vector2f(0, rect.Size.Y / 2 - 1);
            
            this.world = world;
        }

        public void Spawn()
        {
            Position = StartPosition;
        }
        public void Update()
        {
            updatePhysics();
            updateMove();

            Position += velocity;
        }

        private void updateMove()
        {
            bool isMoveLeft = Keyboard.IsKeyPressed(Keyboard.Key.A);
            bool isMoveRight = Keyboard.IsKeyPressed(Keyboard.Key.D);
            bool isMove = isMoveLeft || isMoveRight;

            if (isMove)
            {
                if(isMoveLeft)
                {
                    move.X -= PlayerMoveSpeedAcceleration;
                    Direction = -1;
                }
                else if (isMoveRight)
                {
                    move.X += PlayerMoveSpeedAcceleration;
                    Direction = 1;
                }
            }
        }

        private void updatePhysics()
        {
            bool isFall = true;

            velocity += new Vector2f(0, 0.15f);

            int pX = (int)((Position.X - rect.Origin.X + rect.Size.X / 2) / Tile.TileSize);
            int pY = (int)((Position.Y + rect.Size.Y)/Tile.TileSize);
            Tile tile  = world.GetTile(pX, pY);

            if (tile != null)
            {
                Vector2f nextPos = Position + velocity - rect.Origin;
                FloatRect playerRect = new FloatRect(nextPos, rect.Size);
                FloatRect tileRect = new FloatRect(tile.Position, new Vector2f(Tile.TileSize, Tile.TileSize));

                isFall = !playerRect.Intersects(tileRect);
            }

            if (!isFall)
            {
                velocity.Y = 0;
            }
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform *= Transform;
            target.Draw(rect, states);
            target.Draw(rectDirection, states);
        }
    }
}
