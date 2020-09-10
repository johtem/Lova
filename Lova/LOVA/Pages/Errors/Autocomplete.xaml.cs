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
    public partial class Autocomplete : ContentPage
    {
        public Autocomplete()
        {
            InitializeComponent();

            this.autoCompleteView.ItemsSource = new List<string>()
            {
                "Johan",
                "Oscar",
                "Hannah",
                "Maria",
                "Mamma"
            };
        }
    }
}