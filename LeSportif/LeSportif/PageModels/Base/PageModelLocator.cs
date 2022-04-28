using LeSportif.Pages;
using LeSportif.Services.Account;
using LeSportif.Services.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using TinyIoC;
using Xamarin.Forms;

namespace LeSportif.PageModels.Base
{
    public class PageModelLocator
    {
        static TinyIoCContainer _container;
        static Dictionary<Type, Type> _viewlookup;

        static PageModelLocator()
        {
            _container = new TinyIoCContainer();
            _viewlookup = new Dictionary<Type, Type>();

            // Register Page and Page Models
         
           Register<LoginPageModel, LoginPage>();
            Register<ForgotPasswordPageModel, ForgotPasswordPage>();
            Register<RegisterPageModel, RegisterPage>();
            Register<AcceuilPageModel, AcceuilPage>();

            Register<CaloriesPageModel,CaloriesPage >();
            Register<FoodPageModel, FoodPage>();
            Register<ProfilPageModel, ProfilPage>();
            Register<GymPageModel, GymPage>();
            Register<CalciumPageMode, CalciumPage >();
            Register<ZincPageModel, ZincPage >();
            Register<MagnesiumPageModel, MagnesiumPage >();
            Register<IronPageModel, IronPage >();
            Register<ProteinPageModel, ProteinPage >();
            Register<Omega3PageModel, Omega3Page >();
            Register<CvitaminPageModel, CvitaminPage >();
            Register<EvitaminPageModel, EvitaminPage>();
            Register<ChestPressPageModel, ChestPressPage>();
            Register<LeGPressPageModel, LeGPressPage>();
            Register<LyingLegPageModel, LyingLegPage>();
            Register<SHPageModel, SHPage>();
            
            

            // Register Services (registered as Singletons by default)
            _container.Register<INavigationService, NavigationService>();
         
            _container.Register(DependencyService.Get<IAccountService>());
        }
        public static T Resolve<T>() where T : class
        {
            return _container.Resolve<T>();

        }
        public static Page CreatePageFor<TPageModelType>() where TPageModelType : PageModelBase
        {
            Type pageModelType = typeof(TPageModelType);
            var pageType = _viewlookup[pageModelType];
            var page = (Page)Activator.CreateInstance(pageType);
            var pageModel = Resolve<TPageModelType>();
            page.BindingContext = pageModel;
            return page;
        }
        static void Register<TPageModel, TPage>() where TPageModel : PageModelBase where TPage : Page
        {
            _viewlookup.Add(typeof(TPageModel), typeof(TPage));
            _container.Register<TPageModel>();

        }



    }
}
