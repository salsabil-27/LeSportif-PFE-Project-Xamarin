using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LeSportif
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImageButton : ContentView
    {
        public event EventHandler Clicked;

        public ImageButton()
        {
            InitializeComponent();
            TapGestureRecognizer tap = new TapGestureRecognizer();
            tap.Command = new Command(OnClicked);
            GestureRecognizers.Add(tap);
        }

        public void OnClicked(object sender)
        {
            if (Clicked != null)
            {
                this.Clicked(this, EventArgs.Empty);
            }
        }
        public string Icon
        {
            get
            {
                return lblIcon.Text;
            }
            set
            {
                lblIcon.Text = value;
            }
        }

        public string Text
        {
            get
            {
                return lblText.Text;
            }
            set
            {
                lblText.Text = value;
            }
        }
    }
}