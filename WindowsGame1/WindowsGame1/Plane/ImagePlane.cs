using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1.Plane
{
    public class ImagePlane : Planes
    {
        public Texture2D planeG1, planeG2, planeG3;
        public Texture2D planeR1, planeR2, planeR3;
        public Texture2D planeY1, planeY2, planeY3;
        public Texture2D Bronze, Silver, Gold;
        public Texture2D text, Pixel ,GameOver;
        Screen.GameScreens gs;
        //Pixel la HCN xung quannh may bay de xac dinh va cham
        float elsaped, delay = 200f;
        int frames = 0;
        int ran;
        public bool start = false;
        public bool dead = false;
        public bool k = false;
        KeyboardState _ControlKey = Keyboard.GetState();
        MouseState _ControlM = Mouse.GetState();
        public float Speed = 2f, Ro = 0f, i = 200f;
        public int jumpTime = 500;
        public double jump = 0;
        public bool canjump = true;
        public Vector2 P;
        public Rectangle ST, Test1, Test2;
        Random r = new Random();
        public float Ca, Da;
        Screen.ScrollScreen ss;
        int sc;
        public ImagePlane()
        {
            P = new Vector2(P.X, P.Y);
            //Static.Position.X = 100;
            P.X = 100;
            
            ran = r.Next(1,6);
            //Static.Position.Y = 200 ;
            P.Y = 200;
           
        }

        public override void LoadContent()
        {

            #region
            planeG1 = Static.CONTENT.Load<Texture2D>("planeGreen1");
            planeG2 = Static.CONTENT.Load<Texture2D>("planeGreen2");
            planeG3 = Static.CONTENT.Load<Texture2D>("planeGreen3");
            planeR1 = Static.CONTENT.Load<Texture2D>("RedPlane/planeRed1");
            planeR2 = Static.CONTENT.Load<Texture2D>("RedPlane/planeRed2");
            planeR3 = Static.CONTENT.Load<Texture2D>("RedPlane/planeRed3");
            planeY1 = Static.CONTENT.Load<Texture2D>("YellowPlane/planeYellow1");
            planeY2 = Static.CONTENT.Load<Texture2D>("YellowPlane/planeYellow2");
            planeY3 = Static.CONTENT.Load<Texture2D>("YellowPlane/planeYellow3");
            Bronze = Static.CONTENT.Load<Texture2D>("medalBronze");
            Silver = Static.CONTENT.Load<Texture2D>("medalSilver");
            Gold = Static.CONTENT.Load<Texture2D>("medalGold");
            gs = new Screen.GameScreens();
            gs.LoadContent();
            ss = new Screen.ScrollScreen();
            ss.LoadContent();
            //Hinh Quanh May Bay
            Pixel = Static.CONTENT.Load<Texture2D>("Rect");
            #endregion
            //Hinh GameOver
            GameOver = Static.CONTENT.Load<Texture2D>("textGameOver");
            base.LoadContent();
        }
        public override void Update(GameTime gameTime)
        {
            // Thay đổi Image
            elsaped += (float)gameTime.ElapsedGameTime.Milliseconds;
            if (elsaped >= delay)
            {
                if (frames >= 1)
                {
                    frames = 0;
                }
                else
                {
                    frames++;
                }
                elsaped = 0;
            }                   
            jump += Static.GAMETIME.ElapsedGameTime.TotalSeconds;
            Ro = (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (jump > jumpTime)
            {
                canjump = true;
                jump = 0;

            }
            if (( (Static.PLAYER.isKeyPressed(Keys.Space) || (_ControlKey.IsKeyDown(Keys.Space)) || _ControlM.LeftButton == ButtonState.Pressed)) && canjump)
            {
              
                Speed = -2;
                P.Y = P.Y - 5f;
            }
            if (((Static.PLAYER.isKeyRelease(Keys.Space) || (_ControlKey.IsKeyUp(Keys.Space)) || _ControlM.LeftButton == ButtonState.Released)) && canjump)
            {
                Speed = +1 ;
             P.Y =P.Y + 1f;
            }
         //   gs.Update(gameTime);
            P.Y += Speed;
            //Static.Position.Y += Speed;
           //ST = new Rectangle((int)P.X, (int)P.Y, 88, 73);
           RECTANGLE = new Rectangle((int)P.X, (int)P.Y, 88, 73);
           Test1 = new Rectangle((int)P.X,(int) P.Y, 88, 73);
            if (P.Y < 50 || P.Y > Static._Height - 130)
            {
         //       ss.DX = 0;
                dead = true;
                //P.Y = P.Y +100f;
            }
            base.Update(gameTime);
        }
        public Rectangle Bound
        {
            get { return new Rectangle((int)P.X, (int)P.Y, 82, 75); }
            set { }
        }
       
        public override void Draw()
        {
           Static.SPRITEBATCH.Begin();
           
            bool block = false;          
            
            #region

            //switch (ran)
            //{
            //    case 1:
            //    { 
            //        switch (frames)
            //        {
            //            case 0:
            //                Static.SPRITEBATCH.Draw(planeG1, new Rectangle(100, 200, 88, 73), Color.White);
            //                break;
            //            case 1:
            //                Static.SPRITEBATCH.Draw(planeG2, new Rectangle(100, 200, 88, 73), Color.White);
            //                break;
            //            case 2:
            //                Static.SPRITEBATCH.Draw(planeG3, new Rectangle(100, 200, 88, 73), Color.White);
            //                break;
            //        }

            //       }
            //        break;

            //    case 2:
            //     {
            //         switch (frames)
            //           {
            //        case 0:
            //            Static.SPRITEBATCH.Draw(planeR1, new Rectangle(100, 200, 88, 73), Color.White);
            //            break;
            //        case 1:
            //            Static.SPRITEBATCH.Draw(planeR2, new Rectangle(100, 200, 88, 73), Color.White);
            //            break;
            //        case 2:
            //            Static.SPRITEBATCH.Draw(planeR3, new Rectangle(100, 200, 88, 73), Color.White);
            //            break;
            //            }
            //     }
            //        break;
            //    case 3:
            //    {
            //            switch (frames)
            //            {
            //                case 0:
            //                    Static.SPRITEBATCH.Draw(planeY1, new Rectangle(100, 200, 88, 73), Color.White);
            //                    break;
            //                case 1:
            //                    Static.SPRITEBATCH.Draw(planeY2, new Rectangle(100, 200, 88, 73), Color.White);
            //                    break;
            //                case 2:
            //                    Static.SPRITEBATCH.Draw(planeY3, new Rectangle(100, 200, 88, 73), Color.White);
            //                    break;
            //            }
            //     }
            //            break;
            //        }   
            #endregion
            // Draw Plane
            #region
            if ((ran ==1 ||ran ==6) &&  block== false)
            {

                switch (frames)
                {
                    case 0:
                        Static.SPRITEBATCH.Draw(planeY1, new Rectangle((int)P.X, (int)P.Y, 88, 80), Color.White);
                        break;
                    case 1:
                        Static.SPRITEBATCH.Draw(planeY2, new Rectangle((int)P.X, (int)P.Y, 88, 80), Color.White);
                        break;
                    case 2:
                        Static.SPRITEBATCH.Draw(planeY3, new Rectangle((int)P.X, (int)P.Y, 88, 80), Color.White);
                        break;
                }
                        block = true;
            }
            if ((ran == 2||ran==4) &&  block == false)
            {
                switch (frames)
                {
                    case 0:
                        Static.SPRITEBATCH.Draw(planeR1, new Rectangle((int)P.X, (int)P.Y, 88, 80), Color.White);
                        break;
                    case 1:
                        Static.SPRITEBATCH.Draw(planeR2, new Rectangle((int)P.X, (int)P.Y, 88, 80), Color.White);
                        break;
                    case 2:
                        Static.SPRITEBATCH.Draw(planeR3, new Rectangle((int)P.X, (int)P.Y, 88, 80), Color.White);
                        break;
                }
                block = true;
            }
            if ((ran == 3 || ran == 5) && block == false)
            {
                switch (frames)
                {
                    case 0:
                        Static.SPRITEBATCH.Draw(planeG1, new Rectangle((int)P.X, (int)P.Y, 88, 80), Color.White);
                        break;
                    case 1:
                        Static.SPRITEBATCH.Draw(planeG2, new Rectangle((int)P.X, (int)P.Y, 88, 80), Color.White);
                        break;
                    case 2:
                        Static.SPRITEBATCH.Draw(planeG3, new Rectangle((int)P.X, (int)P.Y, 88, 80), Color.White);
                        break;
                }
                block = true;
            }
            //   Static.SPRITEBATCH.Draw(text, Test1, Color.Red);
            //     Static.SPRITEBATCH.Draw(Pixel,this.Bound, new Color(1f,0f,0f,0.3f));
            int sc = gs.score;
            #endregion
            if (dead == true)
            {
                Static.SPRITEBATCH.Draw(this.GameOver , new Rectangle(200, 100, 400, 73), Color.White);
          //     Static.SPRITEBATCH.DrawString(gs.Font, "Your Score: " + this.sc.ToString(), new Vector2(350, 200), Color.Chocolate);
                //if (gs.score < 3)
                //{
                //    Static.SPRITEBATCH.Draw(this.Bronze, new Rectangle(400, 250, 59, 60), Color.White);
                //}
                //else if (3 <= gs.score && gs.score >= 6)
                //{
                //    Static.SPRITEBATCH.Draw(this.Silver, new Rectangle(400, 250, 59, 60), Color.White);
                //}
                //else if (gs.score > 6)
                //{
                //    Static.SPRITEBATCH.Draw(this.Gold, new Rectangle(400, 250, 59, 60), Color.White);
                //}
            }
            Static.SPRITEBATCH.End();
            base.Draw();
        }
        public Vector2 Top { get { return new Vector2((int)P.X, (int)P.Y - 5); } }
        public Vector2 Bot { get { return new Vector2((int)P.X, (int)P.Y + 5); } }
    }
}
