using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevelopment
{
    class Block : ICollide
    {

        Random r = new Random();
        private Texture2D texture;
        private int width;
        public Vector2 Position;

        public Block(Texture2D _texture, int _width)
        {
            texture = _texture;
            width = _width;
            Position = new Vector2(r.Next(0, width), 2000);
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, Color.White);
        }

        public Rectangle GetCollisionRectangle()
        {
            return new Rectangle((int)Position.X, (int)Position.Y - texture.Height - 100, texture.Width, 20);
        }
    }
}