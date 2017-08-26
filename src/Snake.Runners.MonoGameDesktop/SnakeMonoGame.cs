using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Snake.Framework.Geometry;
using Snake.Framework.Graphics;
using Snake.Game;
using Snake.Framework.Input;

namespace Snake.Runners.MonoGameDesktop
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class SnakeMonoGame : Microsoft.Xna.Framework.Game, IGraphicSystem, IInputSystem
    {
        GraphicsDeviceManager m_graphics;
        SpriteBatch m_spriteBatch;
        SnakeGame m_snakeGame;
        Graphics.SpriteBuffer m_spriteBuffer;
        Framework.Geometry.Rectangle m_bounds;
        SpriteFont m_defaultFont;
        float m_unitX;
        float m_unitY;
        float m_fontSize;
        Framework.Geometry.Rectangle ICanvas.Bounds
        {
            get
            {
                return m_bounds;
            }
        }

        public SnakeMonoGame()
        {
            m_graphics = new GraphicsDeviceManager(this);
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
            m_spriteBatch = new SpriteBatch(GraphicsDevice);         
            m_defaultFont = Content.Load<SpriteFont>("DefaultMonoFont");
            m_fontSize = 12.0f;
            m_unitX = Window.ClientBounds.Width / m_fontSize;
            m_unitY = Window.ClientBounds.Height / m_fontSize;
            m_bounds = new Framework.Geometry.Rectangle(
                0.0f,
                0.0f,
                m_unitX,
               m_unitY);

            m_spriteBuffer = new Graphics.SpriteBuffer(10000);
            m_snakeGame = new SnakeGame();
            m_snakeGame.Initialize(
                this,
                new Framework.Physics.PhysicSystem(),
                new Framework.Texts.Map.MapTextSystem(m_snakeGame, "Slant"),
                this);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-spec/ific content.
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
            m_snakeGame.Update(DateTime.Now);            
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            m_snakeGame.Draw();
            GraphicsDevice.Clear(Color.Black);
            m_spriteBatch.Begin();
            for (int i = 0; i < m_spriteBuffer.Length; i++)
            {
                var sprite = m_spriteBuffer[i];
                m_spriteBatch.DrawString(
                    m_defaultFont,
                    sprite.Content.ToString(),
                    new Vector2(sprite.X, sprite.Y),
                    Color.LightGreen);
            }

            m_spriteBuffer.Clear();
            m_spriteBatch.End();
            base.Draw(gameTime);
        }

        void IGraphicSystem.Initialize()
        {
        }

        void IGraphicSystem.Render()
        {
        }

        void ICanvas.Draw(float x, float y, char sprite)
        {
            if (m_bounds.Contains(x, y))
            {
                // m_spriteBuffer.Add((float)Math.Round(x * m_unit), (float)Math.Round(y * m_unit), sprite);
                m_spriteBuffer.Add(x * m_fontSize, y * m_fontSize, sprite);
            }
        }

        bool IInputSystem.IsKeyDown(Framework.Input.Keys key)
        {
            return Keyboard.GetState().IsKeyDown((Microsoft.Xna.Framework.Input.Keys)key);
        }

        void IInputSystem.Update()
        {
        }
    }
}
