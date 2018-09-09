using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1.Screen
{
    public abstract class Screens
    {
        public virtual void LoadContent() { }
        public virtual void Update(GameTime gametime) { }
        public virtual void Draw() { }
        

    }
}
