using Azure;
using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using LOVA.Models;
using LOVA.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LOVA.Pages.Errors
{
    
    public partial class ReportIssueDetailPage : ContentPage
    {
        public ReportIssueDetailPage(IssueReport detail )
        {
            InitializeComponent();

           

            ProblemDescription.Text = detail.ProblemDescription;
            SolultionDescription.Text = detail.SolutionDescription;
            Well.Text = detail.WellName; 
            NewActivator.Text = detail.NewActivatorSerialNumber;
            NewValve.Text = detail.NewValveSerialNumber;
            ImageName.Text =  string.IsNullOrEmpty(detail.ImageName) ?  "Ingen bild" : detail.ImageName;      
            CreatedAt.Text = detail.CreatedAt.ToShortDateString();

            if (!string.IsNullOrEmpty(detail.ImageName))
            {

                // MediaFile file;
                string fileName = detail.ImageName;
                string containerPath = "https://lottingelundfiles.blob.core.windows.net/lovaphotos/";


                Image.Source = containerPath + fileName;

            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}