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
    public partial class MealPage : ContentPage
    {
        public MealPage()
        {
            InitializeComponent();
        }
     void  Save_Button_Pressed(object sender, EventArgs e)
        {  try
            {
                string name = Meal_Name.Text;
                int cals = int.Parse(Meal_Calories.Text);
                string notes = Meal_Notes.Text;
                App.todaysTarget.logMeal(name, cals, notes);
                Navigation.PopAsync();
            } catch (Exception)
            {
                DisplayAlert("Error", "Please fill all the information", "ok");
            }
        }
    }
}
