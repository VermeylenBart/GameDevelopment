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
using Microsoft.Xna.Framework.Input.Touch;

namespace GameDevelopment
{

    public enum Side
    {
        left,
        right,
        jump,
        nothing
    }

    class UserControl
    {
        private int _Width;

        private TouchCollection touchCollection = TouchPanel.GetState();
        

        public UserControl(int width)
        {
            this._Width = width;
        }

        public Side GetTap()
        {
            if (touchCollection.Count > 0)
            {
                if (touchCollection[0].Position.X <= (this._Width / 2) - 100)
                {
                    return Side.left;
                }
                else if (touchCollection[0].Position.X >= (this._Width / 2) + 100)
                {
                    return Side.right;
                }
                else if (touchCollection[0].Position.X > (this._Width / 2) - 100 && touchCollection[0].Position.X < (this._Width / 2) + 100)
                    return Side.jump;
            }
            return Side.nothing;
        }
    }
}