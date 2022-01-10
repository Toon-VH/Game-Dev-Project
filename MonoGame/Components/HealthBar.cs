using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoTest.GameObjects;

namespace MonoTest.Components
{
    public class HealthBar : IComponent
    {
        private readonly Texture2D _texture;
        public  Moveable _moveAble { get; set; }

        private  Vector2 _position;
        private Rectangle _fullHP;
        private Rectangle _almostFullHP;
        private Rectangle _halfHP;
        private Rectangle _almostEmptyHP;
        private Rectangle _emptyHP;
        private readonly float _scale;


        public HealthBar(Texture2D texture, Vector2 position, Moveable moveable, float scale)
        {
            _texture = texture;
            _position = position;
            _moveAble = moveable;
            _scale = scale;
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


        public void Draw(SpriteBatch spriteBatch)
        {
            if (_moveAble.Health <= 0 && _moveAble is not Hero) return;

            var counter = 0;
            var health = _moveAble.Health;

            
            for (var i = _moveAble.InitialHealth - 1; i >= 0; i--)
            {
                if (health - 4 >= 0 && health != 0)
                {
                    spriteBatch.Draw(_texture, new Vector2(_position.X + (counter * _fullHP.Width * _scale), _position.Y),
                        _fullHP,
                        Color.White, 0f, Vector2.Zero, _scale,
                        SpriteEffects.None, 0f);
                    health -= 4;
                }
                else switch (health)
                {
                    case 3:
                        spriteBatch.Draw(_texture, new Vector2(_position.X + (counter * _fullHP.Width * _scale), _position.Y),
                            _almostFullHP,
                            Color.White, 0f, Vector2.Zero, _scale,
                            SpriteEffects.None, 0f);
                        health -= 3;
                        break;
                    case 2:
                        spriteBatch.Draw(_texture, new Vector2(_position.X + (counter * _fullHP.Width * _scale), _position.Y),
                            _halfHP,
                            Color.White, 0f, Vector2.Zero, _scale,
                            SpriteEffects.None, 0f);
                        health -= 2;
                        break;
                    case 1:
                        spriteBatch.Draw(_texture, new Vector2(_position.X + (counter * _fullHP.Width * _scale), _position.Y),
                            _almostEmptyHP,
                            Color.White, 0f, Vector2.Zero, _scale,
                            SpriteEffects.None, 0f);
                        health -= 1;
                        break;
                    case 0 when counter < _moveAble.InitialHealth / 4:
                        spriteBatch.Draw(_texture, new Vector2(_position.X + (counter * _fullHP.Width * _scale), _position.Y),
                            _emptyHP,
                            Color.White, 0f, Vector2.Zero, _scale,
                            SpriteEffects.None, 0f);
                        break;
                }

                counter++;
            }
        }

        public void Update(GameTime gameTime, Matrix matrix)
        {
            if (_moveAble is Hero) return;
            _position = new Vector2(_moveAble.Position.X + _moveAble.BoundingBox.X *_moveAble.Scale + _moveAble.BoundingBox.Width * _moveAble.Scale/2 - _moveAble.InitialHealth/4 *_fullHP.Width * _scale/2 , _moveAble.Position.Y + _moveAble.BoundingBox.Y *_moveAble.Scale - 10);
        }
    }
} 