using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LeSportif.Pages.Menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlyoutMenuPageFlyout : ContentPage
    {
        public ListView ListView;

        public FlyoutMenuPageFlyout()
        {
            InitializeComponent();

            BindingContext = new FlyoutMenuPageFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        class FlyoutMenuPageFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<FlyoutMenuPageFlyoutMenuItem> MenuItems { get; set; }

            public FlyoutMenuPageFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<FlyoutMenuPageFlyoutMenuItem>(new[]
                {
                  new FlyoutMenuPageFlyoutMenuItem { Id = 0, Title = "Profile" ,TargetType=typeof(FlyoutMenuPageDetail) ,IconSource ="user.png"},
                    new FlyoutMenuPageFlyoutMenuItem { Id = 1, Title = "Messages" ,TargetType=typeof(MessagesPage) ,IconSource ="message.png"},
                    new FlyoutMenuPageFlyoutMenuItem { Id = 2, Title = "Statistics" ,TargetType=typeof(StatisticsPage) ,IconSource ="heartbeat.png"},
                    new FlyoutMenuPageFlyoutMenuItem { Id = 3, Title = "Settings" ,TargetType=typeof(SettingsPage) ,IconSource ="settings.png"},
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}