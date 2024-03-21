using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Iid;
using Firebase.Messaging;
using Newtonsoft.Json;
using Strawberry.MobileApp.Helpers;
using Strawberry.MobileApp.Pages.Chatting;
using Strawberry.MobileApp.Pages.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;
using static Android.Content.ClipData;

namespace Strawberry.MobileApp.Droid.FireBaseHelper
{
    [Service(Exported = false)]
    [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
    public class FirebaseService : FirebaseMessagingService
    {
        public override async void OnNewToken(string token)
        {
            try
            {
                var apikey = await Settings.GetApiKey();
                if (!string.IsNullOrWhiteSpace(apikey))
                {
                    using (var http = new HttpClient())
                    {
                        var formData = new MultipartFormDataContent();
                        formData.Add(new StringContent(apikey), "apikey");
                        formData.Add(new StringContent(token), "pushtoken");
                        var res = await http.PostAsync($"{Settings.ServerUrl}/Authentication/UpdatePushToken", formData);
                    }
                }
            }
#if DEBUG
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                    ex = ex.InnerException;

                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
#else
            catch { }
#endif
            finally
            {
                base.OnNewToken(token);
            }
        }

        public override void OnMessageReceived(RemoteMessage message)
        {
            try
            {
                var command = default(string);
                var data = default(string);

                if (message.Data.ContainsKey("command"))
                    command = message.Data["command"];
                if (message.Data.ContainsKey("data"))
                    data = message.Data["data"];

                switch (command)
                {
                    case "chatting:message":
                    {
                        var dataItem = JsonConvert.DeserializeAnonymousType(data, new
                        {
                            ChattingRoomId = default(int),
                            Item = default(ChattingPageData_Message)
                        });

                        var chattingPage = (ChattingPage)App.Instance?.MainPage.Navigation.NavigationStack
                            .Where(x => x is ChattingPage)
                            .Where(x => ((ChattingPage)x).PageData.Room.Id == dataItem.ChattingRoomId)
                            .FirstOrDefault();

                        if (chattingPage != null)
                        {
                            Xamarin.Essentials.MainThread.BeginInvokeOnMainThread(async () =>
                            {
                                await chattingPage.AppendMessageAsync(dataItem.Item);
                            });
                        }
                        else
                        {
                            var mainPage = (MainPage)App.Instance?.MainPage.Navigation.NavigationStack
                                .Where(x => x is MainPage)
                                .FirstOrDefault();

                            if (mainPage != null)
                            {
                                var mainPageData = mainPage.BindingContext as MainPage_Data;
                                var item = (MainPage_View12_Data)mainPageData.Items
                                    .Where(x => x is MainPage_View12_Data)
                                    .Where(x => ((MainPage_View12_Data)x).Id == dataItem.ChattingRoomId)
                                    .FirstOrDefault();

                                if (item != null)
                                {
                                    item.NotReadCount++;
                                }
                            }
                        }

                        break;
                    }
                    case "chatting:closeroom":
                    {
                        var chattingPage = (ChattingPage)App.Instance?.MainPage.Navigation.NavigationStack
                            .Where(x => x is ChattingPage)
                            .FirstOrDefault();
                        if (chattingPage == null)
                            break;

                        var dataItem = JsonConvert.DeserializeAnonymousType(data, new
                        {
                            roomId = default(int)
                        });

                        if (chattingPage.PageData.Room.Id != dataItem.roomId)
                            break;

                        Xamarin.Essentials.MainThread.BeginInvokeOnMainThread(async () =>
                        {
                            if (chattingPage.PageData.Room.Member1.Id == App.Instance.Member.Id)
                            {
                                chattingPage.PageData.Room.IsCloseMember2 = true;
                            }
                            else
                            {
                                chattingPage.PageData.Room.IsCloseMember1 = true;
                            }

                            await chattingPage.AppendMessageAsync(new ChattingPageData_Message
                            {
                                Type = DataModels.MessageTypes.Close
                            });
                        });
                        break;
                    }
                    case "noti:message":
                    {
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            var mainPage = (MainPage)App.Instance?.MainPage.Navigation.NavigationStack
                                .FirstOrDefault(x => x is MainPage);
                            if (mainPage != null && mainPage.IsActive)
                            {
                                _ = mainPage.CheckNotisAsync();
                            }
                        });
                        break;
                    }
                    default:
                        break;
                }
            }
            finally
            {
                base.OnMessageReceived(message);
            }
        }
    }
}