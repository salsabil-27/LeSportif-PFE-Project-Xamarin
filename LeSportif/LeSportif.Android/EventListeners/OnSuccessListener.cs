using Android.App;
using Android.Content;
using Android.Gms.Tasks;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeSportif.Droid.EventListeners
{
    class OnSuccessListener : Java.Lang.Object, IOnSuccessListener
    {
        private readonly Action<Java.Lang.Object> _SuccessAction;

        public OnSuccessListener(Action<Java.Lang.Object> SuccessAction)
        {
            _SuccessAction = SuccessAction;
        }

        public void OnSuccess(Java.Lang.Object result) => _SuccessAction(result);
    }
}