﻿using System;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LeSportif.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditPage : ContentPage
    { public static User appUser;

        public EditPage()
        {
            try { 
            InitializeComponent();
            BindingContext = App.appUser; }
            catch(Exception) { }
        }
        void OnSliderValueChanged(object sender, ValueChangedEventArgs args)
        {
            double value = args.NewValue;
            CalorieValueLabel.Text = String.Format("{0}", value);
        }

        void OnSleepValueChanged(object sender, ValueChangedEventArgs args)
        {
            double value = args.NewValue;
            SleepValueLabel.Text = String.Format("{0}", value);
        }

        void PageAppearing(System.Object sender, System.EventArgs e)
        {

        }
        void ContentPage_Disappearing(System.Object sender, System.EventArgs e)
        {

        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {

            App.appUser.name = NameEntry.Text;
            App.appUser.gender = (string)GenderEntry.SelectedItem;
            App.appUser.height = Convert.ToInt32(HeightEntry.Text);
            App.appUser.weight = Convert.ToInt32(WeightEntry.Text);
            App.todaysTarget.calorieTarget = Convert.ToInt32(CalorieSlider.Value);
            App.todaysTarget.workoutTarget = Convert.ToInt32(WorkoutTarget.Text);
            App.todaysTarget.sleepTarget = Convert.ToSingle(SleepSlider.Value);
            App.appUser.setDailyTarget(App.todaysTarget);

            Navigation.PopAsync();
        }
    } }