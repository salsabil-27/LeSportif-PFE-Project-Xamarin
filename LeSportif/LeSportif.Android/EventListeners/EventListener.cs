using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeSportif.Droid.EventListeners
{
    public class EventListener : Java.Lang.Object, IEventListener
    {
        private readonly Action<Java.Lang.Object, FirebaseFirestoreException> _eventAction;

        public EventListener(Action<Java.Lang.Object, FirebaseFirestoreException> eventAction)
        {
            _eventAction = eventAction;
        }

        public void OnEvent(Java.Lang.Object obj, FirebaseFirestoreException exception) => _eventAction(obj, exception);
    }
}