﻿using LOVA.Models;
using LOVA.Pages.Errors;
using LOVA.Services;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace LOVA.ViewModels
{
    public class ReplaceDeviceViewModel : BaseViewModel
    {

        public ReplaceDeviceViewModel()
        {
            DataLoaded = true;
            IsBusy = false;
           
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

        public Command OnTakePictureButtonClicked { get; }

        

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
                Directory = "Pictures",
                //Name= "test.jpg",
                SaveToAlbum = true,
                CompressionQuality = 75,
                CustomPhotoSize = 50,
                PhotoSize = PhotoSize.Medium
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



          await Application.Current.MainPage.DisplayAlert("Bild", file.Path, "OK");
        }
 

        async void Save()
        {
            DataLoaded = false;
            IsBusy = true;
            var message = $@"Felbeskrivning: {ProblemDescription}
                            Intagsenhet: {WellName.ToUpper()}
                            Åtgärd: {ProblemSolution}
                            Ny Aktivator: {SerialNewAktivator}
                            Ny Ventil: {SerialNewValve}";

            IssueReport issueReport = new IssueReport
            {
                WellName = WellName.ToUpper(),
                ProblemDescription = ProblemDescription,
                SolutionDescription = ProblemSolution,
                NewActivatorSerialNumber = SerialNewAktivator,
                NewValveSerialNumber = SerialNewValve,
                IsChargeable = IsChargeable,
                CreatedAt = DateTime.Now
            };

            try
            {
                LovaRestService api = new LovaRestService();
                 await api.SaveIssueReportAsync(issueReport, true);



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


            await Application.Current.MainPage.Navigation.PopAsync();

        }


        //Upload to blob function    
        //private async void UploadImage(Stream stream)
        //{
        //    Busy();
        //    var account = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=ahsanblobaccount;AccountKey=fOvpvzb8jFL0pNfDWvz9n76DzLWSlZu4aw6ZLXMbDId15YYfox15UoKvWMmTCJ6vcNoyk5w+A==;EndpointSuffix=core.windows.net");
        //    var client = account.CreateCloudBlobClient();
        //    var container = client.GetContainerReference("images");
        //    await container.CreateIfNotExistsAsync();
        //    var name = Guid.NewGuid().ToString();
        //    var blockBlob = container.GetBlockBlobReference($"{name}.png");
        //    await blockBlob.UploadFromStreamAsync(stream);
        //    URL = blockBlob.Uri.OriginalString;
        //    UploadedUrl.Text = URL;
        //    NotBusy();
        //    await DisplayAlert("Uploaded", "Image uploaded to Blob Storage Successfully!", "OK");
        //}
    }
}
