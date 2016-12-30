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

		protected ItemPage ItemPage;
		protected ListPage ListPage;

		//Constructor for this class. Assigning platform variable to object c# this
		protected BaseTest(Platform platform)
		{
			this.platform = platform;
		}


		[SetUp]
		public virtual void BeforeEachTest()
		{
			//Initialize app by calling StartpApp method from AppInitializer class
			//Passing platform as variable to determine which platform to start the test
			app = AppInitializer.StartApp(platform);
			app.Screenshot("App initialized");

			//Create instance of app pages & assign it to page variables
			ItemPage = new ItemPage(app, platform);
			ListPage = new ListPage(app, platform);

			//add items after app initializes
			ListPage.TapAddButton();
			ItemPage.FillName("Cucumber");
			app.Screenshot("Entered Cucumber");
			ItemPage.FillNote("Calabash");
			app.Screenshot("Entered Calabash");
			ItemPage.SaveTodo();
			app.Screenshot("Item saved");

			ListPage.TapAddButton();
			ItemPage.FillName("Ruby");
			app.Screenshot("Entered Ruby");
			ItemPage.FillNote("Rails");
			app.Screenshot("Entered Rails");
			ItemPage.ToggleSwitch();
			ItemPage.SaveTodo();
			app.Screenshot("Item saved");

			ListPage.TapAddButton();
			ItemPage.FillName("Python");
			app.Screenshot("Entered Python");
			ItemPage.FillNote("Django");
			app.Screenshot("Entered Django");
			ItemPage.ToggleSwitch();
			ItemPage.SaveTodo();
			app.Screenshot("Item saved");
		}
	}
}
