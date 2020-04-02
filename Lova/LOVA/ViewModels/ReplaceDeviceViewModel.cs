using LOVA.Models;
using LOVA.Pages.Errors;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;
using ZXing.Mobile;
using ZXing.Net.Mobile.Forms;

namespace LOVA.ViewModels
{
    public class ReplaceDeviceViewModel : BaseViewModel
    {

        public ReplaceDeviceViewModel()
        {
            

            OnScanNewButtonClicked = new Command(ScanNewAktivator, () => !IsBusy);
            OnScanNewVentilButtonClicked = new Command(ScanNewVentil, () => !IsBusy);
            SaveError = new Command(Save, () => !IsBusy);
            OnTakePictureButtonClicked = new Command(TakePhotoMediaPlugin, () => !IsBusy);
        }


        string problemDescription;
        public string ProblemDescription
        {
            get => problemDescription;
            set
            {
                problemDescription = value;

                OnPropertyChanged();

           }
        }

        string problemSolution;
        public string ProblemSolution
        {
            get => problemSolution;
            set
            {
                problemSolution = value;

                OnPropertyChanged();

            }
        }

        string wellName;

        public string WellName
        {
            get => wellName;
            set
            {
                wellName = value;

                OnPropertyChanged();

            }
        }

        string serialNewAktivator;

        public string SerialNewAktivator
        {
            get => serialNewAktivator;
            set
            {
                serialNewAktivator = value;

                OnPropertyChanged();

            }
        }

        private string _serialNewValve;

        public string SerialNewValve
        {
            get => _serialNewValve;
            set
            {
                _serialNewValve = value;

                OnPropertyChanged();

            }
        }



        private bool _isSwitchToggled;

        public bool IsSwitchToggled
        {
            get { return _isSwitchToggled; }
            set
            {
                _isSwitchToggled = value;
                OnPropertyChanged();
               if (IsChargeable == false)
                { 
                    IsChargeable = true; 
                }
                else
                {
                    IsChargeable = false;
                }
            }
        }


        bool _isChargeable;
        public bool IsChargeable
        {
            get { return _isChargeable; }
            set
            {
                _isChargeable = value;

                OnPropertyChanged();
            }
        }

        string photoPath;

        public string PhotoPath
        {
            get { return photoPath; }
            set
            {
                photoPath = value;
                OnPropertyChanged();
            }
        }




        public Command SaveError { get;  }
        public Command OnScanNewButtonClicked { get;  }

        public Command OnScanNewVentilButtonClicked { get; }

        public Command OnTakePictureButtonClicked { get; }

        async void ScanNewAktivator()
        {

            // await Application.Current.MainPage.Navigation.PushAsync(new ScanNewAktivator(description));

            var options = new MobileBarcodeScanningOptions
            {
                AutoRotate = true,
                UseFrontCameraIfAvailable = false,               
                TryHarder = true
            };

            var overlay = new ZXingDefaultOverlay
            {
                ShowFlashButton = false,
                TopText = "Håll kameran över streckkoden",
                BottomText = "Scanningen sker automatiskt",
                AutomationId = "zxingDefaultOverlay"

            };
            
            var scan = new ZXingScannerPage(options, customOverlay: overlay);
            overlay.FlashCommand = new Command(() => scan.ToggleTorch());
            scan.AutoFocus();
            
            scan.OnScanResult += (result) =>
            {
                scan.IsScanning = false;

                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Application.Current.MainPage.Navigation.PopAsync();
                    SerialNewAktivator = result.Text;
                });
            };
            await Application.Current.MainPage.Navigation.PushAsync(scan);

        }

        async void ScanNewVentil()
        {
            var options = new MobileBarcodeScanningOptions
            {
                AutoRotate = true,
                UseFrontCameraIfAvailable = false,
                TryHarder = true
            };

            var overlay = new ZXingDefaultOverlay
            {
                ShowFlashButton = false,
                TopText = "Håll kameran över streckkoden",
                BottomText = "Scanningen sker automatiskt",
                AutomationId = "zxingDefaultOverlay"

            };

            var scan = new ZXingScannerPage(options, customOverlay: overlay);
            overlay.FlashCommand = new Command(() => scan.ToggleTorch());
            scan.AutoFocus();

            scan.OnScanResult += (result) =>
            {
                scan.IsScanning = false;

                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Application.Current.MainPage.Navigation.PopAsync();
                    SerialNewValve = result.Text;
                });
            };
            await Application.Current.MainPage.Navigation.PushAsync(scan);
        }

        async void TakePhotoMediaPlugin()
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await Application.Current.MainPage.DisplayAlert("Ingen kamera", "Kameran är inte tillgänglig", "OK");
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

            PhotoPath = file.Path;

            //image.Source = ImageSource.FromStream(() =>
            //{
            //    var stream = file.GetStream();
            //    file.Dispose();
            //    return stream;
            //});



          //  await Application.Current.MainPage.DisplayAlert("Bild", file.Path, "OK");
        }
 

        async void Save()
        {

            var message = $@"Felbeskrivning: {ProblemDescription}
Intagsenhet: {WellName}
Åtgärd: {ProblemSolution}
Ny Aktivator: {SerialNewAktivator}
Ny Ventil: {SerialNewValve}";

            try
            {

                var messageBody = new EmailMessage
                {
                    Subject = "Löva felrapport",
                    Body = message,
                    To = { "johan.tempelman@bt.com" }
                };

                if (PhotoPath != null)
                {
                    messageBody.Attachments.Add(new EmailAttachment(PhotoPath));
                }
                


                await Xamarin.Essentials.Email.ComposeAsync(messageBody);
            }
            catch
            {

                    
                await Application.Current.MainPage.DisplayAlert("Save", message, "OK");
            }
            
            
          
        }
    }
}
