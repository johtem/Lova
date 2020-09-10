using Azure.Storage.Blobs;
using LOVA.Models;
using LOVA.Pages.Errors;
using LOVA.Services;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace LOVA.ViewModels
{
    public class ReplaceDeviceViewModel : BaseViewModel
    {

        public ObservableCollection<string> Source { get; set; }

        public ReplaceDeviceViewModel()
        {
            DataLoaded = true;
            IsBusy = false;
           
            SaveError = new Command(Save, () => !IsBusy);
            OnTakePictureButtonClicked = new Command(TakePhotoMediaPlugin, () => !IsBusy);
            OnUploadPictureButtonClicked = new Command(uploadPhotoMediaPlugin, () => !IsBusy);

            this.Source = new ObservableCollection<string>()
            {
                "1A1", "1A2", "1A3", "1A4",
                "1B1", "1B2", "1B3", "1B4",
                "1C1", "1C2", "1C3", "1C4",
                "1D1", "1D2", "1D3", "1D4", "1D5", "1D6",
                "1E1", "1E2", "1E3", "1E4", "1E5",
                "1F1", "1F2", "1F3",
                "1G1", "1G2", "1G3", "1G4",
                "1H1", "1H2", "1H3", "1H4", "1H5", "1H6",
                "1I1", "1I2",
                "1J1", "1J2", "1J3", "1J4",
                "1K1", "1K2", "1K3", "1K4",
                "1L1", "1L2", "1L3", "1L4", "1L5",
                "1M1", "1M2", "1M3", "1M4", "1M5", "1M6",
                "1N1", "1N2", "1N3", "1N4", "1N5",
                "1O1", "1O2", "1O3", "1O4", "1O5",
                "1P1", "1P2", "1P3",
                "3A1", "3A2", "3A3",
                "3B1", "3B2",
                "3C1", "3C2", "3C3",
                "3D1", "3D2", "3D3", "3D4",
                "3E1", "3E2",
                "3F1", "3F2", "3F3", "3F4",
                "3G1", "3G2",
                "3H1", "3H2",
                "3I1", "3I2",
                "3J1", "3J2",
                "3K1", "3K2", "3K3",
                "3L1", "3L2", "3L3",
                "3M1", "3M2",
                "2A1", "2A2", "2A3",
                "2B1", "2B2", "2B3",
                "2C1", "2C2", "2C3",
                "2D1", "2D2", "2D3",
                "2E1", "2E2",
                "2F1", "2F2",
                "2G1", "2G2",
                "2H1", "2H2",
                "2I1", "2I2", "2I3", "2I4",
                "2J1",
                "2K1", "2K2", "2K3",
                "2L1", "2L2", "2L3",
                "2M1",
                "3A1", "3A2", "3A3",
                "3B1", "3B2",
                "3C1", "3C2", "3C3",
                "3D1", "3D2", "3D3", "3D4",
                "3E1", "3E2",
                "3F1", "3F2", "3F3", "3F4",
                "3G1", "3G2",
                "3H1", "3H2",
                "3I1", "3I2",
                "3J1", "3J2",
                "3K1", "3K2", "3K3",
                "3L1", "3L2", "3L3",
                "3M1", "3M2",
                "3N1", "3N2",
                "3O1", "3O2"

            };
        }


        DateTime timeForAlarm { get; set; }

        public DateTime TimeForAlarm
        {
            get => timeForAlarm;
            set
            {
                timeForAlarm = value;
                OnPropertyChanged();
            }
        }
             
        DateTime arrivalTime { get; set; }
        public DateTime ArrivalTime 
        {   get => arrivalTime;
            set
            {
                arrivalTime = value;
                OnPropertyChanged();
            }
        }

        decimal timeToRepair { get; set; }
        public decimal TimeToRepair 
        { 
            get => timeToRepair;
            set 
            {
                timeToRepair = value;
                OnPropertyChanged();
            } 
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
               //if (IsChargeable == false)
               // { 
               //     IsChargeable = true; 
               // }
               // else
               // {
               //     IsChargeable = false;
               // }
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
        public Command OnUploadPictureButtonClicked { get; }

        async void uploadPhotoMediaPlugin()
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await Application.Current.MainPage.DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                return;
            }
            var file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,

            });


            if (file == null)
                return;


            PhotoPath = file.Path;

            //image.Source = ImageSource.FromStream(() =>
            //{
            //    var stream = file.GetStream();
            //    file.Dispose();
            //    return stream;
            //});

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



            // await Application.Current.MainPage.DisplayAlert("Bild", file.Path, "OK");
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
                ImageName = PhotoPath != null ? Path.GetFileName(PhotoPath) : "",
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

                   // MediaFile file;

                    string _storageConnection = "DefaultEndpointsProtocol=https;AccountName=lottingelundfiles;AccountKey=CT94V7yN4yaC5VS78hFvETzqrUfPpH6/U7FVSd8exMOCbopcR8MCd2OKePjHRgHsw8fT5jUaVXrCVh2BvXWsbA==;EndpointSuffix=core.windows.net";

                    string containerName = "lovaphotos";
                    string blobName = Path.GetFileName(PhotoPath);
                    string filePath = PhotoPath;

                    // Get a reference to a container named containerName and then create it
                    BlobContainerClient container = new BlobContainerClient(_storageConnection, containerName);
                    container.Create();

                    // Get a reference to a blob named blobName in a container named "sample-container"
                    BlobClient blob = container.GetBlobClient(blobName);

                    // Upload local file
                    blob.Upload(filePath);



                    //CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(_storageConnection);
                    //CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
                    //CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference("lovaphotos");

                    //string filePath = PhotoPath;
                    //string fileName = Path.GetFileName(filePath);
                    //await cloudBlobContainer.CreateIfNotExistsAsync();

                    //await cloudBlobContainer.SetPermissionsAsync(new BlobContainerPermissions
                    //{
                    //    PublicAccess = BlobContainerPublicAccessType.Blob
                    //});
                    //var blockBlob = cloudBlobContainer.GetBlockBlobReference(fileName);
                    //await UploadImage(blockBlob, filePath);


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
        //private static async Task UploadImage(CloudBlockBlob blob, string filePath)
        //{
        //    using (var fileStream = File.OpenRead(filePath))
        //    {
        //        await blob.UploadFromStreamAsync(fileStream);
        //    }
        //}

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
