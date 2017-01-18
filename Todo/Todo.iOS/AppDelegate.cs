using UIKit;
using Foundation;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using System.Threading.Tasks;

namespace Todo
{
	[Register("AppDelegate")]
	public partial class AppDelegate : FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			// affects all UISwitch controls in the app
			UISwitch.Appearance.OnTintColor = UIColor.FromRGB(0x91, 0xCA, 0x47);

#if DEBUG
			Xamarin.Calabash.Start();
#endif

			Forms.Init();
			LoadApplication(new App());
			return base.FinishedLaunching(app, options);
		}

		#region Test Cloud backdoors
		#if DEBUG
		[Export("populateDummyData:")]
		public NSString PopulateDummyData(NSString noValue)
		{
			BackdoorHelpers.AddDummyDataToDatabase();
			return new NSString();
		}
		#endif
		#endregion
	}
}