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
        public Rectangle _coalition;



        public Player(Texture2D texture)
        {
            _texture = texture;

            Positie = new Vector2(0, 0);
            _viewRectangle = new Rectangle(0, 0, 110, 81);
           // _coalition = new Rectangle((int)Positie.X, (int)Positie.Y, 64, 205);

        }

        public Vector2 Positie;

        public void Update(String Side)
        {
            switch (Side)
            {
                case "left":
                    Positie.X -= 1;
                    _viewRectangle.Y = 81;
                    break;
                case "right":
                    Positie.X += 1;
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
