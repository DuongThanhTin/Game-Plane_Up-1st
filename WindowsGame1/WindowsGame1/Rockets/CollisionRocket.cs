using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1.Rockets
{
    public class CollisionRocket: Roc
    {

        public List<Rockets.Rocket> ROCKET;
        Plane.ImagePlane _plane;
        public float EX;
        public int timer1 = 0;
        public bool start1 = false;
        Screen.GameScreens GS;
        Screen.ScrollScreen SS;
        public List<Score.Star> S;
        public CollisionRocket()
        { }
        public void Reset()
        {
            _plane = new Plane.ImagePlane();
            GS = new Screen.GameScreens();
            SS = new Screen.ScrollScreen();
            GS.Reset_1();     
            GS.score = 0;
        }
        //public override void Update()
        //{
        //    if(
        //    base.Update();
        //}
        //public override void LoadContent()
        //{
        //    SS = new Screen.ScrollScreen();
        //    SS.LoadContent();
        //    base.LoadContent();
        //}
        //public  override void Update()//GameTime gameTime)
        //{
        //    AddRocket();

        //    if (!_plane.dead)
        //    {

        //        for (int j = ROCKET.Count - 1; j > -1; j--)
        //        {
        //            ROCKET[j].Update();

        //            if (_plane.Bound.Intersects(ROCKET[j].Bound))
        //            {
        //                GS.score--;
        //                _plane.dead = true;

        //            }

        //        }
        //    }
        //    if(_plane.dead == true)
        //    {
        //        this.Reset();
        //    }
        //    base.Update();
        //}
        //public override void Draw()
        //{
        //    foreach (var tem in ROCKET)
        //    {
        //        tem.Draw();
        //    }
        //    base.Draw();
        //}
        //public void Reset()
        //{

        //    EX = 0;
        //    timer1 = 0;
        //}
        //public void AddRocket()
        //{
        //    //Thời Gian Xuất hiện RocKEt
        //    EX += (float)Static.GAMETIME.ElapsedGameTime.TotalMilliseconds;
        //    if (EX > 2000)
        //    {
        //        ROCKET.Add(new Rockets.Rocket());
        //        EX = 0;
        //    }
        //}

    }
}
