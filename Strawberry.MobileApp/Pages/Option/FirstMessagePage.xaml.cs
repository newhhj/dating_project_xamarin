using MediaManager;
using Plugin.AudioRecorder;
using Strawberry.MobileApp.Helpers;
using Strawberry.MobileApp.Pages.Shares;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Strawberry.MobileApp.Pages.Option
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FirstMessagePage : BasePage
    {
        public FirstMessagePageData PageData { get => this.pageData; set => this.pageData = value; }
        public AudioRecorderService AudioRecorder { get; private set; }
        public bool RecordIsCanceled { get; set; }

        public FirstMessagePage()
        {
            InitializeComponent();
        }

        private void PageInitalize()
        {
            this.AudioRecorder = new AudioRecorderService
            {
                StopRecordingOnSilence = false, //will stop recording after 2 seconds (default)
                StopRecordingAfterTimeout = true,  //stop recording after a max timeout (defined below)
                TotalAudioTimeout = TimeSpan.FromSeconds(10) //audio will stop recording after 15 seconds,
            };

            this.AudioRecorder.AudioInputReceived += this.Recorder_AudioInputReceived;
        }

        public async Task GetPageDataAsync()
        {
            using (var api = new ApiHelper())
            {
                var result = await api.GetFirstMessagePageData(
                    new
                    {
                        FirstMessage = default(string),
                        VoicePath = default(string),
                    });

                this.PageData.FirstMessage = result.FirstMessage;
                this.PageData.VoicePath = result.VoicePath;

                if (!string.IsNullOrWhiteSpace(this.PageData.VoicePath))
                    this.PageData.PageStateType = FirstMessagePageData.PageStateTypes.Play;
            }
        }

        public async Task ShowPageAsync()
        {
            this.PageInitalize();
            await this.GetPageDataAsync();
            await App.Instance.MainPage.Navigation.PushAsync(this);
        }

        private async void TimeBarAnim()
        {
            int workCount = 0;
            var parent = (Grid)this.timebar.Parent;

            start:
            if (workCount++ > 100)
                return;

            var width = parent.Width;
            if (width < 10)
            {
                await Task.Delay(30);
                goto start;
            }

            this.timebar.Animate("timebaranim", (duration) =>
            {
                this.timebar.WidthRequest = width * duration;
            }, 16, 10000);
        }

        private void Recorder_AudioInputReceived(object sender, string filePath)
        {
            if (this.RecordIsCanceled || string.IsNullOrWhiteSpace(filePath))
            {
                if (!string.IsNullOrWhiteSpace(filePath))
                    File.Delete(filePath);
                this.PageData.VoicePath = null;
            }
            else
            {
                this.PageData.VoicePath = filePath;
            }
        }

        private void ClosePage_Clicked(object sender, EventArgs e)
        {
            if (this.AudioRecorder.IsRecording)
            {
                this.RecordIsCanceled = true;
                this.AudioRecorder.StopRecording();
            }
            this.Navigation.PopAsync();
        }

        private async void Accept_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IDeviceHelper>().Vibrate();

            lock (this.LockData)
            {
                if (this.LockData.IsLocked)
                    return;
                this.LockData.IsLocked = true;
            }

            try
            {
                var buffer = default(byte[]);
                var filename = default(string);
                if (!string.IsNullOrWhiteSpace(this.PageData.VoicePath) && !this.PageData.VoicePath.StartsWith("http"))
                {
                    using (var stream = File.OpenRead(this.PageData.VoicePath))
                    using (var memoryStream = new MemoryStream())
                    {
                        stream.CopyTo(memoryStream);
                        buffer = memoryStream.ToArray();
                        filename = Path.GetFileName(this.PageData.VoicePath);
                    }
                }

                using (var api = new ApiHelper())
                {
                    await api.ExcuteFirstMessage(
                        this.PageData.FirstMessage,
                        this.PageData.IsRemoveVoice,
                        buffer,
                        filename);
                }

                await App.Instance.MainPage.DisplayToastAsync("적용되었습니다.");
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                    ex = ex.InnerException;
                await App.Instance.MainPage.DisplayToastAsync(ex.Message);
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }

        private async void None_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IDeviceHelper>().Vibrate();

            lock (this.LockData)
            {
                if (this.LockData.IsLocked)
                    return;
                this.LockData.IsLocked = true;
            }

            try
            {
                if (!DependencyService.Get<IDeviceHelper>().CheckAudioPermission())
                    return;

                this.PageData.PageStateType = FirstMessagePageData.PageStateTypes.Rec;
                this.TimeBarAnim();
                this.RecordIsCanceled = false;
                await this.AudioRecorder.StartRecording();
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                    ex = ex.InnerException;

                await App.Instance.MainPage.DisplayToastAsync(ex.Message);
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }

        private async void CancelRec_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IDeviceHelper>().Vibrate();

            lock (this.LockData)
            {
                if (this.LockData.IsLocked)
                    return;
                this.LockData.IsLocked = true;
            }

            try
            {
                this.RecordIsCanceled = true;
                await this.AudioRecorder.StopRecording();
                this.PageData.PageStateType = FirstMessagePageData.PageStateTypes.None;
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                    ex = ex.InnerException;
                await App.Instance.MainPage.DisplayToastAsync(ex.Message);
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }

        private async void SaveVoice_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IDeviceHelper>().Vibrate();

            lock (this.LockData)
            {
                if (this.LockData.IsLocked)
                    return;
                this.LockData.IsLocked = true;
            }

            try
            {
                if (this.AudioRecorder.IsRecording)
                {
                    await this.AudioRecorder.StopRecording();
                }

                this.PageData.PageStateType = FirstMessagePageData.PageStateTypes.Play;
                this.PageData.IsRemoveVoice = false;
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                    ex = ex.InnerException;
                await App.Instance.MainPage.DisplayToastAsync(ex.Message);
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }

        private async void PlayVoice_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IDeviceHelper>().Vibrate();

            lock (this.LockData)
            {
                if (this.LockData.IsLocked)
                    return;
                this.LockData.IsLocked = true;
            }

            try
            {
                if (!string.IsNullOrWhiteSpace(this.PageData.VoicePath))
                    await CrossMediaManager.Current.Play(this.PageData.VoicePath);
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                    ex = ex.InnerException;
                await App.Instance.MainPage.DisplayToastAsync(ex.Message);
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }

        private async void RemoveVoice_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IDeviceHelper>().Vibrate();

            lock (this.LockData)
            {
                if (this.LockData.IsLocked)
                    return;
                this.LockData.IsLocked = true;
            }

            try
            {
                this.PageData.VoicePath = null;
                this.PageData.PageStateType = FirstMessagePageData.PageStateTypes.None;
                this.PageData.IsRemoveVoice = true;
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                    ex = ex.InnerException;
                await App.Instance.MainPage.DisplayToastAsync(ex.Message);
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }
    }

    public class FirstMessagePageData : BindableObject
    {
        public enum PageStateTypes
        {
            None = 0,
            Rec = 1,
            Play = 2
        }

        public bool IsRemoveVoice { get => (bool)GetValue(IsRemoveVoiceProperty); set => SetValue(IsRemoveVoiceProperty, value); }
        public static readonly BindableProperty IsRemoveVoiceProperty = BindableProperty.Create(nameof(IsRemoveVoice), typeof(bool), typeof(FirstMessagePageData), false);

        public string FirstMessage { get => (string)GetValue(FirstMessageProperty); set => SetValue(FirstMessageProperty, value); }
        public static readonly BindableProperty FirstMessageProperty = BindableProperty.Create(nameof(FirstMessage), typeof(string), typeof(FirstMessagePageData));

        public string VoicePath { get => (string)GetValue(VoicePathProperty); set => SetValue(VoicePathProperty, value); }
        public static readonly BindableProperty VoicePathProperty = BindableProperty.Create(nameof(VoicePath), typeof(string), typeof(FirstMessagePageData));

        public PageStateTypes PageStateType { get => (PageStateTypes)GetValue(PageStateTypeProperty); set => SetValue(PageStateTypeProperty, value); }
        public static readonly BindableProperty PageStateTypeProperty = BindableProperty.Create(nameof(PageStateType), typeof(PageStateTypes), typeof(FirstMessagePageData), PageStateTypes.None);

        public bool IsVisibleNone { get => (bool)GetValue(IsVisibleNoneProperty); set => SetValue(IsVisibleNoneProperty, value); }
        public static readonly BindableProperty IsVisibleNoneProperty = BindableProperty.Create(nameof(IsVisibleNone), typeof(bool), typeof(FirstMessagePageData), true);

        public bool IsVisibleRec { get => (bool)GetValue(IsVisibleRecProperty); set => SetValue(IsVisibleRecProperty, value); }
        public static readonly BindableProperty IsVisibleRecProperty = BindableProperty.Create(nameof(IsVisibleRec), typeof(bool), typeof(FirstMessagePageData), false);

        public bool IsVisiblePlay { get => (bool)GetValue(IsVisiblePlayProperty); set => SetValue(IsVisiblePlayProperty, value); }
        public static readonly BindableProperty IsVisiblePlayProperty = BindableProperty.Create(nameof(IsVisiblePlay), typeof(bool), typeof(FirstMessagePageData), false);

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            switch (propertyName)
            {
                case nameof(PageStateType):
                    this.SetIsVisibleUI();
                    break;
                default:
                    break;
            }
        }

        private void SetIsVisibleUI()
        {
            this.IsVisibleNone = this.PageStateType == PageStateTypes.None;
            this.IsVisibleRec = this.PageStateType == PageStateTypes.Rec;
            this.IsVisiblePlay = this.PageStateType == PageStateTypes.Play;
        }
    }
}