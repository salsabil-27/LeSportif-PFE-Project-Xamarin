using Microcharts;
using Microcharts.Forms;
using SkiaSharp;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LeSportif.Pages.Menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StatisticsPage : ContentPage
    {
        Performance.Daily daily_stats;
        Performance.Weekly weekly_stats;
        Performance.Monthly monthly_stats;

        public StatisticsPage()
        {
            daily_stats = new Performance.Daily(0, 0, 0);
            weekly_stats = new Performance.Weekly(0, 0, 0);
            monthly_stats = new Performance.Monthly(0, 0, 0);
            InitializeComponent();
             loadCharts();
        }

        public async Task loadCharts()
        {
            daily_stats.CalcPerformance();
            await weekly_stats.CalculateWeekly();
            await monthly_stats.CalculateMonthly();

            var dailyEntries = new[]
            {
                new ChartEntry(daily_stats.SleepDeficit)
                {
                    Label = "Sleep (hrs)",
                    ValueLabelColor=SKColor.Parse("#2596be"),
                    ValueLabel = App.todaysTarget.actualSleep.ToString(),
                    Color = SKColor.Parse("#2596be")
                   

                },


                new ChartEntry(daily_stats.CalorieDeficit)
                {
                    Label = "Calories",
                    ValueLabel = App.todaysTarget.actualCalories.ToString(),
                     ValueLabelColor=SKColor.Parse("#E8BFDF"),
                    Color = SKColor.Parse("#E8BFDF")
                },

                new ChartEntry(daily_stats.WorkoutDeficit)
                {
                    Label = "Workout (min)",
                    ValueLabel =  App.todaysTarget.actualWorkout.ToString(),
                    ValueLabelColor=SKColor.Parse("#96be25"),
                    Color = SKColor.Parse("#96be25")
                }
            };

            var weeklyEntries = new[]
            {
                new ChartEntry(weekly_stats.SleepDeficit)
                {

                  Color = SKColor.Parse("#2596be")
                },


                new ChartEntry(weekly_stats.CalorieDeficit)
                {

                    Color = SKColor.Parse("#E8BFDF")
                },

                new ChartEntry(weekly_stats.WorkoutDeficit)
                {
                    Color = SKColor.Parse("#96be25")
                }
            };

            var monthlyEntries = new[]
            {
                new ChartEntry(monthly_stats.SleepDeficit)
                {

                    Color = SKColor.Parse("#2596be")
                },


                new ChartEntry(monthly_stats.CalorieDeficit)
                {
                    Color = SKColor.Parse("#E8BFDF")
                },

                new ChartEntry(monthly_stats.WorkoutDeficit)
                {
                    Color = SKColor.Parse("#96be25")
                }
            };

            TodayChart.Chart = new RadialGaugeChart { Entries = dailyEntries, LabelTextSize = 30, MaxValue = 100, };
            WeekChart.Chart = new RadialGaugeChart { Entries = weeklyEntries, MaxValue = 100 };
            MonthChart.Chart = new RadialGaugeChart { Entries = monthlyEntries, MaxValue = 100 };
            
        }

        public async void LogSleep(System.Object sender, EventArgs e)
        {

            await Navigation.PushAsync(new SleepPage());

        }


        public async void LogWorkout(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new WorkoutPage());
        }

        public async void LogMeal(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new MealPage());
        }

        void ContentPage_Appearing(System.Object sender, System.EventArgs e)
        {
           App.appUser.setDailyTarget(App.todaysTarget);

            //check if its first time launching the app
            if (App.firstTimeLaunched == true || App.statsPageViewed == false)
            {
                //        DisplayAlert("Activity", "This page has buttons where you can log your meals, calories, and sleep. Below there are charts where you can track your progress!", "OK");
                App.statsPageViewed = true;
            }
            //want to reload charts in case anything has changed since leaving / coming back to the page
          loadCharts();
        }

        void ContentPage_Disappearing(System.Object sender, System.EventArgs e)
        {

        }
    }
}
