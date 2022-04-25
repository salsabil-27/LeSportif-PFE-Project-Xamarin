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
    public partial class WorkoutPage : ContentPage
    {
        public WorkoutPage()
        {
            InitializeComponent();
        }
        void Save_Button_Pressed(System.Object sender, System.EventArgs e)
        {
            try
            {
                string type = (string)Workout_Type.SelectedItem;
                int length = int.Parse(Workout_Time.Text);
                string notes = Workout_Notes.Text;
                App.todaysTarget.logWorkout(type, length, notes);
                Navigation.PopAsync();

            }
            catch (Exception)
            {
                DisplayAlert("Error", "Please fill all the information", "ok");
            }
        }
    }
}