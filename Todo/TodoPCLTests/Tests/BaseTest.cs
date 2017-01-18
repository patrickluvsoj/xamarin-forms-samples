using System;
using Xamarin.UITest;
using NUnit.Framework;

namespace TodoPCLTests
{
	[TestFixture(Platform.Android)]
	[TestFixture(Platform.iOS)]
	public abstract class BaseTest
	{
		protected IApp app;
		protected Platform platform;

		//Initialize page object variables
		protected ItemPage ItemPage;
		protected ListPage ListPage;


		//Constructor for this class. Assigning platform variable to this object
		protected BaseTest(Platform platform)
		{
			this.platform = platform;
		}


		//Setup method will always execute before any tests run
		[SetUp]
		public virtual void BeforeEachTest()
		{
			//AppInitializer class and its method StartApp are custom methods 
			//to abstract the initialization of tests which returns object app
			//Passing platform as variable to determine which platform to start the test
			app = AppInitializer.StartApp(platform);
			app.Screenshot("App initialized");

			//Create instance of app pages & assign it to page variables
			ItemPage = new ItemPage(app, platform);
			ListPage = new ListPage(app, platform);

			//Backdoor method helps pre-populate the app's database with task items
			BackdoorHelpers.PopulateDummyData(app);

			//Operation to sync databse with ListView
			ListPage.TapAddButton();
			ItemPage.CancelTodo();
		}

	}
}
