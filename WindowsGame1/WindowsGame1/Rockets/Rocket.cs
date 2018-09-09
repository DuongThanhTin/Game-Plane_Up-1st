using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1.Rockets
{
    public class Rocket:Roc
    {   
        public Texture2D RocKet, Pixel;
        public Vector2 POSIT;
        public int rand;
        Random r = new Random();
        public Rocket()
        {
            rand = r.Next(74, 380);
            POSIT = new Vector2(1300, rand);
            RocKet = Static.CONTENT.Load<Texture2D>("Rocket");
            Pixel = Static.CONTENT.Load<Texture2D>("Rect");
        }
        public Rectangle Bound
        {
            get { return new Rectangle((int)POSIT.X, (int)POSIT.Y, 38, 38); }
            set { }
        }
        public override void Update()
        {
            this.POSIT.X -= 2f;
            base.Update();
        }
        public override void Draw()
        {
            Static.SPRITEBATCH.Begin();
            Static.SPRITEBATCH.Draw(RocKet, new Rectangle((int)POSIT.X, (int)POSIT.Y, 47, 47), Color.White);
            //Static.SPRITEBATCH.Draw(RocKet, this.Bound, new Color(1f, 0f, 0f, 0.3f));
            Static.SPRITEBATCH.End();
            base.Draw();
        }
        
            
        
    
    }
}
