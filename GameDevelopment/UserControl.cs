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
    class UserControl
    {
        private int _Width;

        private TouchCollection touchCollection = TouchPanel.GetState();

        public UserControl(int width)
        {
            this._Width = width;
        }

        public String GetTap()
        {
            if (touchCollection.Count > 0)
            {
                if (touchCollection[0].Position.X <= (this._Width / 2) - 20)
                {
                    return "left";
                }else if (touchCollection[0].Position.X >= (this._Width / 2) + 20)
                {
                    return "right";
                }
            }
            return "nothing";
        }
    }
}