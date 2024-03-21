using Strawberry.MobileApp.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Strawberry.MobileApp
{
    public class Settings
    {
#if DEBUG
        //public const string ServerUrl = "http://aijinrua.iptime.org:50000";
        public const string ServerUrl = "http://175.125.94.223:50000";

#else
        public const string ServerUrl = "http://strawberrylove.co.kr:50000"; //이거 때문
#endif
		public static User User
		{
			get; set;
		}
		public static Task<string> GetApiKey()
        {
            return Xamarin.Essentials.SecureStorage.GetAsync("ApiKey");
        }

        public static Task SetApiKey(string apikey)
        {
            if (string.IsNullOrWhiteSpace(apikey))
            {
                return Task.Run(() => { Xamarin.Essentials.SecureStorage.Remove("ApiKey"); });
            }
            else
            {
                return Xamarin.Essentials.SecureStorage.SetAsync("ApiKey", apikey);
            }
        }
    }
}
