using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing;
using ZXing.Net.Mobile.Forms;

namespace LeSportif.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GymPage : ContentPage
    {
        public GymPage()
        {
            InitializeComponent();
        }

        public string Legs;
        public string Shoulder;
        public string M;
        

        private async void Scan_Clicked(object sender, EventArgs e)
        {
            var scan = new ZXingScannerPage();
            
            await Navigation.PushModalAsync(scan);

            scan.OnScanResult += (result) =>
            {

                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Navigation.PopModalAsync();
                    await DisplayAlert("This Machine is for:", "" + result.Text, "Go to Video");
                    await Navigation.PushAsync(new EquipementPage());

                });


            };
        }

    
       // public void HandleResult(ZXing.Result rawResult)
        //{ ProcessResult(rawResult.Text); }
        //private async void ProcessResult(string text)
       // {
            //if (text.StartsWith("legs"))
            //{
               // await Navigation.PushAsync(new LegsPage());
           // }
       // }


    }
}