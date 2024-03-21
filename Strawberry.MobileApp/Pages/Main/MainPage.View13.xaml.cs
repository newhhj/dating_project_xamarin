using Strawberry.MobileApp.DataModels;
using Strawberry.MobileApp.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Strawberry.MobileApp.Pages.Main
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage_View13 : DataTemplate
	{
		public MainPage_View13()
		{
			InitializeComponent();
		}

		// "관심리스트" 버튼 클릭 이벤트 핸들러
		private void Button_Clicked(object sender, EventArgs e)
		{
			// MainPage 인스턴스를 가져옵니다.
			var page = (MainPage)App.Instance.MainPage.Navigation.NavigationStack
				.FirstOrDefault(x => x is MainPage);

			// MoveMenu 메서드를 호출하여 관심리스트 화면으로 이동합니다.
			page.MoveMenu(2);
		}
	}
}
