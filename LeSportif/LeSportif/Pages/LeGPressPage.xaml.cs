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
    public partial class LeGPressPage : ContentPage
    {
        public LeGPressPage()
        {
            InitializeComponent();
            var htmlcontent = new HtmlWebViewSource();
            htmlcontent.Html = "<html><head> </head><body>" + "<iframe width='560'' height='315'' src='https://www.youtube.com/embed/8EMbB0tCn7Q'" + " title='YouTube video player' frameborder='0' allow='accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture'  allowfullscreen></iframe>" + "</body></html>";

        }
    }
}