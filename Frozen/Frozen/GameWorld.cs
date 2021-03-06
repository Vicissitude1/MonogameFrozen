﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;


namespace Frozen
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    class GameWorld : Game
    {


        
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        public float deltaTime { get; private set; }
        public List<GameObject> gos = new List<GameObject>();
        private static GameWorld instance;
        private Texture2D background;
        private Rectangle destRect;
        private Rectangle sourceRectangle;
        public Floor floor;
        public Song song;
        


        int i = 0;


        public static GameWorld Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameWorld();
                }
                return instance;
            }
        }

        private GameWorld()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            

            gos = new List<GameObject>();

            Director director = new Director(new PlayerBuilder());
            gos.Add(director.Construct(new Vector2(0, 0)));

            director = new Director(new EnemyBuilder());
            gos.Add(director.Construct(new Vector2(500, 1000)));

            Camera.Instance.Zoom = 1.0f;

            floor = new Floor();
            floor.Initialize(Content);
            
             
           

            //go.Add(director.Construct(new Player(, 50));

            // player = director.Construct(new Player()) 
            //director = new Director(new EnemyBuilder());
            //gos.Add(director.Construct(Vector2.Zero));
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
            background = Content.Load<Texture2D>("background");
            destRect = new Rectangle((int)(-GraphicsDevice.Viewport.Width * 0.5f), (int)(-GraphicsDevice.Viewport.Height * 0.5f), GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            sourceRectangle = new Rectangle(0, 0, 213, 120);

            //SFX.Instance.LoadContent(this.Content);

            this.song = Content.Load<Song>("baggrundstest");
            MediaPlayer.Play(song);
            MediaPlayer.IsRepeating = true;

            MediaPlayer.MediaStateChanged += MediaPlayer_MediaStateChanged;

            foreach (GameObject go in gos)
            {
                go.LoadContent(this.Content);

            }
             // TODO: use this.Content to load your game content here
        }


        public void MediaPlayer_MediaStateChanged(object sender, System.EventArgs e)
        {
            // 0.0f is silent, 1.0f is full volume
            MediaPlayer.Volume -= 0.1f;
            MediaPlayer.Play(song);
        }
        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            for (int i = 0; i < gos.Count; i++)
            {
                gos[i].Update();
            }
                

         

            //Camera.Instance.Rotation += 0.01f;

            Camera.Instance.Pos = gos[0].transform.Position;

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {

           
            
            GraphicsDevice.Clear(Color.CornflowerBlue);


            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend, null,null,null,null,Camera.Instance.get_transformation(GraphicsDevice));
            foreach (GameObject go in gos)
            {
                go.Draw(spriteBatch);

            }
         
            spriteBatch.Draw(background, destRect, new Rectangle(i, 0, sourceRectangle.Width, sourceRectangle.Height), Color.BlanchedAlmond, 0f, Vector2.Zero,  SpriteEffects.None, 0f);
            

            floor.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
