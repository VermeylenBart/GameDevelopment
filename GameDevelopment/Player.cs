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
        private Rectangle _viewRectangle, _viewRectangle2, _currentView;
        public Rectangle _coalition;



        public Player(Texture2D texture)
        {
            _texture = texture;

            Positie = new Vector2(100, 100);
            _viewRectangle = new Rectangle(0, 0, 110, 81);
            _viewRectangle2 = new Rectangle(0, 81, 110, 81);
           // _coalition = new Rectangle((int)Positie.X, (int)Positie.Y, 64, 205);

            _currentView = _viewRectangle;

        }

        public Vector2 Positie;

        public void Update(String Side)
        {
            switch (Side)
            {
                case "left":
                    Positie.X -= 1;
                    _currentView = _viewRectangle2;
                    break;
                case "right":
                    Positie.X += 1;
                    _currentView = _viewRectangle;
                    break;
                case "nothing":
                    break;
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Positie, _currentView, Color.White);
        }
    }
}
