using LOVA.ViewModels;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.XamarinForms.Input;
using Telerik.XamarinForms.Input.DataForm;
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

            takePhoto.Clicked += async (sender, args) =>
            {
                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await DisplayAlert("Ingen kamera", "Kameran är inte tillgänglig", "OK");
                    return;
                }

                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    Directory = "Test",
                    SaveToAlbum = true,
                    CompressionQuality = 75,
                    CustomPhotoSize = 50,
                    PhotoSize = PhotoSize.MaxWidthHeight,
                    MaxWidthHeight = 2000,
                    DefaultCamera = CameraDevice.Front
                });

                if (file == null)
                {
                    return;
                }

                
                image.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    file.Dispose();
                    return stream;
                });

                

                await DisplayAlert("Bild", file.Path, "OK");
            };

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

    }
}