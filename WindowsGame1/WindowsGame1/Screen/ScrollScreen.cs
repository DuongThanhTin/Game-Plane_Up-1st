using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1.Screen
{
    class ScrollScreen 
    {
        #region
        //Vector2 Position;
        //Matrix viewMatrix;
        //public Matrix ViewMatrix
        //{
        //    get { return viewMatrix; }
        //}
        //public  int ScreenWidth
        //{
        //    get { return GraphicsDeviceManager.DefaultBackBufferWidth; }
        //}
        ////public int ScreenHeight
        ////{
        ////    get { return GraphicsDeviceManager.DefaultBackBufferHeight; }
        ////}
        //public void Update(Vector2 GamerPosition)
        //{
        //    Position.X = GamerPosition.X - (ScreenWidth / 2);
        //   // Position.Y = GamerPosition.Y - (ScreenHeight / 2);
        //    if (Position.X < 0)
        //        Position.X = 0;
        //    viewMatrix = Matrix.CreateTranslation(new Vector3(-Position, 0));

        //}
        #endregion
        public float AT = 10;
        public double AE = 0;
        public int DX = 0 ,DK=50;
        public Texture2D T,T1,T2,T3,T4,T5,T6;
        public bool can = false;
        public Rectangle POSITION,POSITION1, POSITION2;
        public Vector2 P; public Texture2D Ready , TapClick;
        Rectangle r1;
        public ScrollScreen()
        {
            this.POSITION = new Rectangle(0,410,800,71);
            this.POSITION1 = new Rectangle(0, 410, 800, 71);
            this.POSITION2 = new Rectangle(0, 0, 800, 71);
           
            P = new Vector2(500, 71);
        }
        public void LoadContent()
        {
            this.T = Static.CONTENT.Load<Texture2D>("Ground/groundDirt");
            this.T2 = Static.CONTENT.Load<Texture2D>("Ground/ReversegroundDirt");
            this.T1 = Static.CONTENT.Load<Texture2D>("Ground/azx");
            this.T3 = Static.CONTENT.Load<Texture2D>("Ground/123");
            this.T4 = Static.CONTENT.Load<Texture2D>("Ground/1234");
            this.T5 = Static.CONTENT.Load<Texture2D>("Ground/groundGrass1");
            this.T6 = Static.CONTENT.Load<Texture2D>("Ground/groundGrass2");
            
            //Hình Ready
            Ready = Static.CONTENT.Load<Texture2D>("textGetReady");
           //Hinhf TapClick
           TapClick = Static.CONTENT.Load<Texture2D>("tapTick");
        }
        int D_Ready= 100;
        int D_Tap = 300;
        public void Update()
        {

            AE += Static.GAMETIME.ElapsedGameTime.TotalMilliseconds;
            if (AE > 10) //Di Chuyen nhanh cham ground
            {
                this.DX += 4;
                D_Ready -= 4;
                D_Tap -= 4;
                if (DX > 100000)
                {
                    D_Ready=100;
                    D_Tap = 300;
                    DX = 0;
                    AE = 0;
                    can = true;
                }
         //       if()
            }

        }
        public void Draw()
        {
            //Static.SPRITEBATCH.Draw(this.T, this.POSITION, Color.White);
            AT += (float)Static.GAMETIME.ElapsedGameTime.TotalMilliseconds;

            // Static.SPRITEBATCH.Draw(this.T1, this.POSITION1, new Rectangle(DK, 0, 500, 71), Color.White);
            Static.SPRITEBATCH.Draw(this.Ready, new Rectangle(D_Ready, 100,400,73) , Color.White);
            Static.SPRITEBATCH.Draw(this.TapClick, new Rectangle(D_Tap, 200, 59, 59), Color.White);
            Static.SPRITEBATCH.Draw(this.T5, this.POSITION, new Rectangle(DX, 0, 500, 71), Color.White);
            Static.SPRITEBATCH.Draw(this.T6, this.POSITION2, new Rectangle(DX, 0, 500, 71), Color.White);
            
        }
    }
}
