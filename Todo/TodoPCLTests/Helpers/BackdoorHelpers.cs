using System;
using Xamarin.UITest;
using Xamarin.UITest.iOS;
namespace TodoPCLTests
{
	public static class BackdoorHelpers
	{
		public static void PopulateDummyData(IApp app)
		{
			if (app is iOSApp)
				app.Invoke("populateDummyData:", "");
			else
				app.Invoke("PopulateDummyData");
		}
	}
}
