using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1.Screen
{
    public class GameScreens: Screens
    {
     
        public Texture2D backgrounds1;
        public Texture2D backgrounds2;
        public Texture2D Bronze, Silver, Gold;
        Random r = new Random();
      
        //Score User
        public int ra, score=0;
        Screen.ScrollScreen Sc;
        public List<Score.Star> STAR;
        public Score.Star s;
        public float EX, Delay = 3000f,Long,Short,Long2,Short2;
        public bool A = false;
        public bool K = false;
        public SpriteFont Font;
        Plane.ImagePlane _plane1;
        Rockets.CollisionRocket  CR;
        public List<Rockets.Rocket> ROCKET;
        public int n;
        public Vector2 D,B;
//        public bool Collided { get; private set; }

        public GameScreens()
        {
             ra = r.Next(0,2);
        }
        public override void LoadContent()
        {
            backgrounds1 = Static.CONTENT.Load<Texture2D>("background");
            backgrounds2 = Static.CONTENT.Load<Texture2D>("BG1223");
            Bronze = Static.CONTENT.Load<Texture2D>("medalBronze");
            Silver = Static.CONTENT.Load<Texture2D>("medalSilver");
            Gold = Static.CONTENT.Load<Texture2D>("medalGold");
            Sc = new Screen.ScrollScreen();
            STAR = new List<Score.Star>();
            s = new Score.Star();
            CR = new Rockets.CollisionRocket();
            Font = Static.CONTENT.Load<SpriteFont>("font");
            _plane1 = new Plane.ImagePlane();
       
            Sc.LoadContent();
            base.LoadContent();
        }
        //Đang Làm Loading......
  
        public override void Update(GameTime gametime)
        {
       
           // CR.Update();
            AddStar();
          
           for (int i = STAR.Count - 1; i > -1; i--)
        //  for(int i=0; i<STAR.Count;i++)
            {

                STAR[i].Update();
                //Increase Score And Collision 
                if (!STAR[i].Score)
                { 
                    if (_plane1.Bound.Intersects(/*intersectingRectangle))*/STAR[i].Bound))
                    {
               
                       STAR[i].Score = true;
                    }
               
                }
                if (STAR[i].Score)
                {                 
                    score++; 
                    STAR.RemoveAt(i);
                }

            }
            Sc.Update();
            // s.Update();     
            // Star Move
            _plane1.Update(gametime);
            base.Update(gametime);
        }

        //TEST_COLLISION


        // Star Appear
        public void AddStar()
        {

            EX += (float)Static.GAMETIME.ElapsedGameTime.TotalMilliseconds;
            if (EX > Delay)
            {            
                STAR.Add(new Score.Star());
                EX = 0;
            }
        }
        public void Reset_1()
        {
            STAR = new List<Score.Star>();
            STAR.Add(new Score.Star());
           
        }
        public override void Draw()
        {
            Static.SPRITEBATCH.Begin(/*SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.LinearWrap, null, null*/);
          
            switch (ra)
            {
                case 0:
                Static.SPRITEBATCH.Draw(this.backgrounds1, Vector2.Zero, Color.White);
                break;
                case 1:                                  
                Static.SPRITEBATCH.Draw(this.backgrounds2, Vector2.Zero, Color.White);
                break;
                case 2:
                Static.SPRITEBATCH.Draw(this.backgrounds1, Vector2.Zero, Color.White);
                break;
            }
            
            
            foreach (var item in STAR)
            {
             
                        item.Draw();
                   
            }
            Sc.Draw();
            Static.SPRITEBATCH.DrawString(this.Font, "Score: " + this.score.ToString(), new Vector2(10, 0), Color.Aquamarine);
            if (_plane1.dead == true)
            {
                Static.SPRITEBATCH.DrawString(this.Font, "Score: " + this.score.ToString(), new Vector2(350, 200), Color.Chocolate);
                if (this.score < 3)
                {
                    Static.SPRITEBATCH.Draw(this.Bronze, new Rectangle(400, 250, 59, 60), Color.White);
                }
                else if (3 <= this.score && this.score >= 6)
                {
                    Static.SPRITEBATCH.Draw(this.Silver, new Rectangle(400, 250, 59, 60), Color.White);
                }
                else if (this.score > 6)
                {
                    Static.SPRITEBATCH.Draw(this.Gold, new Rectangle(400, 250, 59, 60), Color.White);
                }
            }
            
            // s.Draw();
            Static.SPRITEBATCH.End();
            base.Draw();

        }

        
    }
}
