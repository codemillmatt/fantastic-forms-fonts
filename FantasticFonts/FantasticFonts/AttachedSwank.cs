using System;
using Xamarin.Forms;
using static Xamarin.Forms.Device;

namespace FantasticFonts
{
	public static class AttachedSwank
	{
		public static readonly BindableProperty CustomFontNameProperty = BindableProperty.CreateAttached("CustomFontName", typeof(string), typeof(AttachedSwank), default(string), BindingMode.OneWay, propertyChanged: HandleCustomFontNameChanged);

		static void HandleCustomFontNameChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var attachedLabel = bindable as Label;

			if (attachedLabel == null)
				return;

			if (newValue == null)
			{
				attachedLabel.FontFamily = Font.Default.FontFamily;
				return;
			}

			string newFont = newValue.ToString();

			if (RuntimePlatform == Device.Android)
			{
				newFont = $"{GetCustomFontFileName(attachedLabel)}#{newValue}";
			}

			attachedLabel.FontFamily = newFont;
		}

		public static void SetCustomFontName(Label label, string fontName)
		{
			label.SetValue(CustomFontNameProperty, fontName);
		}

		public static string GetCustomFontName(Label label)
		{
			return (string)label.GetValue(CustomFontNameProperty);
		}

		public static readonly BindableProperty CustomFontFileNameProperty = BindableProperty.CreateAttached("CustomFontFileName", typeof(string), typeof(AttachedSwank), default(string), BindingMode.OneWay, propertyChanged: HandleCustomFontFileNameChanged);

		static void HandleCustomFontFileNameChanged(BindableObject bindable, object oldValue, object newValue)
		{
			if (RuntimePlatform != Device.Android)
				return;

			var attachedLabel = bindable as Label;
			if (attachedLabel == null)
				return;

			if (newValue == null)
			{
				attachedLabel.FontFamily = Font.Default.FontFamily;
				return;
			}

			var newFont = $"{newValue}#{GetCustomFontName(attachedLabel)}";

			attachedLabel.FontFamily = newFont;
		}

		public static void SetCustomFontFileName(Label label, string fileName)
		{
			label.SetValue(CustomFontFileNameProperty, fileName);
		}

		public static string GetCustomFontFileName(Label label)
		{
			return (string)label.GetValue(CustomFontFileNameProperty);
		}
	}
}
