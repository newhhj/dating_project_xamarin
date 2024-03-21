using Rg.Plugins.Popup.Extensions;
using Strawberry.MobileApp.Helpers;
using Strawberry.MobileApp.Pages.Main;
using Strawberry.MobileApp.Pages.Shares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Strawberry.MobileApp.Pages.Chatting
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChattingBadMannerPage : BasePage
    {
        private int RoomId { get; set; }

        public ChattingBadMannerPage()
        {
            InitializeComponent();
        }

        public Task ShowPageAsync(int roomId)
        {
            this.RoomId = roomId;
            return App.Instance.MainPage.Navigation.PushAsync(this);
        }

        private void Item01_Clicked(object sender, EventArgs e)
        {
            var item = "반말쓰거나 예의없어요.";
            if (this.pageData.SelectedType01Items.Any(x => x == item))
            {
                this.pageData.SelectedType01Items.Remove(item);
                this.pageData.Item01Selected = false;
            }
            else
            {
                if (this.pageData.SelectedType01Items.Count >= 3)
                    return;

                this.pageData.SelectedType01Items.Add(item);
                this.pageData.Item01Selected = true;
            }
        }

        private void Item02_Clicked(object sender, EventArgs e)
        {
            var item = "대화가 불성실 했어요.";
            if (this.pageData.SelectedType01Items.Any(x => x == item))
            {
                this.pageData.SelectedType01Items.Remove(item);
                this.pageData.Item02Selected = false;
            }
            else
            {
                if (this.pageData.SelectedType01Items.Count >= 3)
                    return;

                this.pageData.SelectedType01Items.Add(item);
                this.pageData.Item02Selected = true;
            }
        }

        private void Item03_Clicked(object sender, EventArgs e)
        {
            var item = "채팅에 답변이 없어요.";
            if (this.pageData.SelectedType01Items.Any(x => x == item))
            {
                this.pageData.SelectedType01Items.Remove(item);
                this.pageData.Item03Selected = false;
            }
            else
            {
                if (this.pageData.SelectedType01Items.Count >= 3)
                    return;

                this.pageData.SelectedType01Items.Add(item);
                this.pageData.Item03Selected = true;
            }
        }

        private void Item04_Clicked(object sender, EventArgs e)
        {
            var item = "자랑만 해요.";
            if (this.pageData.SelectedType01Items.Any(x => x == item))
            {
                this.pageData.SelectedType01Items.Remove(item);
                this.pageData.Item04Selected = false;
            }
            else
            {
                if (this.pageData.SelectedType01Items.Count >= 3)
                    return;

                this.pageData.SelectedType01Items.Add(item);
                this.pageData.Item04Selected = true;
            }
        }

        private void Item05_Clicked(object sender, EventArgs e)
        {
            var item = "취향이 아니에요.";
            if (this.pageData.SelectedType01Items.Any(x => x == item))
            {
                this.pageData.SelectedType01Items.Remove(item);
                this.pageData.Item05Selected = false;
            }
            else
            {
                if (this.pageData.SelectedType01Items.Count >= 3)
                    return;

                this.pageData.SelectedType01Items.Add(item);
                this.pageData.Item05Selected = true;
            }
        }

        private void Item06_Clicked(object sender, EventArgs e)
        {
            var item = "영업이나 홍보를 해요.";
            if (this.pageData.SelectedType01Items.Any(x => x == item))
            {
                this.pageData.SelectedType01Items.Remove(item);
                this.pageData.Item06Selected = false;
            }
            else
            {
                if (this.pageData.SelectedType01Items.Count >= 3)
                    return;

                this.pageData.SelectedType01Items.Add(item);
                this.pageData.Item06Selected = true;
            }
        }

        private void Item07_Clicked(object sender, EventArgs e)
        {
            var item = "사기유도하는 유령회원이에요.";
            if (this.pageData.SelectedType01Items.Any(x => x == item))
            {
                this.pageData.SelectedType01Items.Remove(item);
                this.pageData.Item07Selected = false;
            }
            else
            {
                if (this.pageData.SelectedType01Items.Count >= 3)
                    return;

                this.pageData.SelectedType01Items.Add(item);
                this.pageData.Item07Selected = true;
            }
        }

        private void Item08_Clicked(object sender, EventArgs e)
        {
            var item = "성희롱이나 추행하는 대화를 해요.";
            if (this.pageData.SelectedType01Items.Any(x => x == item))
            {
                this.pageData.SelectedType01Items.Remove(item);
                this.pageData.Item08Selected = false;
            }
            else
            {
                if (this.pageData.SelectedType01Items.Count >= 3)
                    return;

                this.pageData.SelectedType01Items.Add(item);
                this.pageData.Item08Selected = true;
            }
        }

        private void Item09_Clicked(object sender, EventArgs e)
        {
            var item = "다짜고짜 연락처 등 무리한 요구를 해요.";
            if (this.pageData.SelectedType01Items.Any(x => x == item))
            {
                this.pageData.SelectedType01Items.Remove(item);
                this.pageData.Item09Selected = false;
            }
            else
            {
                if (this.pageData.SelectedType01Items.Count >= 3)
                    return;

                this.pageData.SelectedType01Items.Add(item);
                this.pageData.Item09Selected = true;
            }
        }

        private void Item10_Clicked(object sender, EventArgs e)
        {
            var item = "음주 강요 또는 주정을 부려요.";
            if (this.pageData.SelectedType02Items.Any(x => x == item))
            {
                this.pageData.SelectedType02Items.Remove(item);
                this.pageData.Item10Selected = false;
            }
            else
            {
                if (this.pageData.SelectedType02Items.Count >= 3)
                    return;

                this.pageData.SelectedType02Items.Add(item);
                this.pageData.Item10Selected = true;
            }
        }

        private void Item11_Clicked(object sender, EventArgs e)
        {
            var item = "이기적이고 강요적이에요.";
            if (this.pageData.SelectedType02Items.Any(x => x == item))
            {
                this.pageData.SelectedType02Items.Remove(item);
                this.pageData.Item11Selected = false;
            }
            else
            {
                if (this.pageData.SelectedType02Items.Count >= 3)
                    return;

                this.pageData.SelectedType02Items.Add(item);
                this.pageData.Item11Selected = true;
            }
        }

        private void Item12_Clicked(object sender, EventArgs e)
        {
            var item = "성희롱, 추행을 해요.";
            if (this.pageData.SelectedType02Items.Any(x => x == item))
            {
                this.pageData.SelectedType02Items.Remove(item);
                this.pageData.Item12Selected = false;
            }
            else
            {
                if (this.pageData.SelectedType02Items.Count >= 3)
                    return;

                this.pageData.SelectedType02Items.Add(item);
                this.pageData.Item12Selected = true;
            }
        }

        private void Item13_Clicked(object sender, EventArgs e)
        {
            var item = "프로필사진과 차이가 크거나 본인이 아니예요.";
            if (this.pageData.SelectedType02Items.Any(x => x == item))
            {
                this.pageData.SelectedType02Items.Remove(item);
                this.pageData.Item13Selected = false;
            }
            else
            {
                if (this.pageData.SelectedType02Items.Count >= 3)
                    return;

                this.pageData.SelectedType02Items.Add(item);
                this.pageData.Item13Selected = true;
            }
        }

        private void Item14_Clicked(object sender, EventArgs e)
        {
            var item = "직업, 나이 등 프로필 스팩과 달라요.";
            if (this.pageData.SelectedType02Items.Any(x => x == item))
            {
                this.pageData.SelectedType02Items.Remove(item);
                this.pageData.Item14Selected = false;
            }
            else
            {
                if (this.pageData.SelectedType02Items.Count >= 3)
                    return;

                this.pageData.SelectedType02Items.Add(item);
                this.pageData.Item14Selected = true;
            }
        }

        private void Item15_Clicked(object sender, EventArgs e)
        {
            var item = "약속시간 및 장소를 정한 뒤 취소 또는 연락이 안되요.";
            if (this.pageData.SelectedType02Items.Any(x => x == item))
            {
                this.pageData.SelectedType02Items.Remove(item);
                this.pageData.Item15Selected = false;
            }
            else
            {
                if (this.pageData.SelectedType02Items.Count >= 3)
                    return;

                this.pageData.SelectedType02Items.Add(item);
                this.pageData.Item15Selected = true;
            }
        }

        private void Item16_Clicked(object sender, EventArgs e)
        {
            var item = "약속장소에 아예 나오지 않았어요.";
            if (this.pageData.SelectedType02Items.Any(x => x == item))
            {
                this.pageData.SelectedType02Items.Remove(item);
                this.pageData.Item16Selected = false;
            }
            else
            {
                if (this.pageData.SelectedType02Items.Count >= 3)
                    return;

                this.pageData.SelectedType02Items.Add(item);
                this.pageData.Item16Selected = true;
            }
        }

        private void Close_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }

        private async void Accept_Clicked(object sender, EventArgs e)
        {
            lock (this.LockData)
            {
                if (this.LockData.IsLocked)
                    return;
                this.LockData.IsLocked = true;
            }

            try
            {
                if (this.pageData.SelectedType01Items.Count == 0
                 && this.pageData.SelectedType02Items.Count == 0
                 && string.IsNullOrWhiteSpace(this.pageData.Item17Text))
                    throw new Exception("한 가지 이상을 선택하거나 기타 이슈를 입력하세요.");


                using (var api = new ApiHelper())
                {
                    var items = new List<string>();
                    if (this.pageData.SelectedType01Items.Count > 0)
                        items.AddRange(this.pageData.SelectedType01Items);
                    if (this.pageData.SelectedType02Items.Count > 0)
                        items.AddRange(this.pageData.SelectedType02Items);
                    if (!string.IsNullOrWhiteSpace(this.pageData.Item17Text))
                        items.Add(this.pageData.Item17Text);

                    await api.ExcuteMannerAndRemoveChattingRoom(
                        this.RoomId,
                        DataModels.AppraisalTypes.BadManner,
                        items.ToArray());
                }

                var mainPage = (MainPage)App.Instance.MainPage.Navigation.NavigationStack
                    .FirstOrDefault(x => x is MainPage);

                var mainPageData = mainPage.BindingContext as MainPage_Data;
                var item = mainPageData.Items
                    .Where(x => x is MainPage_View12_Data)
                    .Where(x => ((MainPage_View12_Data)x).Id == this.RoomId)
                    .FirstOrDefault();

                if (item != null)
                {
                    mainPageData.Items.Remove(item);
                }

                var chattingPage = (ChattingPage)App.Instance.MainPage.Navigation.NavigationStack
                    .FirstOrDefault(x => x is ChattingPage);

                if (chattingPage != null)
                {
                    App.Instance.MainPage.Navigation.RemovePage(chattingPage);
                }

                await this.Navigation.PopAsync();
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