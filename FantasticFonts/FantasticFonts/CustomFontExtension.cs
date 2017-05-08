using System;
using Xamarin.Forms.Xaml;
using Xamarin.Forms;
using static Xamarin.Forms.Device;

namespace FantasticFonts
{
	public class CustomFontExtension : IMarkupExtension
	{
		public string FontFileAndName { get; set; }

		public object ProvideValue(IServiceProvider serviceProvider)
		{
			if (RuntimePlatform == Android)
				return FontFileAndName;

			return FontFileAndName.Split(new char[] { '#' })[1];
		}
	}
}
