using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

namespace Strawberry.MobileApp.Pages.Main
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage_View03 : DataTemplate
	{
		// MainPage 인스턴스에 접근하기 위한 속성
		private MainPage MainPage { get => (MainPage)App.Instance.MainPage.Navigation.NavigationStack.FirstOrDefault(x => x is MainPage); }

		public MainPage_View03()
		{
			InitializeComponent();
		}

		// 핫딸기 버튼 클릭 이벤트 핸들러
		private void ExcuteHotStrawberry_Clicked(object sender, EventArgs e)
		{
			// 클릭된 항목의 데이터를 가져옴
			var data = (MainPage_View03_Data)((Element)sender).BindingContext;
			// MainPage의 ExcuteHotStrawberry 메서드 호출하여 데이터 전달
			this.MainPage?.ExcuteHotStrawberry(data);
		}

		// 결과보기 버튼 클릭 이벤트 핸들러
		private void ShowResult_Clicked(object sender, EventArgs e)
		{
			// MainPage의 Menu02_Clicked 메서드 호출
			MainPage.Menu02_Clicked(this, EventArgs.Empty);
		}
	}
}
