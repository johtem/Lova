using LOVA.ViewModels;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LOVA.Pages.Errors
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReplaceDevicePage : ContentPage
    {
        private ReplaceDeviceViewModel _viewModel;
       

        public ReplaceDevicePage()
        {
            InitializeComponent();

            _viewModel = new ReplaceDeviceViewModel();

            BindingContext = _viewModel;


        }

        //public ReplaceDevicePage(ReplaceDeviceViewModel errorVM)
        //{
        //    InitializeComponent();
        //    BindingContext = errorVM;
        //}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            _viewModel.IsChargeable = false;

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}