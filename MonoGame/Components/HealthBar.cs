using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoTest.GameObjects;

namespace MonoTest.Components
{
    public class HealthBar : Component
    {
        private readonly Texture2D _texture;
        private readonly Vector2 _position;
        private readonly Hero _hero;

        private Rectangle _fullHP;
        private Rectangle _almostFullHP;
        private Rectangle _halfHP;
        private Rectangle _almostEmptyHP;
        private Rectangle _emptyHP;

        public HealthBar(Texture2D texture, Vector2 position, Hero hero)
        {
            _texture = texture;
            _position = position;
            _hero = hero;
            InitializeRectangles();
        }

        private void InitializeRectangles()
        {
            _fullHP = new Rectangle(0, 0, 17, 17);
            _almostFullHP = new Rectangle(17, 0, 17, 17);
            _halfHP = new Rectangle(34, 0, 17, 17);
            _almostEmptyHP = new Rectangle(51, 0, 17, 17);
            _emptyHP = new Rectangle(68, 0, 17, 17);
        }


        public override void Draw(SpriteBatch spriteBatch)
        {
            var counter = 0;
            var health = _hero.Health;

            for (var i = _hero.InitialHealth - 1; i >= 0; i--)
            {
                if (health - 4 >= 0 && health != 0)
                {
                    spriteBatch.Draw(_texture, new Vector2(_position.X + (counter * _fullHP.Width), _position.Y),
                        _fullHP,
                        Color.White, 0f, Vector2.Zero, 1f,
                        SpriteEffects.None, 0f);
                    health -= 4;
                }
                else switch (health)
                {
                    case 3:
                        spriteBatch.Draw(_texture, new Vector2(_position.X + (counter * _fullHP.Width), _position.Y),
                            _almostFullHP,
                            Color.White, 0f, Vector2.Zero, 1f,
                            SpriteEffects.None, 0f);
                        health -= 3;
                        break;
                    case 2:
                        spriteBatch.Draw(_texture, new Vector2(_position.X + (counter * _fullHP.Width), _position.Y),
                            _halfHP,
                            Color.White, 0f, Vector2.Zero, 1f,
                            SpriteEffects.None, 0f);
                        health -= 2;
                        break;
                    case 1:
                        spriteBatch.Draw(_texture, new Vector2(_position.X + (counter * _fullHP.Width), _position.Y),
                            _almostEmptyHP,
                            Color.White, 0f, Vector2.Zero, 1f,
                            SpriteEffects.None, 0f);
                        health -= 1;
                        break;
                    case 0 when counter < _hero.InitialHealth / 4:
                        spriteBatch.Draw(_texture, new Vector2(_position.X + (counter * _fullHP.Width), _position.Y),
                            _emptyHP,
                            Color.White, 0f, Vector2.Zero, 1f,
                            SpriteEffects.None, 0f);
                        break;
                }

                counter++;
            }
        }

        public override void Update(GameTime gameTime, Matrix matrix)
        {
        }
    }
}