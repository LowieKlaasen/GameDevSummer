using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameDev
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _heroTexture;

        private Hero hero;

        private Texture2D blokTexture;
        //private Rectangle heroBlok;
        private Rectangle staticBlok;
        private Color backgroundColor;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();

            hero = new Hero(_heroTexture, new KeyboardReader());

            //heroBlok = new Rectangle(10, 10, 50, 50);
            staticBlok = new Rectangle(100, 100, 50, 50);

            backgroundColor = Color.CornflowerBlue;
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            _heroTexture = Content.Load<Texture2D>("RogueRunning_Cropped");

            blokTexture = new Texture2D(GraphicsDevice, 1, 1);
            blokTexture.SetData(new[] { Color.White });
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            hero.Update(gameTime);

            if (hero.BoundingBox.Intersects(staticBlok))
            {
                backgroundColor = Color.Black;
            }
            else
            {
                backgroundColor = Color.CornflowerBlue;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(backgroundColor);
            _spriteBatch.Begin();
            
            hero.Draw(_spriteBatch);

            //_spriteBatch.Draw(blokTexture, heroBlok, Color.Red);
            _spriteBatch.Draw(blokTexture, staticBlok, Color.Green);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
