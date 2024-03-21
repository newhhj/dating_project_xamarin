using Newtonsoft.Json;
using Strawberry.MobileApp.Pages.Shares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Strawberry.MobileApp.Pages.Join
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page_Join_Email : BasePage
    {
        public Page_Join_Email()
        {
            InitializeComponent();
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
                if (!this.PageData.IsNextConfirm)
                    return;

                using (var http = new HttpClient())
                {
                    var formData = new MultipartFormDataContent();
                    formData.Add(new StringContent(App.Instance.Member.Email), "email");
                    var res = await http.PostAsync($"{Settings.ServerUrl}/Authentication/CheckEmail", formData);
                    if (!res.IsSuccessStatusCode)
                        throw new Exception("잠시 후에 다시 시도해 주세요");

                    var resData = JsonConvert.DeserializeAnonymousType(await res.Content.ReadAsStringAsync(), new
                    {
                        Message = default(string)
                    });

                    if (!string.IsNullOrWhiteSpace(resData.Message))
                        throw new Exception(resData.Message);
                }

                await this.Navigation.PushAsync(new Page_Join_Password());
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