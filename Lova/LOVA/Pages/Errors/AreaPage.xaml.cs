using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LOVA.Pages.Errors
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AreaPage : ContentPage
    {
        public AreaPage()
        {
            InitializeComponent();

            Func<CancellationToken, Task<Stream>> streamFunc = ct => Task.Run(() =>
            {
                Assembly assembly = typeof(AreaPage).Assembly;
                string fileName = assembly.GetManifestResourceNames().FirstOrDefault(n => n.Contains("areamap.pdf"));
                Stream stream = assembly.GetManifestResourceStream(fileName);
                return stream;
            });
            this.pdfViewer.Source = streamFunc;
        }
    }
}