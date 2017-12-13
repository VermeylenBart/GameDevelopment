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
        public Vector2 Position, Velocity;
        private bool isJumping;
        private const float LandPosition = 1000f;
        private Rectangle _viewRectangle;
        public Rectangle _coalition;
        private int _width, _height;




        public Player(Texture2D texture, int width, int height)
        {
            _texture = texture;
            _width = width;
            _height = height;
            _viewRectangle = new Rectangle(0, 0, _texture.Width, _texture.Height/4);

            Position = new Vector2(0, 0);  //_height-_viewRectangle.Height);

            Velocity = Vector2.Zero;
            isJumping = true;

            _coalition = new Rectangle((int)Position.X, (int)Position.Y, _viewRectangle.Width, 100);

        }

        private void _moving(int speed)
        {
            Position.X += speed;

            if (Position.X <= 0 - _viewRectangle.Width)
            {
                Position.X = _width;
            }
            else if (Position.X > _width)
            {
                Position.X = 0 - _viewRectangle.Width;
            }
        }

        public void Update(Side side, GameTime gameTime)
        {

            if (!isJumping)
            {
                doJump(40f);
            }
            else
            {
                Velocity.Y++;
                if (Position.Y >= _height - _viewRectangle.Height)
                {
                    Position.Y = _height - _viewRectangle.Height;
                    Velocity.Y = 0;
                    isJumping = false;
                }
            }
            


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

            Position += Velocity;

            _coalition.X = (int)Position.X;
            _coalition.Y = (int)Position.Y;

        }

        private void doJump(float speed)
        {
            isJumping = true;
            Velocity = new Vector2(0, -speed);
        }

        
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Position, _viewRectangle, Color.White);
        }
    }
}
