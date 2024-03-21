using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Strawberry.MobileApp.Helpers
{
    public interface IDeviceHelper
    {
        Task<string> GetPushToken();

        Task<string> GetReferrer();

        bool CheckAudioPermission();

        void Vibrate();
    }
}
