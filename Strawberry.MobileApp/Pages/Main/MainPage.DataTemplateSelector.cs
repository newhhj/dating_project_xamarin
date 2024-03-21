using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Strawberry.MobileApp.Pages.Main
{
	public class MainPage_DataTemplateSelector : DataTemplateSelector
	{
		// 각각의 데이터 템플릿을 정의합니다.
		public DataTemplate ViewLabel { get; set; }
		public DataTemplate View01 { get; set; }
		public DataTemplate View02 { get; set; }
		public DataTemplate View03 { get; set; }
		public DataTemplate View04 { get; set; }
		public DataTemplate View05 { get; set; }
		public DataTemplate View06 { get; set; }
		public DataTemplate View07 { get; set; }
		public DataTemplate View08 { get; set; }
		public DataTemplate View09 { get; set; }
		public DataTemplate View10 { get; set; }
		public DataTemplate View11 { get; set; }
		public DataTemplate View12 { get; set; }
		public DataTemplate View13 { get; set; }
		public DataTemplate View14 { get; set; }
		public DataTemplate LoveFortune { get; set; }

		// 데이터 템플릿을 선택하는 메서드를 재정의합니다.
		protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
		{
			if (item is MainPage_ViewLabel_Data)
				return this.ViewLabel;
			if (item is MainPage_View01_Data)
				return this.View01;
			if (item is MainPage_View02_Data)
				return this.View02;
			if (item is MainPage_View03_Data)
				return this.View03;
			if (item is MainPage_View04_Data)
				return this.View04;
			if (item is MainPage_View05_Data)
				return this.View05;
			if (item is MainPage_View06_Data[])
				return this.View06;
			if (item is MainPage_View_LoveFortune_Data)
				return this.LoveFortune;
			if (item is MainPage_View07_Data)
				return this.View07;
			if (item is MainPage_View08_Data)
				return this.View08;
			if (item is MainPage_View09_Data)
				return this.View09;
			if (item is MainPage_View10_Data)
				return this.View10;
			if (item is MainPage_View11_Data)
				return this.View11;
			if (item is MainPage_View12_Data)
				return this.View12;
			if (item is MainPage_View13_Data)
				return this.View13;
			if (item is MainPage_View14_Data)
				return this.View14;

			// 기본적으로 View01 데이터 템플릿을 반환합니다.
			return this.View01;
		}
	}
}
