using LOVA.Models;
using LOVA.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LOVA.Views.Alarm
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HttpTestPage : ContentPage
    {
        public HttpTestPage()
        {
            InitializeComponent();

            BindingContext = new HttpTestViewModel();

        }

       

        
    }
}