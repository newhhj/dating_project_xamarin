using Strawberry.MobileApp.DataModels;
using Strawberry.MobileApp.Helpers;
using Strawberry.MobileApp.Pages.Shares;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Strawberry.MobileApp.Pages.Join
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page_Join_Profile : BasePage
    {
        public Page_Join_Profile()
        {
            #region Append Empty Image
            {
                var repeatCount = 6 - App.Instance.Member.ProfileImages.Count;
                for (int i = 0; i < repeatCount; i++)
                {
                    App.Instance.Member.ProfileImages.Add(new Member_ProfileImage());
                }
            }
            #endregion

            InitializeComponent();
        }

        private async void Thumbnail01_Clicked(object sender, EventArgs e)
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
                    App.Instance.Member.ProfileImages[0].ProfileImageSource = ImageSource.FromStream(() => { return new MemoryStream(data.buffer); });
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }

        private async void Thumbnail02_Clicked(object sender, EventArgs e)
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
                    App.Instance.Member.ProfileImages[1].ProfileImageSource = ImageSource.FromStream(() => { return new MemoryStream(data.buffer); });
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }

        private async void Thumbnail03_Clicked(object sender, EventArgs e)
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
                    App.Instance.Member.ProfileImages[2].ProfileImageSource = ImageSource.FromStream(() => { return new MemoryStream(data.buffer); });
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }

        private async void Thumbnail04_Clicked(object sender, EventArgs e)
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
                    App.Instance.Member.ProfileImages[3].ProfileImageSource = ImageSource.FromStream(() => { return new MemoryStream(data.buffer); });
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }

        private async void Thumbnail05_Clicked(object sender, EventArgs e)
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
                    App.Instance.Member.ProfileImages[4].ProfileImageSource = ImageSource.FromStream(() => { return new MemoryStream(data.buffer); });
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }

        private async void Thumbnail06_Clicked(object sender, EventArgs e)
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
                    App.Instance.Member.ProfileImages[5].ProfileImageSource = ImageSource.FromStream(() => { return new MemoryStream(data.buffer); });
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }

        private async void Gender_Clicked(object sender, EventArgs e)
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
                list.Add("남자");
                list.Add("여자");

                var result = await DisplayActionSheet("성별 선택", "취소", null, list.ToArray());
                if (string.IsNullOrWhiteSpace(result) || result == "취소")
                    return;

                App.Instance.Member.Gender = result == "남자" ? DataModels.GenderTypes.Male : DataModels.GenderTypes.Female;
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }

        private async void Birth_Clicked(object sender, EventArgs e)
        {
            lock (this.LockData)
            {
                if (this.LockData.IsLocked)
                    return;
                this.LockData.IsLocked = true;
            }

            try
            {
                var year = default(int);
                var month = default(int);
                var day = default(int);

                // 년도 선택
                {
                    if (!App.Instance.Member.Gender.HasValue)
                        throw new Exception("성별을 먼저 선택하세요.");

                    var startYear = default(int);
                    var endYear = default(int);
                    
                    if (App.Instance.Member.Gender == DataModels.GenderTypes.Male)
                    {
                        startYear = DateTime.Today.Year - 24;
                        endYear = startYear - 42;
                    }
                    else
                    {
                        startYear = DateTime.Today.Year - 17;
                        endYear = startYear - 38;
                    }

                    var list = new List<string>();
                    for (int i = startYear; i >= endYear; i--)
                    {
                        list.Add($"{i}년");
                    }

                    var result = await this.DisplayActionSheet("년도 선택", "취소", null, list.ToArray());
                    if (string.IsNullOrWhiteSpace(result) || result == "취소")
                        return;

                    year = int.Parse(result.Replace("년", ""));
                }

                // 월 선택
                {
                    var list = new List<string>();
                    for (int i = 1; i <= 12; i++)
                    {
                        list.Add($"{i:00}월");
                    }

                    var result = await this.DisplayActionSheet("월 선택", "취소", null, list.ToArray());
                    if (string.IsNullOrWhiteSpace(result) || result == "취소")
                        return;

                    month = int.Parse(result.Replace("월", ""));
                }

                // 일 선택
                {
                    var date = new DateTime(year, month, 1);

                    var list = new List<string>();
                    for (int i = date.Day; i <= date.AddMonths(1).AddDays(-1).Day; i++)
                    {
                        list.Add($"{i:00}일");
                    }

                    var result = await this.DisplayActionSheet("일 선택", "취소", null, list.ToArray());
                    if (string.IsNullOrWhiteSpace(result) || result == "취소")
                        return;

                    day = int.Parse(result.Replace("일", ""));
                }

                App.Instance.Member.BirthDay = new DateTime(year, month, day);
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                    ex = ex.InnerException;

                await this.DisplayAlert("알림", ex.Message, "확인");
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }

        private async void Nickname_Clicked(object sender, EventArgs e)
        {
            lock (this.LockData)
            {
                if (this.LockData.IsLocked)
                    return;
                this.LockData.IsLocked = true;
            }

            try
            {
            inputNickname:
                var result = await DisplayPromptAsync("닉네임", "영문, 숫자, 한글만 최대 10자까지 가능합니다.", placeholder: "닉네임을 입력하세요.", maxLength: 10, keyboard: Keyboard.Text);
                if (string.IsNullOrWhiteSpace(result))
                    return;

                if (Regex.IsMatch(result, "[^a-zA-Z0-9가-힣]"))
                {
                    await this.DisplayAlert("알림", "닉네임은 영문, 숫자, 한글만 가능합니다.", "확인");
                    goto inputNickname;
                }

                if (result.Length > 10)
                {
                    await this.DisplayAlert("알림", "닉네임은 10자까지 가능합니다.", "확인");
                    goto inputNickname;
                }

                App.Instance.Member.Nickname = result;
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                    ex = ex.InnerException;

                await this.DisplayAlert("알림", ex.Message, "확인");
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }

        private async void Tall_Clicked(object sender, EventArgs e)
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
                for (int i = 150; i <= 190; i++)
                {
                    list.Add($"{i}cm");
                }
                list.Add($"190cm 이상");

                var result = await DisplayActionSheet("키 선택", "취소", null, list.ToArray());
                if (string.IsNullOrWhiteSpace(result) || result == "취소")
                    return;

                if (result == "190cm 이상")
                    App.Instance.Member.Tall = 191;
                else
                    App.Instance.Member.Tall = int.Parse(Regex.Match(result, "[0-9]{3}").Value);
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }

        private async void BodyStyle_Clicked(object sender, EventArgs e)
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

                if (!App.Instance.Member.Gender.HasValue)
                    throw new Exception("성별을 먼저 선택하세요.");

                if (App.Instance.Member.Gender == DataModels.GenderTypes.Male)
                    textData = "마른/슬림근육/보통/근육질/통통/우람";
                else
                    textData = "마른/슬림/보통/다소볼륨/글래머/통통";

                foreach (var item in textData.Split('/'))
                {
                    list.Add(item.Trim());
                }

                var result = await DisplayActionSheet("체형 선택", "취소", null, list.ToArray());
                if (string.IsNullOrWhiteSpace(result) || result == "취소")
                    return;

                App.Instance.Member.BodyStyle = result;
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                    ex = ex.InnerException;

                await this.DisplayAlert("알림", ex.Message, "확인");
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }

        private async void School_Clicked(object sender, EventArgs e)
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
                var textData = "고등학교/전문대/대학교/석사/박사/기타";

                foreach (var item in textData.Split('/'))
                {
                    list.Add(item.Trim());
                }

                var result = await DisplayActionSheet("학력 선택", "취소", null, list.ToArray());
                if (string.IsNullOrWhiteSpace(result) || result == "취소")
                    return;

                App.Instance.Member.School = result;
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                    ex = ex.InnerException;

                await this.DisplayAlert("알림", ex.Message, "확인");
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }

        private async void Job_Clicked(object sender, EventArgs e)
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
                var textData = "없음/준비 중/아르바이트/자영업/프리랜서/학생/회사원/공무원/군무원/군인/바사관/의경/장교/직업 군인"
                    + "/검찰 공무원/경찰 공무원/소방 공무원/교육직/연구직/강사/교사/교수/교육 공무원/대학생/대학원생/박사/번역사"
                    + "/보건교사/상담교사/유치원교사/저널리스트/중,고등학생/칼럼니스트/통역사/편집 기술자/평론가/경영적/사무직"
                    + "/경리직/기업 임원/비서/사무보조/전문 경영자/기획자/데이터 분석가/조사원/건설직/금융직/세무직/재무관련직"
                    + "/증권 관련직/회계직/공인중개사/세무사/은행원/기계 관련직/기술직/정비원/보험관련직/보험 설계사/부동산 임대업자"
                    + "/가사 서비스직/미용 서비스직/숙박 서비스직/서비스직/기상캐스터/사회복지사/웨딩플래너/플로리스트/네일 아티스트"
                    + "/메이크업 아티스트/조향사/커플매니저/헬스케어 전문가"
                    + "/직접입력";

                foreach (var item in textData.Split('/'))
                {
                    list.Add(item.Trim());
                }

                var result = await DisplayActionSheet("직업 선택", "취소", null, list.ToArray());
                if (string.IsNullOrWhiteSpace(result) || result == "취소")
                    return;

                if (result == "직접입력")
                {
                inoutJob:
                    result = await DisplayPromptAsync("직업 입력", "한글과 공백만 최대 10자까지 가능합니다.", placeholder: "직업을 입력하세요.", maxLength: 10, keyboard: Keyboard.Text);
                    if (string.IsNullOrWhiteSpace(result))
                        return;

                    if (Regex.IsMatch(result, "[^가-힣\\s]"))
                    {
                        await this.DisplayAlert("알림", "한글과 공백만 가능합니다.", "확인");
                        goto inoutJob;
                    }

                    if (result.Length > 10)
                    {
                        await this.DisplayAlert("알림", "10자까지 가능합니다.", "확인");
                        goto inoutJob;
                    }
                }

                App.Instance.Member.Job = result;
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                    ex = ex.InnerException;

                await this.DisplayAlert("알림", ex.Message, "확인");
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

                var result = await DisplayActionSheet("종교 선택", "취소", null, list.ToArray());
                if (string.IsNullOrWhiteSpace(result) || result == "취소")
                    return;

                App.Instance.Member.Religion = result;
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

                var result = await DisplayActionSheet("음주 여부 선택", "취소", null, list.ToArray());
                if (string.IsNullOrWhiteSpace(result) || result == "취소")
                    return;

                App.Instance.Member.Alcohol = result;
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

                var result = await DisplayActionSheet("흡연 여부 선택", "취소", null, list.ToArray());
                if (string.IsNullOrWhiteSpace(result) || result == "취소")
                    return;

                App.Instance.Member.Smoking = result;
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
                if (App.Instance.Member.ProfileImages[0].ProfileImageSource == null)
                    throw new Exception("첫 번째 사진은 필수입니다.");
                if (!App.Instance.Member.Gender.HasValue)
                    throw new Exception("성별을 선택하세요.");
                if (!App.Instance.Member.BirthDay.HasValue)
                    throw new Exception("생일을 선택하세요.");
                if (string.IsNullOrWhiteSpace(App.Instance.Member.Nickname))
                    throw new Exception("닉네임을 입력하세요.");
                if (!App.Instance.Member.Tall.HasValue)
                    throw new Exception("키를 선택하세요.");
                if (string.IsNullOrWhiteSpace(App.Instance.Member.BodyStyle))
                    throw new Exception("체형을 선택하세요.");
                if (string.IsNullOrWhiteSpace(App.Instance.Member.School))
                    throw new Exception("학력을 선택하세요");
                if (string.IsNullOrWhiteSpace(App.Instance.Member.Job))
                    throw new Exception("직업을 선택하세요");
                if (string.IsNullOrWhiteSpace(App.Instance.Member.Religion))
                    throw new Exception("종교를 선택하세요");
                if (string.IsNullOrWhiteSpace(App.Instance.Member.Alcohol))
                    throw new Exception("음주여부를 선택하세요");
                if (string.IsNullOrWhiteSpace(App.Instance.Member.Smoking))
                    throw new Exception("흡연여부를 선택하세요");

                await Navigation.PushAsync(new Page_Join_Location());
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

        private void CloseButton_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }
    }
}