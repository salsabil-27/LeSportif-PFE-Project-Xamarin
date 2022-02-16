using LeSportif.PageModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LeSportif.PageModels
{

    public class AcceuilPageModel : PageModelBase
    {
        private ProfilPageModel _profile;
        public ProfilPageModel ProfilePageModel
        {
            get => _profile;
            set => SetProperty(ref _profile, value);
        }

        private CaloriesPageModel _Calories;
        public CaloriesPageModel CaloriesPageModel
        {
            get => _Calories;
            set => SetProperty(ref _Calories, value);
        }

        private FoodPageModel _Food;
        public FoodPageModel FoodPageModel
        {
            get => _Food;
            set => SetProperty(ref _Food, value);
        }

        private GymPageModel _Gym;
        public GymPageModel GymPageModel
        {
            get => _Gym;
            set => SetProperty(ref _Gym, value);
        }

        public AcceuilPageModel(ProfilPageModel profile,
             CaloriesPageModel Calories,
            FoodPageModel Food,
            GymPageModel Gym)
        {
            ProfilePageModel = profile;
            CaloriesPageModel = Calories;
            FoodPageModel = Food;
            GymPageModel = Gym;


        }

        public override Task InitializeAsync(object navigationData)
        {
            return Task.WhenAny(base.InitializeAsync(navigationData),
                ProfilePageModel.InitializeAsync(null),
                CaloriesPageModel.InitializeAsync(null),
               FoodPageModel.InitializeAsync(null),
                GymPageModel.InitializeAsync(null));




        }
    }
}
