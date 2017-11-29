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
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace GameDevelopment
{
    class Player
    {
        private Texture2D _texture;
        private Rectangle _viewRectangle;
        private Rectangle _coalition;
        private int _width, _height;



        public Player(Texture2D texture, int width, int height)
        {
            _texture = texture;
            _width = width;
            _height = height;
            _viewRectangle = new Rectangle(0, 0, 330, 243);

            Positie = new Vector2(0, _height-_viewRectangle.Height);
            
           // _coalition = new Rectangle((int)Positie.X, (int)Positie.Y, 64, 205);

        }

        public Vector2 Positie;

        private void _moving(int speed)
        {
            Positie.X += speed;

            if (Positie.X <= 0-_viewRectangle.Width)
            {
                Positie.X = _width;
            }
            else if (Positie.X > _width)
            {
                Positie.X = 0-_viewRectangle.Width;
            }
        }

        public void Update(Side side)
        {
            switch (side)
            {
                case Side.left:
                    _moving(-10);
                    _viewRectangle.Y = _viewRectangle.Height;
                    break;
                case Side.right:
                    _moving(10);
                    _viewRectangle.Y = 0;
                    break;
                default:
                    break;
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Positie, _viewRectangle, Color.White);
        }
    }
}
