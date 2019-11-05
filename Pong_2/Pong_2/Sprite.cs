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
    class Sprite
    {
        private Texture2D texture;
        public Vector2 position;
        public Rectangle sourceRectangle;
        public Color color = Color.White;
        public float rotation = 0;
        public float scale = 1;

        public Rectangle Size => texture.Bounds;

        public Sprite(Texture2D texture, Vector2 position, Rectangle sourceRectangle) 
        {
            this.texture = texture;
            this.position = position;
            this.sourceRectangle = sourceRectangle;
        }
        public Sprite(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            this.position = position;
            this.sourceRectangle = new Rectangle(0,0,texture.Width,texture.Height);
        }
        public Rectangle DestinationRectangle 
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, sourceRectangle, color, rotation, Vector2.Zero, Vector2.One, SpriteEffects.None, 0);
        }
    }
}
