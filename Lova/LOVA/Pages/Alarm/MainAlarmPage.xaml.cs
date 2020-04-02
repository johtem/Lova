using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LOVA.Pages.Alarm
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainAlarmPage : ContentPage
    {
        public MainAlarmPage()
        {
            InitializeComponent();
        }

        private void OnHttpButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HttpTestPage());
        }

        private void OnIssueReportButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ReportIssuesPage());
        }
    }
}