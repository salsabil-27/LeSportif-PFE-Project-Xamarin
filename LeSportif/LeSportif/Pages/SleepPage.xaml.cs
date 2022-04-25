using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LeSportif.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SleepPage : ContentPage
    {
        public SleepPage()
        {
            InitializeComponent();
        }
        void Save_Button_Pressed(System.Object sender, System.EventArgs e)
        {
            try
            {
                float length = Convert.ToSingle(sleepLength.Text);
                string notes = sleepnotes.Text;
                App.todaysTarget.logSleep(length, notes);
                Navigation.PopAsync();
            }
            catch { DisplayAlert("Error", "Please fill all the information", "ok"); }

        }

        void ContentPage_Appearing(System.Object sender, System.EventArgs e)
        {
            BindingContext = App.todaysTarget.sleep;

        }

        void ContentPage_Disappearing(System.Object sender, System.EventArgs e)
        {
        }
    }
}