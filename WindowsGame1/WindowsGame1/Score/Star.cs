using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1.Score
{
    public class Star : ScourceStar 
    {
        public Texture2D ImageStar,Pixel;
        public Vector2 Po;
        public bool Score = false;
        Random r = new Random();
        public int RANDOM;
        public Rectangle ST,Test1;
        public Star()
        {
            RANDOM = r.Next(74, 400);
            Po = new Vector2(800, RANDOM);
            ImageStar = Static.CONTENT.Load<Texture2D>("StarS/starGold");
            Pixel = Static.CONTENT.Load<Texture2D>("Rect");
        }
        //Star Move
        public Rectangle Bound
        {
            get { return new Rectangle((int)Po.X, (int)Po.Y, 39/*41*/, 38/*43*/); }
            set { }
        }

        public override void Update()
        {

            this.Po.X = this.Po.X -2.5f;
            //     ST = new Rectangle((int)Po.X, (int)Po.Y, ImageStar.Width,ImageStar.Height);
            //     Test1 = new Rectangle((int)Po.X, (int)Po.Y, ImageStar.Width, ImageStar.Height);
            base.Update();
        }
      
        // Draw Star
        public  override void Draw()
        {                     
              Static.SPRITEBATCH.Draw(ImageStar, this.Bound, Color.White);
              // Static.SPRITEBATCH.Draw(ImageStar, this.Bound, new Color(1f, 0f, 0f, 0.3f));
                base.Draw();
        }
        
    }
}
