using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1.Plane
{
    public abstract class Planes
    {

        public virtual void LoadContent() { }
        public virtual void Update(GameTime gameTime) { }
        public virtual void Draw() { }
        public virtual void Ran() { }
        
        public virtual void Control(GameTime gameTime) { }
        public Rectangle RECTANGLE ;


    }
}
