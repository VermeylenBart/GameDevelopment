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
    class Player : ICollide
    {
        private Texture2D _texture;
        public Vector2 Position, Velocity;
        public bool isJumping;
        private const float LandPosition = 1000f;
        private Rectangle _viewRectangle;
        private Rectangle _coalition;
        private int _width, _height;
        public bool isCollide;




        public Player(Texture2D texture, int width, int height)
        {
            _texture = texture;
            _width = width;
            _height = height;
            _viewRectangle = new Rectangle(0, 0, _texture.Width, _texture.Height/4);

            Position = new Vector2(0, _height-_viewRectangle.Height);

            Velocity = Vector2.Zero;
            isJumping = false;
            isCollide = false;

            _coalition = new Rectangle((int)Position.X+10, (int)Position.Y + _texture.Height, _viewRectangle.Width-20, 20);

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

        public void Update(Side side)
        {

            if (!isJumping)
            {
                doJump(40f);
            }
            else
            {
                Velocity.Y++;
                if (isCollide)
                {
                    Velocity.Y = 0;
                    isJumping = false;
                    isCollide = false;
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

        public Rectangle GetCollisionRectangle()
        {
            return _coalition;
        }
    }
}
