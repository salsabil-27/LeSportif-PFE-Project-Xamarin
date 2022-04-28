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
    class OnFailureListener : Java.Lang.Object, IOnFailureListener
    {
        private readonly Action<Java.Lang.Exception> _FailureAction;

        public OnFailureListener(Action<Java.Lang.Exception> FailureAction)
        {
            _FailureAction = FailureAction;

        }

        public void OnFailure(Java.Lang.Exception e) => _FailureAction(e);

    }
}