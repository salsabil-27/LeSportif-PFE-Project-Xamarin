﻿using LeSportif.PageModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LeSportif.Pages
{

    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class CaloriesPage : ContentPage
    {

        public double kcal;
        public double Bmi;



        public CaloriesPage()
        {
            
                InitializeComponent();
         
        }
        private async void Calculate_Clicked(object sender, EventArgs e)
        {
            try
            {
                var Weight = double.Parse(weight.Text);
                var Height = double.Parse(height.Text);
                var Age = int.Parse(age.Text);
                if (!string.IsNullOrEmpty(weight.Text) && !string.IsNullOrEmpty(height.Text) && !string.IsNullOrEmpty(age.Text))
                {


                    if (woman.IsChecked)
                    {
                        kcal = (10 * Weight) + (6.25 * Height) - (5 * Age) - 161;

                    }
                    else
                    {
                        kcal = (10 * Weight) + (6.25 * Height) - (5 * Age) + 5;

                    }
                    await DisplayAlert("Result", $"Your daily calorie requirement are:{kcal}", "ok");


                }
                else
                {
                    await DisplayAlert("Error", "Please fill all the information", "ok");

                }
            }catch (Exception){
                await DisplayAlert("Error", "Please fill all the information", "ok");
            }

        }

        private async void BMI_Clicked(object sender, EventArgs e)
        {
          try
          { 
            var Weight = double.Parse(weight.Text);
            var Height = double.Parse(height.Text);


           
               if (!string.IsNullOrEmpty(weight.Text) && !string.IsNullOrEmpty(height.Text))
                    
                    {
                        Bmi = Math.Round(Weight / Math.Pow(Height / 100, 2), 2);
                        string resultat = "";
                        if (Bmi < 18.5)
                            resultat = "You are underweight";
                        else if (Bmi < 25)
                            resultat = "You have a normal weight";
                        else if (Bmi < 30)
                            resultat = "You are overweight";
                        else
                            resultat = "You are obese";
                        await DisplayAlert("Result", $"Your BMI Is :{Bmi}", "ok", resultat);
               }
           
          }
          catch (Exception)
          { await DisplayAlert("Error", "Please fill all the information", "ok"); }
        }
    }
}


    
