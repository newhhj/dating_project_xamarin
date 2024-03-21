using Strawberry.MobileApp.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly:Dependency(typeof(Strawberry.MobileApp.iOS.DeviceHelper))]
namespace Strawberry.MobileApp.iOS
{
    public class DeviceHelper : IDeviceHelper
    {
		public bool CheckAudioPermission()
		{
			throw new NotImplementedException();
		}

		public async Task<string> GetPushToken()
        {
            //var token = await FirebaseMessaging.Instance.GetToken();
            //return (string)token;
            throw new Exception();
        }

        public async Task<string> GetReferrer()
        {
            await Task.Delay(1);
            return Xamarin.Essentials.Preferences.Get("referrer", null);
        }

		public void Vibrate()
		{
			throw new NotImplementedException();
		}
	}
}