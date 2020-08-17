using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace LOVA.Services
{
    public interface IStatusBarPlatformSpecific
    {
        void SetStatusBarColor(Color color);
    }
}
