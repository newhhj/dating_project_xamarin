using FFImageLoading;
using Newtonsoft.Json;
using Strawberry.MobileApp.DataModels;
using Strawberry.MobileApp.Helpers;
using Strawberry.MobileApp.Pages.Near;
using Strawberry.MobileApp.Pages.Shares;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Strawberry.MobileApp.Pages.Join
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page_Join_Preference : BasePage
    {
        public Page_Join_Preference()
        {
            InitializeComponent();
            InitPage();
        }

        private void InitPage()
        {
            if (App.Instance.Member.Gender == DataModels.GenderTypes.Female)
                App.Instance.Member.Preference_MinAge = 25;
            App.Instance.Member.Preference_MaxAge = 49;
            App.Instance.Member.Preference_Range = 30;
            App.Instance.Member.Preference_MinTall = 150;
            App.Instance.Member.Preference_MaxTall = 191;
        }

        

        private async void BeautyOrWealth_Clicked(object sender, EventArgs e)
        {
            lock (this.LockData)
            {
                if (this.LockData.IsLocked)
                    return;
                this.LockData.IsLocked = true;
            }

            try
            {
                var result = await this.DisplayActionSheet($"{(App.Instance.Member.Gender == GenderTypes.Male ? "미모" : "재력")} 선호 선택", "취소", null, "예", "아니오");
                App.Instance.Member.Preference_BeautyOrWealth = result == "예";
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }

        private async void Body_Clicked(object sender, EventArgs e)
        {
            lock (this.LockData)
            {
                if (this.LockData.IsLocked)
                    return;
                this.LockData.IsLocked = true;
            }

            try
            {
                var list = new List<string>();
                var textData = default(string);

                if (App.Instance.Member.Gender == GenderTypes.Male)
                    textData = "마른/슬림/보통/다소볼륨/글래머/통통";
                else
                    textData = "마른/슬림근육/보통/근육질/통통/우람";

                foreach (var item in textData.Split('/'))
                {
                    list.Add(item.Trim());
                }

                var result = await DisplayActionSheet("체형 선호 선택", "취소", null, list.ToArray());
                if (string.IsNullOrWhiteSpace(result) || result == "취소")
                    return;

                App.Instance.Member.Preference_BodyStyle = result;
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }

        private async void Religion_Clicked(object sender, EventArgs e)
        {
            lock (this.LockData)
            {
                if (this.LockData.IsLocked)
                    return;
                this.LockData.IsLocked = true;
            }

            try
            {
                var list = new List<string>();
                var textData = "무교/기독교/불교/천주교/원불교/기타";

                foreach (var item in textData.Split('/'))
                {
                    list.Add(item.Trim());
                }

                var result = await DisplayActionSheet("종교 선호", "취소", null, list.ToArray());
                if (string.IsNullOrWhiteSpace(result) || result == "취소")
                    return;

                App.Instance.Member.Preference_Religion = result;
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }

        private async void Alcohol_Clicked(object sender, EventArgs e)
        {
            lock (this.LockData)
            {
                if (this.LockData.IsLocked)
                    return;
                this.LockData.IsLocked = true;
            }

            try
            {
                var list = new List<string>();
                var textData = "안함/가끔/자주";

                foreach (var item in textData.Split('/'))
                {
                    list.Add(item.Trim());
                }

                var result = await DisplayActionSheet("음주 선호 선택", "취소", null, list.ToArray());
                if (string.IsNullOrWhiteSpace(result) || result == "취소")
                    return;

                App.Instance.Member.Preference_Alcohol = result;
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }

        private async void Smoking_Clicked(object sender, EventArgs e)
        {
            lock (this.LockData)
            {
                if (this.LockData.IsLocked)
                    return;
                this.LockData.IsLocked = true;
            }

            try
            {
                var list = new List<string>();
                var textData = "안함/가끔/자주";

                foreach (var item in textData.Split('/'))
                {
                    list.Add(item.Trim());
                }

                var result = await DisplayActionSheet("흡연 선호 선택", "취소", null, list.ToArray());
                if (string.IsNullOrWhiteSpace(result) || result == "취소")
                    return;

                App.Instance.Member.Preference_Smoking = result;
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }

        private async void Priority_Clicked(object sender, EventArgs e)
        {
            lock (this.LockData)
            {
                if (this.LockData.IsLocked)
                    return;
                this.LockData.IsLocked = true;
            }

            try
            {
                var list = new List<string>();
                var textData = $"없음/{(App.Instance.Member.Gender == GenderTypes.Male ? "미모" : "재력")}/나이/거리/키/체형/종교/음주/흡연";

                foreach (var item in textData.Split('/'))
                {
                    list.Add(item.Trim());
                }

                var result = await DisplayActionSheet("우선 조건 선택", "취소", null, list.ToArray());
                if (string.IsNullOrWhiteSpace(result) || result == "취소")
                    return;

                switch (result)
                {
                    case "미모":
                    case "재력":
                        App.Instance.Member.Preference_Priority = PriorityTypes.BeautyOrWealth;
                        break;
                    case "나이":
                        App.Instance.Member.Preference_Priority = PriorityTypes.Age;
                        break;
                    case "거리":
                        App.Instance.Member.Preference_Priority = PriorityTypes.Range;
                        break;
                    case "키":
                        App.Instance.Member.Preference_Priority = PriorityTypes.Tall;
                        break;
                    case "체형":
                        App.Instance.Member.Preference_Priority = PriorityTypes.Body;
                        break;
                    case "종교":
                        App.Instance.Member.Preference_Priority = PriorityTypes.Religion;
                        break;
                    case "음주":
                        App.Instance.Member.Preference_Priority = PriorityTypes.Alcohol;
                        break;
                    case "흡연":
                        App.Instance.Member.Preference_Priority = PriorityTypes.Smoking;
                        break;
                    case "없음":
                    default:
                        App.Instance.Member.Preference_Priority = PriorityTypes.None;
                        break;
                }
            }
            finally
            {
                this.LockData.IsLocked = false;
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
                using (var http = new HttpClient())
                {
                    var member = App.Instance.Member;
                    var formDataContent = new MultipartFormDataContent();

                    formDataContent.Add(new StringContent(member.Id.ToString()), "Id");
                    if (member.Id == 0)
                    {
                        if (member.KakaoKey.HasValue)
                            formDataContent.Add(new StringContent(member.KakaoKey.ToString()), "KakaoKey");
                        if (!string.IsNullOrWhiteSpace(member.PhoneNumber))
                            formDataContent.Add(new StringContent(member.PhoneNumber.ToString()), "PhoneNumber");
                        if (!string.IsNullOrWhiteSpace(member.Email))
                            formDataContent.Add(new StringContent(member.Email.ToString()), "Email");
                        if (!string.IsNullOrWhiteSpace(member.Password))
                            formDataContent.Add(new StringContent(member.Password.ToString()), "Password");
                        formDataContent.Add(new StringContent(member.ConsentMarketing.ToString()), "ConsentMarketing");
                    }
                    formDataContent.Add(new StringContent(member.Gender.ToString()), "Gender");
                    if (member.BirthDay.HasValue)
                        formDataContent.Add(new StringContent(member.BirthDay.Value.ToString()), "BirthDay");
                    formDataContent.Add(new StringContent(member.Nickname.ToString()), "Nickname");
                    formDataContent.Add(new StringContent(member.Tall.ToString()), "Tall");
                    formDataContent.Add(new StringContent(member.BodyStyle.ToString()), "BodyStyle");
                    formDataContent.Add(new StringContent(member.School.ToString()), "School");
                    formDataContent.Add(new StringContent(member.Job.ToString()), "Job");
                    formDataContent.Add(new StringContent(member.Religion.ToString()), "Religion");
                    formDataContent.Add(new StringContent(member.Alcohol.ToString()), "Alcohol");
                    formDataContent.Add(new StringContent(member.Smoking.ToString()), "Smoking");
                    formDataContent.Add(new StringContent(member.Lat.ToString()), "Lat");
                    formDataContent.Add(new StringContent(member.Lng.ToString()), "Lng");
                    formDataContent.Add(new StringContent(member.Preference_MinAge.ToString()), "Preference_MinAge");
                    formDataContent.Add(new StringContent(member.Preference_MaxAge.ToString()), "Preference_MaxAge");
                    formDataContent.Add(new StringContent(member.Preference_Range.ToString()), "Preference_Range");
                    formDataContent.Add(new StringContent(member.Preference_MinTall.ToString()), "Preference_MinTall");
                    formDataContent.Add(new StringContent(member.Preference_MaxTall.ToString()), "Preference_MaxTall");
                    formDataContent.Add(new StringContent(member.Preference_BeautyOrWealth.ToString()), "Preference_BeautyOrWealth");
                    if (!string.IsNullOrWhiteSpace(member.Preference_BodyStyle))
                        formDataContent.Add(new StringContent(member.Preference_BodyStyle.ToString()), "Preference_BodyStyle");
                    if (!string.IsNullOrWhiteSpace(member.Preference_Religion))
                        formDataContent.Add(new StringContent(member.Preference_Religion.ToString()), "Preference_Religion");
                    if (!string.IsNullOrWhiteSpace(member.Preference_Alcohol))
                        formDataContent.Add(new StringContent(member.Preference_Alcohol.ToString()), "Preference_Alcohol");
                    if (!string.IsNullOrWhiteSpace(member.Preference_Smoking))
                        formDataContent.Add(new StringContent(member.Preference_Smoking.ToString()), "Preference_Smoking");
                    formDataContent.Add(new StringContent(member.Preference_Priority.ToString()), "Preference_Priority");

                    foreach (var image in member.ProfileImages)
                    {
                        var source = image.ProfileImageSource as StreamImageSource;
                        if (source != null)
                        {
                            var stream = await source.Stream(CancellationToken.None);
                            var buffer = stream.ToByteArray();

                            formDataContent.Add(new StringContent(image.Id.ToString()), "ProfileImageIds");
                            formDataContent.Add(new ByteArrayContent(buffer), "ProfileImages", $"{Guid.NewGuid()}.jpg");
                        }
                    }

                    var referrer = default(string);
                    try
                    {
                        referrer = await DependencyService.Get<IDeviceHelper>().GetReferrer();
                    }
                    catch { }

                    if (!string.IsNullOrWhiteSpace(referrer))
                        formDataContent.Add(new StringContent(referrer), "Referrer");


                    var res = await http.PostAsync($"{Settings.ServerUrl}/Authentication/JoinMember", formDataContent);
                    var resText = await res.Content.ReadAsStringAsync();
                    if (res.IsSuccessStatusCode)
                    {
                        var resData = JsonConvert.DeserializeAnonymousType(resText, new
                        {
                            Message = default(string),
                            ApiKey = default(string),
                            Id = default(int),
                            ProfileImages = default(ObservableCollection<Member_ProfileImage>),
                            State = default(MemberStateTypes?)
                        });

                        if (!string.IsNullOrWhiteSpace(resData.Message))
                            throw new Exception(resData.Message);


                        await Settings.SetApiKey(resData.ApiKey);

                        App.Instance.Member.MemberState = resData.State ?? MemberStateTypes.JoinWait;
                        App.Instance.Member.Id = resData.Id;
                        App.Instance.Member.ProfileImages = resData.ProfileImages;
                        for (int i = 0; i < 6 - App.Instance.Member.ProfileImages.Count; i++)
                            App.Instance.Member.ProfileImages.Add(new Member_ProfileImage());

                        var nextPage = default(Page);
                        if (resData.State == MemberStateTypes.JoinConfirm)
                        {
                            var page = new Join.Page_Join_CharmingPoint();
                            await page.Init();
                            nextPage = page;
                            await this.Navigation.PushAsync(nextPage);
                        }
                        else
                        {
                            nextPage = new Page_Join_Confirm();
                        }

                        await this.Navigation.PushAsync(nextPage);

                        var removePages = this.Navigation.NavigationStack
                            .Where(x => x != nextPage)
                            .ToArray();

                        foreach (var removePage in removePages)
                            this.Navigation.RemovePage(removePage);
                    }
                    else
                    {
                        throw new Exception("서버와의 통신에 실패했습니다.");
                    }
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