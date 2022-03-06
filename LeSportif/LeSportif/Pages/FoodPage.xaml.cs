using LeSportif.Services.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LeSportif.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

   partial class FoodPage : ContentPage
    { public string M;
        public FoodPage()
        {
            InitializeComponent();
        }

        private async void Zinc_Clicked(object sender, EventArgs e)
        {
            try
            {
                await Navigation.PushAsync(new ZincPage());
            }
            catch (Exception ex) { M = ex.Message; }
        }

        private async void Calcium_Clicked(object sender, EventArgs e)
            
        {  try
            {
                await Navigation.PushAsync(new CalciumPage());
            }
            catch (Exception ex) { M = ex.Message; }

        }

        private async void magnesium_Clicked(object sender, EventArgs e)
        {
            try
            {
                await Navigation.PushAsync(new MagnesiumPage());
            }
            catch (Exception ex) { M = ex.Message; }
        }

        private async void Iron_Clicked(object sender, EventArgs e)
        {
            try
            {
                await Navigation.PushAsync(new IronPage());
            }
            catch (Exception ex) { M = ex.Message; }
        }

        private async void protein_Clicked(object sender, EventArgs e)
        {
            try
            {
                await Navigation.PushAsync(new ProteinPage());
            }
            catch (Exception ex) { M = ex.Message; }
        }
        private async void Omega3_Clicked(object sender, EventArgs e)
        {
            try
            {
                await Navigation.PushAsync(new Omega3Page());
            }
            catch (Exception ex) { M = ex.Message; }
        }

        private async void Evitamin_Clicked(object sender, EventArgs e)
        {
            try
            {
                await Navigation.PushAsync(new EvitaminPage());
            }
            catch (Exception ex) { M = ex.Message; }
        }

        private async void Cvitamin_Clicked(object sender, EventArgs e)
        {
            try
            {
                await Navigation.PushAsync(new CvitaminPage());
            }
            catch (Exception ex) { M = ex.Message; }
        }

       
    }
}
