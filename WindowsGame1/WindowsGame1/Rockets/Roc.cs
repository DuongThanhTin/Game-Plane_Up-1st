using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1.Rockets
{
    
        public abstract class Roc
        {
            public virtual void LoadContent() { }
            public virtual void Update() { }//GameTime gameTime) { }
            public virtual void Draw() { }
        }
    
}
