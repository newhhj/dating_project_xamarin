using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Strawberry.MobileApp.Pages.Shares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Strawberry.MobileApp.Pages.Main
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage_Dialog_RemovePartner : PopupPage
	{
		// 작업 완료를 나타내는 TaskCompletionSource
		public TaskCompletionSource<bool> TaskCompletionSource { get; private set; }

		public MainPage_Dialog_RemovePartner()
		{
			InitializeComponent();

			// TaskCompletionSource 초기화
			this.TaskCompletionSource = new TaskCompletionSource<bool>();
		}

		protected override bool OnBackButtonPressed()
		{
			var result = base.OnBackButtonPressed();

			// 작업이 완료되었음을 알림
			this.TaskCompletionSource.SetResult(false);

			return result;
		}

		protected override bool OnBackgroundClicked()
		{
			var result = base.OnBackgroundClicked();

			// 작업이 완료되었음을 알림
			this.TaskCompletionSource.SetResult(false);

			return result;
		}

		private void Deny_Clicked(object sender, EventArgs e)
		{
			// 다이얼로그를 닫고 작업이 완료되었음을 알림
			this.Navigation.PopPopupAsync();
			this.TaskCompletionSource.SetResult(false);
		}

		private void Allow_Clicked(object sender, EventArgs e)
		{
			// 다이얼로그를 닫고 작업이 완료되었음을 알림
			this.Navigation.PopPopupAsync();
			this.TaskCompletionSource.SetResult(true);
		}
	}
}
