using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LeSportif.Pages.Menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlyoutMenuPageDetail : ContentPage
    {
        public FlyoutMenuPageDetail()
        {
            InitializeComponent();
            BindingContext = App.appUser;
            loadCharts();
            WorkoutGoal.Text = App.todaysTarget.workoutTarget.ToString();
            calorieSlider.Text = App.todaysTarget.calorieTarget.ToString();
            sleepSlider.Text = App.todaysTarget.sleepTarget.ToString();
            //  Weight.Text== App.todaysTarget.sleepTarget.ToString();
        }
        void ContentPage_Appearing(System.Object sender, System.EventArgs e)
        {
            resetBinding();
        }

        void ContentPage_Disappearing(System.Object sender, System.EventArgs e)
        {

        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new EditPage());
        }

        void resetBinding()
        {
            DailyTarget target = App.todaysTarget;
            this.BindingContext = null;
            this.BindingContext = App.appUser;
            WorkoutGoal.Text = target.workoutTarget.ToString();
            calorieSlider.Text = target.calorieTarget.ToString();
            sleepSlider.Text = target.sleepTarget.ToString();


        }
        public async Task loadCharts()
        {



        }


    }
}

