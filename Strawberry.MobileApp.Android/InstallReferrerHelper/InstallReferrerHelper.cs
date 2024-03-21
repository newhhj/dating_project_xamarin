using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Com.Android.Installreferrer.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Com.Android.Installreferrer.Api.InstallReferrerClient;

namespace Strawberry.MobileApp.Droid.InstallReferrerHelper
{
    public class InstallReferrerHelper : IDisposable
    {
        private Context Context { get; set; }
        private InstallReferrerClient ReferrerClient { get; set; }
        private InstallReferrerStateListener StateListener { get; set; }
        private TaskCompletionSource<bool> TaskCompletionSource { get; set; }

        public InstallReferrerHelper(Context context)
        {
            this.Context = context;
            this.ReferrerClient = NewBuilder(this.Context).Build();
            this.TaskCompletionSource = new TaskCompletionSource<bool>();
            this.StateListener = new InstallReferrerStateListener();
            this.StateListener.OnResponseOk += this.StateListener_OnResponseOk;
            this.StateListener.OnResponseDeveloperError += this.StateListener_OnResponseDeveloperError;
            this.StateListener.OnResponseFeatureNotSupported += this.StateListener_OnResponseFeatureNotSupported;
            this.StateListener.OnResponsePermissionError += this.StateListener_OnResponsePermissionError;
            this.StateListener.OnResponseServiceDisconnected += this.StateListener_OnResponseServiceDisconnected;
            this.StateListener.OnResponseServiceUnavailable += this.StateListener_OnResponseServiceUnavailable;
            this.StateListener.OnServiceDisconnected += this.StateListener_OnServiceDisconnected;
        }

        public async Task<string> GetReferrer()
        {
            var referrer = Xamarin.Essentials.Preferences.Get("referrer", null);
            if (!string.IsNullOrWhiteSpace(referrer))
                return referrer;

            if (!this.ReferrerClient.IsReady)
            {
                this.ReferrerClient.StartConnection(this.StateListener);
                await this.TaskCompletionSource.Task;
            }

            referrer = this.ReferrerClient.InstallReferrer.InstallReferrer;
            Xamarin.Essentials.Preferences.Set("referrer", referrer);

            return referrer;
        }

        private void StateListener_OnServiceDisconnected(object sender, EventArgs e)
        {
            this.TaskCompletionSource.SetException(new Exception("Disconnected"));
        }

        private void StateListener_OnResponseServiceUnavailable(object sender, EventArgs e)
        {
            this.TaskCompletionSource.SetException(new Exception("ServiceUnavailable"));
        }

        private void StateListener_OnResponseServiceDisconnected(object sender, EventArgs e)
        {
            this.TaskCompletionSource.SetException(new Exception("ServiceDisconnected"));
        }

        private void StateListener_OnResponsePermissionError(object sender, EventArgs e)
        {
            this.TaskCompletionSource.SetException(new Exception("PermissionError"));
        }

        private void StateListener_OnResponseFeatureNotSupported(object sender, EventArgs e)
        {
            this.TaskCompletionSource.SetException(new Exception("FeatureNotSupported"));
        }

        private void StateListener_OnResponseDeveloperError(object sender, EventArgs e)
        {
            this.TaskCompletionSource.SetException(new Exception("DeveloperError"));
        }

        private void StateListener_OnResponseOk(object sender, EventArgs e)
        {
            this.TaskCompletionSource.SetResult(true);
        }

        public void Dispose()
        {
            if (this.Context != null)
            {
                this.Context = null;
            }

            if (this.StateListener != null)
            {
                this.StateListener.Dispose();
                this.StateListener = null;
            }

            if (this.ReferrerClient != null)
            {
                this.ReferrerClient.EndConnection();
                this.ReferrerClient.Dispose();
                this.ReferrerClient = null;
            }

            if (this.TaskCompletionSource != null)
            {
                this.TaskCompletionSource = null;
            }
        }
    }

    public class InstallReferrerStateListener : Java.Lang.Object, IInstallReferrerStateListener
    {
        public event EventHandler OnResponseOk;
        public event EventHandler OnResponseFeatureNotSupported;
        public event EventHandler OnResponseServiceUnavailable;
        public event EventHandler OnResponseDeveloperError;
        public event EventHandler OnResponsePermissionError;
        public event EventHandler OnResponseServiceDisconnected;
        public event EventHandler OnServiceDisconnected;

        public void OnInstallReferrerServiceDisconnected()
        {
            this.OnServiceDisconnected.Invoke(this, EventArgs.Empty);
        }

        public void OnInstallReferrerSetupFinished(int responseCode)
        {
            switch (responseCode)
            {
                case InstallReferrerResponse.Ok:
                    this.OnResponseOk.Invoke(this, EventArgs.Empty);
                    break;
                case InstallReferrerResponse.FeatureNotSupported:
                    this.OnResponseFeatureNotSupported.Invoke(this, EventArgs.Empty);
                    break;
                case InstallReferrerResponse.ServiceUnavailable:
                    this.OnResponseServiceUnavailable.Invoke(this, EventArgs.Empty);
                    break;
                case InstallReferrerResponse.DeveloperError:
                    this.OnResponseDeveloperError.Invoke(this, EventArgs.Empty);
                    break;
                case InstallReferrerResponse.PermissionError:
                    this.OnResponsePermissionError.Invoke(this, EventArgs.Empty);
                    break;
                case InstallReferrerResponse.ServiceDisconnected:
                    this.OnResponseServiceDisconnected.Invoke(this, EventArgs.Empty);
                    break;
            }
        }
    }
}