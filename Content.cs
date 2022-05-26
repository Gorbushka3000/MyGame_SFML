using SFML.Graphics;

namespace MyGame
{
    public class Content
    {
        public const string CONTENT_DIR = "C:\\Users\\glebd\\Desktop\\Learn_C#\\MyGame\\Content\\";
        public static Texture texTile0;
        public static Texture texTile1;
        public static void Load()
        {
            texTile0 = new Texture(CONTENT_DIR + "Texture\\Tiles_0.png");
            texTile1 = new Texture(CONTENT_DIR + "Texture\\Tiles_2.png");
        }
    }
}
