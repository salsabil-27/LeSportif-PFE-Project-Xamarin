using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Gms.Tasks;
using System;


namespace LeSportif.Droid.EventListeners
{
    class OnCompleteEventHandleListener : Java.Lang.Object, IOnCompleteListener
    {
        private readonly Action<Task> _completeAction;

        public OnCompleteEventHandleListener(Action<Task> completeAction)
        {
            _completeAction = completeAction;
        }
        public void OnComplete(Task task) => _completeAction(task);
    }
}