using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Doog.Framework;
using Snake;

namespace Snake.Runners.MonoGameDesktop
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class SnakeMonoGame : Microsoft.Xna.Framework.Game, IGraphicSystem, IInputSystem
    {
        void HandleAction()
        {

        }

        GraphicsDeviceManager m_graphics;
        SpriteBatch m_spriteBatch;
        SnakeGame m_snakeGame;
        Graphics.SpriteBuffer m_spriteBuffer;
        Doog.Framework.Rectangle m_bounds;
        SpriteFont m_defaultFont;
        Vector2 m_fontSize;
        Vector2 m_fontSizeHalf;
        Vector2 m_fontScale;
        Vector2 m_fontDrawScale;
        Doog.Framework.Rectangle ICanvas.Bounds
        {
            get
            {
                return m_bounds;
            }
        }

        public SnakeMonoGame()
        {
            m_graphics = new GraphicsDeviceManager(this);
            //m_graphics.ToggleFullScreen();
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
            Window.Position = new Microsoft.Xna.Framework.Point(0, 0);
            Window.Title = "Doog - Snake";
            m_graphics.PreferredBackBufferWidth = GraphicsDevice.Adapter.CurrentDisplayMode.Width - 100;
            m_graphics.PreferredBackBufferHeight = GraphicsDevice.Adapter.CurrentDisplayMode.Height - 100;
            m_graphics.ApplyChanges();
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
            var realFontSize = m_defaultFont.MeasureString("@");
            m_fontScale = new Vector2(1.0f, realFontSize.X / realFontSize.Y);
            m_fontDrawScale = m_fontScale * 1f; 
            m_fontSize = new Vector2(realFontSize.X, realFontSize.Y) * m_fontScale;
            m_fontSizeHalf = m_fontSize * 0.5f;
            m_bounds = new Doog.Framework.Rectangle(
                0.0f,
                0.0f,
                (int)(Window.ClientBounds.Width / m_fontSize.X),
                (int)(Window.ClientBounds.Height / m_fontSize.Y));

            m_spriteBuffer = new Graphics.SpriteBuffer((int)(m_bounds.Width * m_bounds.Height));
            m_snakeGame = new SnakeGame();
            m_snakeGame.Initialize(
                this,
                new Doog.Framework.PhysicSystem(),
                new Doog.Framework.MapTextSystem(m_snakeGame, "Slant"),
                this,
                Exit);
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
            if (Keyboard.GetState().IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Escape))
            {
                Exit();
            }

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
                    (new Vector2(sprite.X, sprite.Y) * m_fontSize),
                    Color.LightGreen,
                    0.0f,
                    Vector2.Zero,
                    m_fontDrawScale,
                    SpriteEffects.None,
                    1.0f);
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
                m_spriteBuffer.Add(x, y, sprite);
            }
        }

        bool IInputSystem.IsKeyDown(Doog.Framework.Keys key)
        {
            return Keyboard.GetState().IsKeyDown((Microsoft.Xna.Framework.Input.Keys)key);
        }

        void IInputSystem.Update()
        {
        }
    }
}
