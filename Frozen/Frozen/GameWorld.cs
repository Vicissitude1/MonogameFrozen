using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Frozen
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameWorld : Game
    {

        

        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        public float deltaTime { get; private set; }
        private List<GameObject> gos = new List<GameObject>();
        private static GameWorld instance;
        private Texture2D background;
        private Rectangle mainFrame;


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
            gos.Add(director.Construct(Vector2.Zero));

            director = new Director(new EnemyBuilder());
            gos.Add(director.Construct(Vector2.Zero));

            Camera.Instance.Zoom = 1.0f;
             

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
            mainFrame = new Rectangle((int)(-GraphicsDevice.Viewport.Width * 0.5f), (int)(-GraphicsDevice.Viewport.Height * 0.5f), GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);

            foreach (GameObject go in gos)
            {
                go.LoadContent(this.Content);

            }
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

            //Camera.Instance.Pos = gos[0].transform.Position;

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {

           

            GraphicsDevice.Clear(Color.CornflowerBlue);


            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, null,null,null,null,Camera.Instance.get_transformation(GraphicsDevice));
            foreach (GameObject go in gos)
            {
                go.Draw(spriteBatch);

            }
            spriteBatch.Draw(background, mainFrame, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
