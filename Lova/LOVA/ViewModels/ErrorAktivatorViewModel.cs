using LOVA.Models;
using LOVA.Views.Errors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace LOVA.ViewModels
{
    public class ErrorAktivatorViewModel : INotifyPropertyChanged
    {

        public ErrorAktivatorViewModel()
        {
            OnScanNewButtonClicked = new Command(ScanNewAktivator, () => !IsBusy);
            OnScanNewVentilButtonClicked = new Command(ScanNewVentil, () => !IsBusy);
            SaveError = new Command(Save, () => !IsBusy);
            OnTakePictureButtonClicked = new Command(TakePicture, () => !IsBusy);
        }

        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        

        public event PropertyChangedEventHandler PropertyChanged;

        


        bool isBusy = false;

        public bool IsBusy
        {
            get => isBusy;
            set
            {
                isBusy = value;

                OnPropertyChanged();
                SaveError.ChangeCanExecute();
                OnScanNewButtonClicked.ChangeCanExecute();

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

        private string _serialNewVentil;

        public string SerialNewVentil
        {
            get => _serialNewVentil;
            set
            {
                _serialNewVentil = value;

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
               if (IsFoto == false)
                { 
                    IsFoto = true; 
                }
                else
                {
                    IsFoto = false;
                }


               
            }
        }


        private bool _isFoto = false;

        public bool IsFoto
        {
            get { return _isFoto; }
            set
            {
                _isFoto = value;

                OnPropertyChanged();
            }
        }


        public Command SaveError { get;  }
        public Command OnScanNewButtonClicked { get;  }

        public Command OnScanNewVentilButtonClicked { get; }

        public Command OnTakePictureButtonClicked { get; }

        async void ScanNewAktivator()
        {
            var description = new ErrorAktivatorViewModel
            {
                WellName = WellName,
                ProblemDescription = ProblemDescription,
                SerialNewAktivator = SerialNewAktivator,
                SerialNewVentil = SerialNewVentil,
                ProblemSolution = ProblemSolution
            };

            await Application.Current.MainPage.Navigation.PushAsync(new ScanNewAktivator(description));
        }

        async void ScanNewVentil()
        {
            var description = new ErrorAktivatorViewModel
            {
                WellName = WellName,
                ProblemDescription = ProblemDescription,
                SerialNewAktivator = SerialNewAktivator,
                SerialNewVentil = SerialNewVentil,
                ProblemSolution = ProblemSolution
            };

            await Application.Current.MainPage.Navigation.PushAsync(new ScanNewVentil(description));
        }

        async void TakePicture()
        {
            var description = new ErrorAktivatorViewModel
            {
                WellName = WellName,
                ProblemDescription = ProblemDescription,
                SerialNewAktivator = SerialNewAktivator,
                SerialNewVentil = SerialNewVentil,
                ProblemSolution = ProblemSolution
            };

            await Application.Current.MainPage.Navigation.PushAsync(new CameraPage());
        }
 

        async void Save()
        {
            try
            {
                await Xamarin.Essentials.Email.ComposeAsync("Löva felrapport", "", "johan.tempelman@bt.com");
            }
            catch
            {
                var message = $@"Felbeskrivning: {ProblemDescription}
Intagsenhet: {WellName}
Åtgärd: {ProblemSolution}
Ny Aktivator: {SerialNewAktivator}
Ny Ventil: {SerialNewVentil}";

                    
                await Application.Current.MainPage.DisplayAlert("Save", message, "OK");
            }
            
            
          
        }
    }
}
