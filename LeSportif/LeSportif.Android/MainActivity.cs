using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Xamarin.Forms;
using System.Net.NetworkInformation;
using LibVLCSharp.Forms.Shared;
using Firebase;

namespace LeSportif.Droid
{
    [Activity(Label = "LeSportif", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public static FirebaseApp app;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            LibVLCSharpFormsRenderer.Init();
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            ZXing.Net.Mobile.Forms.Android.Platform.Init();
            InitiFirebaseAuth();
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            ZXing.Net.Mobile.Android.PermissionsHandler.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        private void InitiFirebaseAuth()
        {
            var options = new FirebaseOptions.Builder()
                .SetApplicationId("1:291090906808:android:dba9fef55c7221e12b7e4d")
                .SetApiKey("AIzaSyB9UfKvPAAZKHOGdHchRnTovXL0XPtQpQY")
                .SetProjectId("lesportif-40abb")
                .SetStorageBucket("lesportif-40abb.appspot.com")
                .SetDatabaseUrl("https://lesportif-40abb-default-rtdb.firebaseio.com/")
                .Build();

            if (app == null)
            {
                app = FirebaseApp.InitializeApp(this, options, "LeSportif22");
            }
        }
    }
}