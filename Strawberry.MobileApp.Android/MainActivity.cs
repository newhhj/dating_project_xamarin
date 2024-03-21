using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Firebase.Messaging;
using Android.Views;
using Android.Widget;
using Com.Android.Installreferrer.Api;
using Android.Content.Res;

namespace Strawberry.MobileApp.Droid
{
    [Activity(
        MainLauncher = true, 
        LaunchMode = LaunchMode.SingleTop,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize,
        ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public static MainActivity Instance { get; private set; }

        public bool LieAboutCurrentFocus { get; private set; }


        #region 글꼴 크기 고정 코드
        public override Resources Resources
        {
            get
            {
                Resources resource = base.Resources;
                Configuration configuration = new Configuration();
                configuration.SetToDefaults();
                if (Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.NMr1)
                {
                    return CreateConfigurationContext(configuration).Resources;
                }
                else
                {
#pragma warning disable CS0618 // 형식 또는 멤버는 사용되지 않습니다.
                    resource.UpdateConfiguration(configuration, resource.DisplayMetrics);
#pragma warning restore CS0618 // 형식 또는 멤버는 사용되지 않습니다.
                    return resource;
                } 
            }
        }
        #endregion

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Instance = this;

            this.Window.AddFlags(WindowManagerFlags.Secure);

            //KakaoSDK.Init(new DefaultKakaoAdapter(AuthType.KakaoLoginAll));
            Rg.Plugins.Popup.Popup.Init(this);
            MediaManager.CrossMediaManager.Current.Init();
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            Xamarin.Forms.Forms.Init(this, savedInstanceState);
            FFImageLoading.Forms.Platform.CachedImageRenderer.Init(enableFastRenderer: true);
            FFImageLoading.Forms.Platform.CachedImageRenderer.InitImageViewHandler();
            Xamarin.FormsMaps.Init(this, savedInstanceState);
			global::Xamarin.Auth.Presenters.XamarinAndroid.AuthenticationConfiguration.Init(this, savedInstanceState);
			LoadApplication(new App());
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public override void OnBackPressed()
        {
            Rg.Plugins.Popup.Popup.SendBackPressed(base.OnBackPressed);
        }



        public override bool DispatchTouchEvent(MotionEvent ev)
        {
            var result = false;

            try
            {
                LieAboutCurrentFocus = CurrentFocus != null && CurrentFocus is EditText;
                result = base.DispatchTouchEvent(ev);
                LieAboutCurrentFocus = false;
            }
            catch (Exception ex)
            {
                while (ex != null)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                    System.Diagnostics.Debug.WriteLine(ex.StackTrace);
                    ex = ex.InnerException;
                }
            }

            return result;
        }

        public override View CurrentFocus
        {
            get
            {
                if (LieAboutCurrentFocus)
                    return null;

                return base.CurrentFocus;
            }
        }
    }
}