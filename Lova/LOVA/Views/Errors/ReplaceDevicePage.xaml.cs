using LOVA.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.XamarinForms.Input;
using Telerik.XamarinForms.Input.DataForm;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LOVA.Views.Errors
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReplaceDevicePage : ContentPage
    {

       
        public ReplaceDevicePage()
        {
            InitializeComponent();
            BindingContext = new ErrorAktivatorViewModel();
        }

        public ReplaceDevicePage(ErrorAktivatorViewModel errorVM)
        {
            InitializeComponent();
            BindingContext = errorVM;
        }

    }
}