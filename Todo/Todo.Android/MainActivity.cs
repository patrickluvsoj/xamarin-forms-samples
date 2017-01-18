using Android.App;
using Android.OS;
using Android.Content.PM;

using Java.Interop;


namespace Todo
{
	[Activity(Label = "Todo", Icon = "@drawable/icon", MainLauncher = true,
		ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity :
	global::Xamarin.Forms.Platform.Android.FormsApplicationActivity // superclass new in 1.3
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			global::Xamarin.Forms.Forms.Init(this, bundle);

			LoadApplication(new App());
		}

		#region Xamarin Test Cloud Backdoors
		#if DEBUG

		[Export("PopulateDummyData")]
		public void PopulateDummyData()
		{
			BackdoorHelpers.AddDummyDataToDatabase();
		}

		#endif
		#endregion
	}
}
