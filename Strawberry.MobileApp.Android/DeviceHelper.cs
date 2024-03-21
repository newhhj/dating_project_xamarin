using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Content.Res;
using Android.Gms.Extensions;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.Core.App;
using AndroidX.Core.Content;
using FFImageLoading;
using Firebase.Messaging;
using Java.IO;
using Strawberry.MobileApp.Droid.InstallReferrerHelper;
using Strawberry.MobileApp.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly:Dependency(typeof(Strawberry.MobileApp.Droid.DeviceHelper))]
namespace Strawberry.MobileApp.Droid
{
    public class DeviceHelper : IDeviceHelper
    {

        public async Task<string> GetPushToken()
        {
            var token = await FirebaseMessaging.Instance.GetToken();
            return (string)token;
        }

        public async Task<string> GetReferrer()
        {
            using (var referrerHelper = new InstallReferrerHelper.InstallReferrerHelper(Android.App.Application.Context))
            {
                return await referrerHelper.GetReferrer();
            }
        }

        public bool CheckAudioPermission()
        {
            if (ContextCompat.CheckSelfPermission(MainActivity.Instance, Manifest.Permission.RecordAudio) !=  Permission.Granted)
            {
                ActivityCompat.RequestPermissions(MainActivity.Instance, new string[] { Manifest.Permission.RecordAudio }, 1);
                return false;
            }
            else
            {
                return true;
            }
        }

        public void Vibrate()
        {
            var vibrator = (Vibrator)MainActivity.Instance.GetSystemService(Context.VibratorService);
            vibrator.Vibrate(VibrationEffect.CreateOneShot(50, 255));
        }
    }
}