using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonogameBouncingBall;

public class BouncingBallGame : Game
{
    private const int BALL_SIZE = 116;
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Texture2D _ballSprite;
    private Vector2 _ballPos;
    private Vector2 _ballSpeed;

    public BouncingBallGame()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;

        _ballPos = new Vector2(100, 100);
        _ballSpeed = new Vector2(2, 2);
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        _ballSprite = Content.Load<Texture2D>("basketball1");
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        if(_ballSprite != null)
        {
            if(_ballPos.X + BALL_SIZE + _ballSpeed.X > Window.ClientBounds.Width ||
                _ballPos.X + _ballSpeed.X < 0)
            {
                _ballSpeed.X = -_ballSpeed.X;
            }

            if(_ballPos.Y + BALL_SIZE + _ballSpeed.Y > Window.ClientBounds.Height ||
                _ballPos.Y + _ballSpeed.Y < 0)
            {
                _ballSpeed.Y = -_ballSpeed.Y;
            }

            _ballPos += _ballSpeed;
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();
        _spriteBatch.Draw(_ballSprite, _ballPos, Color.White);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
