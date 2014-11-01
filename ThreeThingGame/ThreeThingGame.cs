#region Using Statements
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using System;
using System.Collections.Generic;
#endregion

namespace ThreeThingGame
{
    /// <summary>
    /// This is a game, its probably gonna be awful, but its gonna be good because it's so bad! - joe
    /// </summary>
    public class ThreeThingGame : Game
    {
        enum GameState
        {
            Playing,
            Paused,
            Menu
        }
        GameState gameState = new GameState();

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Items for setting up the virtual screen space, it is then upscaled/downscaled
        //to the resoloution of the display
        float scaleX;
        float scaleY;
        public const int VirtualScreenWidth = 1920;
        public const int VirtualScreenHeight = 1080;
        Vector3 screenScale;
        //Everything is done in relation to a 1080p res

        //Key & mouse state
        public KeyboardState currentKeyState;
        public KeyboardState prevKeyState;
        public MouseState prevMouseState;
        public MouseState currentMouseState;

        //Background
        Background background;

        //Player
        Player player;

        Robot robot;

        List<Robot> robotsList = new List<Robot>();


        //Constructor
        public ThreeThingGame()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            //This is the actual resolution of the display
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            robotsList.Add(robot);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            gameState = GameState.Playing; //means initial state is 'playing'

            //Gets resolution difference for matrix calculations
            scaleX = (float)GraphicsDevice.Viewport.Width / (float)VirtualScreenWidth;
            scaleY = (float)GraphicsDevice.Viewport.Height / (float)VirtualScreenHeight;
            screenScale = new Vector3(scaleX, scaleY, 1.0f);

            //Background setup
            background = new Background(true, new Rectangle(0, 0, 1920, 1080), Content.Load<Texture2D>("IMG/background_highres_default"));

            //Player setup
            player = new Player(true, new Rectangle(600, 800, 64, 120), Content.Load<Texture2D>("IMG/player"));

            robot = new Robot(true, new Rectangle(400, 800, 64, 120), Content.Load<Texture2D>("IMG/robot1"));
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            prevKeyState = currentKeyState; //used for comparison, has previous ticks keypress
            currentKeyState = Keyboard.GetState(); //gets current keypress
            prevMouseState = currentMouseState;
            currentMouseState = Mouse.GetState();

            //this multiplies the MouseStates by the virtual scale so button presses are in the correct position, m stands for mouse
            var mOldStateX = (int)(prevMouseState.X / scaleX);
            var mOldStateY = (int)(prevMouseState.Y / scaleY);
            var mStateX = (int)(currentMouseState.X / scaleX);
            var mStateY = (int)(currentMouseState.Y / scaleY);

            if (gameState == GameState.Playing)
            {
                //All updating logic for the game in play mode is done here

                //Player movement
                if (currentKeyState.IsKeyDown(Keys.A))
                {
                    player.position.X -= player.movespeed;
                }
                if (currentKeyState.IsKeyDown(Keys.D))
                {
                    player.position.X += player.movespeed;
                }
                if (currentKeyState.IsKeyDown(Keys.W) || currentKeyState.IsKeyDown(Keys.Space))
                {
                    player.Jump();
                }

                player.ApplyPhysics();

                /*foreach (Robot robot in robotsList)
                {
                    robot.ApplyGravity();
                }*/

                

                if ((robot.position.X > player.position.X && robot.position.X < player.position.X + robot.alertDistance ) ||
                    (robot.position.X < player.position.X && robot.position.X > player.position.X - robot.alertDistance))
                {
                    // Robot is alerted. 
                    if (player.position.X > robot.position.X)
                    {
                        robot.position.X = robot.position.X + robot.movespeed;
                    }
                    if (player.position.X < robot.position.X)
                    {
                        robot.position.X = robot.position.X - robot.movespeed;
                    }
                }


            }

            //Exit Program
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //Does matrix multiplication to actually upscale/downscale display
            var scaleMatrix = Matrix.CreateScale(screenScale);
            spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, scaleMatrix);

            if (gameState == GameState.Playing)
            {
                //All draw calls for when game is in 'Playing' mode

                //Draw background
                if (background.isActive == true)
                {
                    spriteBatch.Draw(background.texture, background.position, new Rectangle(0, 0, 1920, 1080), Color.White);
                }
                if (player.isActive == true)
                {
                    spriteBatch.Draw(player.texture, player.position, new Rectangle(0, 0, 280, 385), Color.White);
                }

                if (robot.isActive == true)
                {
                    spriteBatch.Draw(robot.texture, robot.position, Color.White);
                }

            }

            base.Draw(gameTime);
            spriteBatch.End();
        }
    }
}
