using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace WindowsGame1
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
      
        Screen.GameScreens currentScreens;
        Screen.ScrollScreen ScrollScreens; // Scroll Screen
        Plane.ImagePlane _plane;
        Plane.ControlPlane _Control = new Plane.ControlPlane();
        KeyboardState _ControlKey = Keyboard.GetState();
        public bool gameover = false;
        MouseState _ControlM = Mouse.GetState();
        Rockets.CollisionRocket CL;
        public List<Rockets.Rocket> ROCKET;
        int timer = 0;
        public float EX;
        public int score;
        public List<Score.Star> STAR;
        public bool start = false;
        Player P;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            Static.CONTENT = Content; //Muốn sử dụng trong class Static thì phải Static.CONTENT
            Static.GRAPHICSDEVICE = GraphicsDevice;
            Static.SPRITEBATCH = spriteBatch;
            
            this.graphics.PreferredBackBufferWidth = Static._Width; // Kích thước của Form
            this.graphics.PreferredBackBufferHeight = Static._Height; // Kích thước của Form
            
            Player P = new Player();
            IsMouseVisible = true;
            
        }

        
        protected override void Initialize()
        {


            base.Initialize();
        }


        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Static.SPRITEBATCH =  new SpriteBatch(GraphicsDevice); // Muốn sử dụng trong class Static thì phải Static.SPRITEBATCH
            ScrollScreens = new Screen.ScrollScreen();
            currentScreens = new Screen.GameScreens();
             _plane = new Plane.ImagePlane();
            CL = new Rockets.CollisionRocket();
            P = new WindowsGame1.Player();
            _Control.LoadContent();
            CL.LoadContent();
            //   ScrollScreens.LoadContent();
            currentScreens.LoadContent(); //Phải vào LoadContent thì mới có thể ra ảnh được
        //    Reset_2();
            _plane.LoadContent();
            ROCKET = new List<Rockets.Rocket>(); //Add Rocket
       
                
            }
        

        //Collision
 

        protected override void UnloadContent()
        {
        }


        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            Static.GAMETIME = gameTime;
         
            CL.timer1 += (int)gameTime.ElapsedGameTime.Milliseconds;
            AddRocket();
            if (!_plane.dead)//&& this.timer >=3000)
            {
                if (CL.timer1>1000)
                {
                this.start = true;
                }
                if (this.start)
                {
                    ScrollScreens.Update();
                    currentScreens.Update(gameTime);
                    Static.PLAYER.Update();
                    _plane.Update(gameTime);
                    _Control.Update(gameTime);
                    //   this.timer += gameTime.ElapsedGameTime.Milliseconds;

                    // Collision Rocket


                    // this.start = true;
                    //  this.timer = 0;
                    for (int j = ROCKET.Count - 1; j > -1; j--)
                 {
                    ROCKET[j].Update();

                        if (_plane.Bound.Intersects(ROCKET[j].Bound))
                        {
                            _plane.dead = true;
                            gameover = true;
                            
                        }
                         if (_plane.dead && Static.PLAYER.isKeyPress(Microsoft.Xna.Framework.Input.Keys.Space))//isMousePressed(Microsoft.Xna.Framework.Input.MouseState))
                              {
                //gameover = false;
                //_plane.dead = false;
                           this.Reset_2();
                             _plane.dead = false;
                               }
                           }
         
                }
          
            }
          
             

            #region 
            //elsaped += (float)gameTime.ElapsedGameTime.Milliseconds;
            //if (elsaped >= delay)
            //{
            //    if (frames >= 1)
            //    {
            //        frames = 0;
            //    }
            //    else
            //    {
            //        frames++;
            //    }
            //    elsaped = 0;
            //}
            #endregion
            //Ham` Nay` phai? co Gamer thi moi co the su dung ScrollScreens.Update(GamerPosition);

           base.Update(gameTime);
        }
        public  void Reset_2()
        {
            CL.Reset();
            ROCKET = new List<Rockets.Rocket>();
            ROCKET.Add(new Rockets.Rocket());
            STAR = new List<Score.Star>();
            STAR.Add(new Score.Star());
            _plane.dead = false;
        }

        public void AddRocket()
        {

            EX += (float)Static.GAMETIME.ElapsedGameTime.TotalMilliseconds;
           
            if (EX > 1700)
            {
                EX = 0;
                ROCKET.Add(new Rockets.Rocket());
                
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            // Scroll Screen
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend,SamplerState.LinearWrap , null, null);
            //spriteBatch.Draw(background, Vector2.Zero, Color.White);
       
            _Control.Draw();
        //    currentScreens.Draw();
        
            CL.Draw();
          
            currentScreens.Draw();
            

            #region
            //switch (frames)
            //{
            //    case 0:
            //        spriteBatch.Draw(Static.plane1, new Rectangle(100, 200, 88, 73), Color.White);
            //        break;
            //    case 1:
            //        spriteBatch.Draw(Static.plane2, new Rectangle(100, 200, 88, 73), Color.White);
            //        break;
            //    case 2:
            //        spriteBatch.Draw(Static.plane3, new Rectangle(100, 200, 88, 73), Color.White);
            //        break;
            //}
            #endregion
            foreach (var tem in ROCKET)
            {
                tem.Draw();
            }
            _plane.Draw();
            spriteBatch.End();
           

            base.Draw(gameTime);
        }
        
    }
}
