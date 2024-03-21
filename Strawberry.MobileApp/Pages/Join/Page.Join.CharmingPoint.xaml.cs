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
    public partial class Page_Join_CharmingPoint : BasePage
    {
        public Page_Join_CharmingPoint()
        {
            InitializeComponent();
        }

        public async Task Init()
        {
            this.PageData.Items = new System.Collections.ObjectModel.ObservableCollection<Data_Join_CharmingPoint.ItemData>();

            var text = "1인가구/즐거운 술자리/연락이 잘되요/미소가 이뻐요/비율이 좋아요/맛집도사/다리가 예뻐요/뇌색/허세 없어요/뛰어난 커리어/운동 잘해요/춤을 잘 춰요/긍정적 마인드/소통을 잘해요/유머감각/이야기를 잘 들어줘요/목소리가 좋아요/동안이예요/예의와 매너 굿/다정해요/패션 감각/솔직해요/애교 많아요/피부가 좋아요/웃음이 많아요/털털해요/장난기가 많아요/엉덩이가 예뻐요/경제력/한 사람만 봐요/ISTJ/ISFJ/INFJ/INTJ/ISTP/ISFP/INFP/INTP/ESTP/ESFP/ENFP/ENTP/ESTJ/ESFJ/ENFJ/ENTJ";
            var texts = text.Split('/');

            foreach (var item in texts)
            {
                this.PageData.Items.Add(new Data_Join_CharmingPoint.ItemData
                {
                    Name = item
                });
            }

            using (var http = new HttpClient())
            {
                var formData = new MultipartFormDataContent();
                formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");
                var res = await http.PostAsync($"{Settings.ServerUrl}/Authentication/GetCharmingPoints", formData);
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
            var data = (Data_Join_CharmingPoint.ItemData)((View)sender).BindingContext;

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
                var items = this.PageData.Items
                    .Where(x => x.IsSelected)
                    .ToArray();

                using (var http = new HttpClient())
                {
                    var formData = new MultipartFormDataContent();
                    formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");

                    foreach (var item in items)
                        formData.Add(new StringContent(item.Name), "items");

                    var res = await http.PostAsync($"{Settings.ServerUrl}/Authentication/UpdateCharmingPoints", formData);
                    var resText = await res.Content.ReadAsStringAsync();
                    if (!res.IsSuccessStatusCode)
                        throw new Exception("서버와의 통신에 실패했습니다.");

                    var resData = JsonConvert.DeserializeAnonymousType(resText, new
                    {
                        Message = default(string)
                    });

                    if (!string.IsNullOrWhiteSpace(resData.Message))
                        throw new Exception(resData.Message);

                    var nextPage = new Page_Join_Interest();
                    await nextPage.Init();
                    await this.Navigation.PushAsync(nextPage);
                }
            }
            catch (Exception ex)
            {
                await this.DisplayAlert("알림", ex.Message, "확인");
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }
    }
}