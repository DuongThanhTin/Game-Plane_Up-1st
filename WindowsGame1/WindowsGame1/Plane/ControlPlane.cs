using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace WindowsGame1.Plane
{
    public class ControlPlane : Planes
    {
        
        public override void LoadContent()
        {
            base.LoadContent();
        }
        public override void Update(GameTime gameTime)
        {
            

            base.Update(gameTime);
        }
      
        public override void Draw()
        {
            Static.SPRITEBATCH.Begin();

            Static.SPRITEBATCH.End();
            base.Draw();
        }
    }
}
