using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoTest.Animations;

namespace MonoTest.GameObjects
{
    public abstract class GameObject
    {
        protected Texture2D _texture;
        
        public Vector2 Position { get; set; }
        public int Damage { get; set; }
        public Animation CurrentAnimation { get; private set; }
        public bool RemoveFlag { get;  set; }
        public abstract void Update(GameTime gameTime);
        

        public abstract void Draw(SpriteBatch spriteBatch, GraphicsDevice graphics);
        
        protected readonly IDictionary<string, Animation> Animations;

        protected GameObject()
        {
            Animations = new Dictionary<string, Animation>();
        }

        protected void AddAnimation(string key, Animation animation)
        {
            Animations.Add(key, animation);
        }

        protected void SetCurrentAnimation(string key)
        {
            if (!Animations.ContainsKey(key)) throw new Exception("Animation not defined.");
            CurrentAnimation = Animations[key];
        }
    }
}