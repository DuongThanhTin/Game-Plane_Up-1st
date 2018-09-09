using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1
{
    public class Player
    {
        private KeyboardState _ControlKey, key;// = Keyboard.GetState();
        private MouseState _ControlM;
        private MouseState  M; //= Mouse.GetState();
       
        public Player()
        {
            Static.PLAYER = this;
        }

        public void Update()
        {
            if (_ControlKey != null|| _ControlM !=null )
            {
                key = _ControlKey;
                _ControlKey = Keyboard.GetState();
                _ControlM = Mouse.GetState();
            }
        }
        public bool isKeyPressed(Keys k)
        {
            return (/*(key.IsKeyUp(k) && _ControlKey.IsKeyDown(k)) ||*/ (_ControlM.LeftButton == ButtonState.Pressed && M.LeftButton == ButtonState.Released));
        }
        public bool isKeyPress(Keys k)
        {
            return ((key.IsKeyUp(k) && _ControlKey.IsKeyDown(k)));
        }
        public bool isMouseRelease(MouseState m)
        {
            return (_ControlM.LeftButton == ButtonState.Pressed && M.LeftButton == ButtonState.Released);
        }
        public bool isKeyRelease(Keys k)
        {
            return (/*(key.IsKeyUp(k) && _ControlKey.IsKeyDown(k) ) ||*/ (_ControlM.LeftButton == ButtonState.Pressed&& M.LeftButton == ButtonState.Released));
        }

    }
}
