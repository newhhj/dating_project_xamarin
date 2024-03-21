using Newtonsoft.Json;
using Strawberry.MobileApp.Pages.Shares;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Strawberry.MobileApp.Pages.Join
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page_Join_Interest : BasePage
    {
        public Page_Join_Interest()
        {
            InitializeComponent();
        }



        public async Task Init()
        {
            this.PageData.Items = new ObservableCollection<Data_Join_Interest.ItemData>();

            var text = "즐거운 음주/영화관람/맛집탐방/진지한 만남/훈남훈녀/놀이동산/넷플릭스/음주가무/혼술/IT/봉사활동/가벼운 술자리/결혼/패션/명품/애플신상/파티/자기개발/운동 스포츠/드라이브/얼리어답터/비혼/퇴근 한잔/재혼/웹툰/지구환경/웰빙/요리/건강 헬스/친구만 원해/국내 여행/해외 여행/클럽/음악 노래/쇼핑/전시 박람/캠핑 레져/재테크/휴양지/외국어";
            var texts = text.Split('/');

            foreach (var item in texts)
            {
                this.PageData.Items.Add(new Data_Join_Interest.ItemData
                {
                    Name = item
                });
            }

            using (var http = new HttpClient())
            {
                var formData = new MultipartFormDataContent();
                formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");
                var res = await http.PostAsync($"{Settings.ServerUrl}/Authentication/GetInterests", formData);
                var resText = await res.Content.ReadAsStringAsync();
                if (!res.IsSuccessStatusCode)
                    throw new Exception("서버와의 통신에 실패했습니다.");

                var resData = JsonConvert.DeserializeAnonymousType(resText, new
                {
                    Message = default(string),
                    Items = default(string[])
                });

                if (!string.IsNullOrWhiteSpace(resData.Message))
                    throw new Exception(resData.Message);

                var items = this.PageData.Items
                    .Where(x => resData.Items.Any(z => z == x.Name))
                    .ToArray();

                foreach (var item in items)
                    item.IsSelected = true;
            }
        }

        private void CloseButton_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }

        private void Item_Clicked(object sender, EventArgs e)
        {
            var data = (Data_Join_Interest.ItemData)((View)sender).BindingContext;

            if (!data.IsSelected && this.PageData.Items.Count(x => x.IsSelected) >= 3)
            {
                this.DisplayAlert("알림", "최대 3가지를 선택할 수 있습니다.", "확인");
            }
            else
            {
                data.IsSelected = !data.IsSelected;
            }
        }

        private async void NextButton_Clicked(object sender, EventArgs e)
        {
            lock (this.LockData)
            {
                if (this.LockData.IsLocked)
                    return;
                this.LockData.IsLocked = true;
            }

            try
            {
                indicator.IsVisible = true;
                await Task.Delay(1);

                var items = this.PageData.Items
                    .Where(x => x.IsSelected)
                    .ToArray();

                using (var http = new HttpClient())
                {
                    var formData = new MultipartFormDataContent();
                    formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");

                    foreach (var item in items)
                        formData.Add(new StringContent(item.Name), "items");

                    var res = await http.PostAsync($"{Settings.ServerUrl}/Authentication/UpdateInterests", formData);
                    var resText = await res.Content.ReadAsStringAsync();
                    if (!res.IsSuccessStatusCode)
                        throw new Exception("서버와의 통신에 실패했습니다.");

                    var resData = JsonConvert.DeserializeAnonymousType(resText, new
                    {
                        Message = default(string)
                    });

                    if (!string.IsNullOrWhiteSpace(resData.Message))
                        throw new Exception(resData.Message);

                    var nextPage = new Main.MainPage();
                    await nextPage.InitAsync();
                    await this.Navigation.PushAsync(nextPage);

                    var removePages = this.Navigation.NavigationStack
                        .Where(x => x != nextPage)
                        .ToArray();
                    foreach (var page in removePages)
                        this.Navigation.RemovePage(page);
                }
            }
            catch (Exception ex)
            {
                await this.DisplayAlert("알림", ex.Message, "확인");
            }
            finally
            {
                this.LockData.IsLocked = false;
                indicator.IsVisible = false;
            }
        }
    }
}