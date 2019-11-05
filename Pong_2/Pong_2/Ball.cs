using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Pong_2
{
    class Ball
    {
        private Sprite sprite;
        public const float beginignSpeed = 4;
        public float speed = 4;
        public Vector2 velocity = new Vector2(1,0);

        public Rectangle DestinationRectangle => sprite.DestinationRectangle;
        public Rectangle Size => sprite.Size;
        public Ball(Sprite sprite, Rectangle screenBounds)
        {
            this.sprite = sprite;
            Reset(screenBounds);
        }
        public void Reset(Rectangle screenBounds) 
        {
            Position = new Vector2(
                screenBounds.Width/2-sprite.Size.Width / 2, 
                screenBounds.Height/2-sprite.Size.Height / 2);

            speed = beginignSpeed;
            velocity = new Vector2(velocity.X*-1, 0);
        }
        
        public void Update(Rectangle screenBounds)
        {
            float postionY = sprite.position.Y;
            if (postionY >= screenBounds.Height-sprite.Size.Height || postionY <= 0)
            {
                velocity.Y = velocity.Y*-1;
            }

            sprite.position += velocity * speed;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);
        }
        public Vector2 Position 
        {
            get { return sprite.position; }
            set { sprite.position = value; }
        }
    }
}
