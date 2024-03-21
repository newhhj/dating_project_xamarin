using Newtonsoft.Json;
using Strawberry.MobileApp.Pages.Shares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Xamarin.Essentials.Permissions;

namespace Strawberry.MobileApp.Pages.Join
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page_Join_Phone : BasePage
    {
        public Page_Join_Phone()
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
                if (!this.PageData.UseNext)
                    return;

                using (var http = new HttpClient())
                {
                    var content = new MultipartFormDataContent();
                    content.Add(new StringContent(this.PageData.PhoneNumber), "phone");
                    var res = await http.PostAsync($"{Settings.ServerUrl}/Authentication/SendSMS", content);
                    var resText = await res.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeAnonymousType(resText, new
                    {
                        message = default(string),
                        phone = default(string),
                        phoneNumber = default(string),
                        code = default(string)
                    });

                    if (!string.IsNullOrWhiteSpace(result.message))
                        throw new Exception(result.message);

                    await this.Navigation.PushAsync(new Join.Page_Join_PhoneCert(result.phoneNumber, result.code));
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