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

       

        private async void Scan_Clicked(object sender, EventArgs e)
        {
            var scan = new ZXingScannerPage();
            
            await Navigation.PushModalAsync(scan);
            
            scan.OnScanResult += (result) =>
            {

                Device.BeginInvokeOnMainThread(async () =>
                {
                await Navigation.PopModalAsync();
                await DisplayAlert("This Machine is for:", "" + result.Text, "Explain how to use it with a video");
                    try
                    {
                        switch (result.Text)
                        {
                            case "Qr":

                             default:
                                break;
                            case "Lying Leg Curl":

                                await Navigation.PushAsync(new LyingLegPage());
                                break;
                            case "Shoulder Press":
                                await Navigation.PushAsync(new SHPage());
                                break;
                            case "Chest Press":
                                await Navigation.PushAsync(new ChestPressPage());
                                break;
                            case "Leg-Press":

                                await Navigation.PushAsync(new LeGPressPage());
                                break;
                            
                        }
                    }
                    catch (Exception ) {  }
                });



            };
        }

    }
}