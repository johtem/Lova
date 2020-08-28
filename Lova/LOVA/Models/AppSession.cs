using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace LOVA.Models
{
    public static class AppSession
    {
        public static string AllVACasesUrl = "https://lovaapi.azurewebsites.net/api/IssueReports";
        public static string LoginUrl = "https://lovaapi.azurewebsites.net/api/Login";

        public static bool FirstRun
        {
            get => Preferences.Get(nameof(FirstRun), true);
            set => Preferences.Set(nameof(FirstRun), value);
        }
    }
}
