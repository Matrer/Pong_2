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
    class Paddle
    {
        private Sprite sprite;
        private Rectangle screenBounds;
        public Vector2 Position => sprite.position;
        
        public Paddle(Sprite sprite, Rectangle screenBounds)
        {
            this.screenBounds = screenBounds;
            this.sprite = sprite;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);
        }
        public void Update(Ball ball)
        {
            if(sprite.DestinationRectangle.Intersects(ball.DestinationRectangle))
            {
              //  ball.speed++;
                int size = sprite.Size.Height;
                int onePart = size / 5;
                float position = ball.Position.Y+ball.Size.Height/2;

                ball.velocity.X = ball.velocity.X * -1f;
                if (Position.Y - onePart*5 < position)
                {
                    ball.velocity.Y = 1;
                    return;
                }
                if (Position.Y - onePart * 4 < position)
                {
                    ball.velocity.Y = 0.5f;
                    return;
                }
                if (Position.Y - onePart * 3 < position)
                {
                    ball.velocity.Y = 0;
                    return;
                }
                if (Position.Y - onePart * 2 < position)
                {
                    ball.velocity.Y = -0.5f;
                    return;
                }
                if (Position.Y - onePart < position)
                {
                    ball.velocity.Y = -1;
                    return;
                }


            }
        }

        public void moveUp() 
        {
            if (0 < sprite.position.Y)
            {
                sprite.position.Y -= 4;
            }
        }
        public void moveDown()
        {
            if (screenBounds.Height - sprite.Size.Height > sprite.position.Y)
            {
                sprite.position.Y += 4;
            }
        }


    }
}
