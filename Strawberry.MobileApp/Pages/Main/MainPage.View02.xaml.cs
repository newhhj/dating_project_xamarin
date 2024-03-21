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
	public partial class MainPage_View02 : DataTemplate
	{
		public MainPage_View02()
		{
			InitializeComponent();
		}

		// 뷰 셀이 나타날 때 호출되는 이벤트 처리 메서드
		private void ViewCell_Appearing(object sender, EventArgs e)
		{
			((ViewCell)sender).On<Android>().Element.ForceUpdateSize();
		}
	}
}
