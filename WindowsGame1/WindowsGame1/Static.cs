using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1
{
    public class Static
    {
        public static int _Width = 800;
        public static int _Height = 480;
        public static Player PLAYER;
        public static ContentManager CONTENT;
        public static SpriteBatch SPRITEBATCH;
        public static Texture2D T; //planeG1, planeG2, planeG3;
        public static GameTime GAMETIME;
        public static GraphicsDevice GRAPHICSDEVICE;
        public static Vector2 Position;
        
        //public static Rectangle RECTANGLE = new Rectangle((int)Position.X, (int)Position.Y, 88, 73);
    }
}
