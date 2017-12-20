using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using System.Collections.Generic;
using System.Diagnostics;

namespace GameDevelopment
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        int windowWidth, windowHeight;
        Texture2D Jumper, Background, GameBlock;
        Side _UserControl;
        Player player;
        Block block;



        public Rectangle ground;

        List<ICollide> collideObjecten;




        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.IsFullScreen = true;

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

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // add the sprites
            Jumper = Content.Load<Texture2D>("Jumper");
            Background = Content.Load<Texture2D>("Background");
            GameBlock = Content.Load<Texture2D>("Block");



            windowWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            windowHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

            player = new Player(Jumper, windowWidth, windowHeight);

            ground = new Rectangle(0, (int)windowHeight-100, (int)windowWidth, 100);
            
            block = new Block(GameBlock, windowWidth);

            collideObjecten = new List<ICollide>();

            collideObjecten.Add(block);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        private bool CheckCollision()
        {

            if (player.GetCollisionRectangle().Intersects(ground))
                return true;

            for (int i = 0; i < collideObjecten.Count; i++)
            {
                if (player.GetCollisionRectangle().Intersects(collideObjecten[i].GetCollisionRectangle()))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                Exit();

            _UserControl = (new UserControl(windowWidth)).GetTap();

            if (CheckCollision() && player.isJumping)
            {
                player.isCollide = true;
            }

           

            // TODO: Add your update logic here
           

            player.Update(_UserControl);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            spriteBatch.Draw(Background, new Vector2(0, 0), new Rectangle(0, 2760, windowWidth, windowHeight), Color.White);
            block.Draw(spriteBatch);
            player.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
