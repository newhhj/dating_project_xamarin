using FFImageLoading;
using FFImageLoading.Forms;
using Strawberry.MobileApp.Helpers;
using Strawberry.MobileApp.Pages.Shares;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Strawberry.MobileApp.Pages.Appeal
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppealWritePage : BasePage
    {
        private TaskCompletionSource<bool> TaskCompletionSource { get; set; }

        public AppealWritePage(AppealPage_Data.ContentTypes type)
        {
            InitializeComponent();
            this.TaskCompletionSource = new TaskCompletionSource<bool>();
            this.pageData.ContentType = type;
        }

        protected override bool OnBackButtonPressed()
        {
            var result = base.OnBackButtonPressed();
            this.TaskCompletionSource.SetResult(false);
            return result;
        }

        public Task<bool> ShowAsync()
        {
            App.Instance.MainPage.Navigation.PushAsync(this);
            return TaskCompletionSource.Task;
        }

        private async void Area_Clicked(object sender, EventArgs e)
        {
            var helper = new AreaCodeHelper();
            var sidoList = helper.GetSiDo();
            var sido = await this.DisplayActionSheet("시,도 선택", "취소", null, sidoList);
            if (sido == null || sido == "취소")
                return;

            var gugunList = helper.GetGuGun(sido);
            if (gugunList == null || gugunList.Length == 0)
            {
                this.pageData.Area = sido;
                return;
            }

            var gugun = await this.DisplayActionSheet("구,군 선택", "취소", null, gugunList);
            if (gugun == null || gugun == "취소")
                return;

            this.pageData.Area = $"{sido} {gugun}";
        }

        private async void Time_Clicked(object sender, EventArgs e)
        {
            var list = new List<string>();
            for (int i = 1; i <= 24; i++)
                list.Add($"{i:00}시");

            var result = await this.DisplayActionSheet("시간 선택", "취소", null, list.ToArray());
            if (result != null && result != "취소")
                this.pageData.Time = result;
        }

        private async void Image_Clicked(object sender, EventArgs e)
        {
            lock (this.LockData)
            {
                if (this.LockData.IsLocked)
                    return;
                this.LockData.IsLocked = true;
            }

            try
            {
                var data = await this.TakeImageAsync();
                if (data.buffer != null)
                {
                    var element = (CachedImage)sender;
                    element.Source = ImageSource.FromStream(() => { return new MemoryStream(data.buffer); });
                }
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }

        private void BackButton_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
            this.TaskCompletionSource.SetResult(false);
        }

        private async void AcceptButton_Clicked(object sender, EventArgs e)
        {
            lock (this.LockData)
            {
                if (this.LockData.IsLocked)
                    return;
                this.LockData.IsLocked = true;
            }

            try
            {
                var streamImageSources = this.pageData.Images
                    .Where(x => x is StreamImageSource)
                    .ToArray();

                if (this.pageData.ContentType == AppealPage_Data.ContentTypes.Boast ||
                    this.pageData.ContentType == AppealPage_Data.ContentTypes.Metting ||
                    this.pageData.ContentType == AppealPage_Data.ContentTypes.Sell)
                {
                    if (streamImageSources.Length == 0)
                        throw new Exception("하나 이상의 이미지를 등록해주세요.");
                }

                if (this.pageData.ContentType == AppealPage_Data.ContentTypes.Metting)
                {
                    if (string.IsNullOrWhiteSpace(this.pageData.Area))
                        throw new Exception("지역을 선택해주세요.");

                    if (string.IsNullOrWhiteSpace(this.pageData.Time))
                        throw new Exception("시간을 선택해주세요.");
                }

                if (this.pageData.ContentType == AppealPage_Data.ContentTypes.Sell)
                {
                    if (string.IsNullOrWhiteSpace(this.pageData.Area))
                        throw new Exception("지역을 선택해주세요.");
                }

                if (string.IsNullOrWhiteSpace(this.pageData.Content))
                    throw new Exception("내용을 입력해주세요.");

                if (this.pageData.Content.Length > 500)
                    throw new Exception("최대 500자 까지 가능합니다.");

                var imageSources = new List<byte[]>();

                foreach (var item in streamImageSources)
                {
                    var source = (StreamImageSource)item;
                    var stream = await source.Stream(CancellationToken.None);
                    var buffer = stream.ToByteArray();
                    imageSources.Add(buffer);
                }

                using (var api = new ApiHelper())
                {
                    await api.ExcutePoomPoom(
                        this.pageData.ContentType,
                        this.pageData.Content,
                        this.pageData.Area,
                        this.pageData.Time,
                        this.pageData.UseComment,
                        imageSources.ToArray());
                }

                this.TaskCompletionSource.SetResult(true);
                await this.Navigation.PopAsync();

                if (streamImageSources.Length > 0)
                {
                    await this.DisplayToastAsync("이미지는 관리자 승인 후 노출됩니다.");
                }
            }
            catch (Exception ex)
            {
                await this.DisplayToastAsync(ex.Message);
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }
    }
}