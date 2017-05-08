using Xamarin.Forms;

namespace FantasticFonts
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			//MainPage = new FantasticFontsPage();
			//MainPage = new AttachedFontPage();
			MainPage = new FontWithMarkupExtensionPage();
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
