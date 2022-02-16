using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LeSportif.PageModels.Base
{
    // sharebale code  that we want to put into our model base 
    public class PageModelBase : BindableObject
    {
        string _title;
        /// <summary>
        /// Title of the Page, settable in the PageModel
        /// </summary>
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        bool _isLoading;
        /// <summary>
        /// Flag to notify the Page on network activity
        /// </summary>
        public bool IsLoading
        {
            get => _isLoading;
            set => SetProperty(ref _isLoading, value);
        }


        /// <summary>
        /// Performs Page Model initialization Asynchronously
        /// </summary>
        /// <param name="navigationData"></param>
        /// <returns></returns>
        public virtual Task InitializeAsync(object navigationData)
        {
            return Task.CompletedTask;
        }
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return false;

            }
            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }



    }
}
